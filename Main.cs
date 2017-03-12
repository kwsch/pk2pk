using System;
using System.Collections.Concurrent;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PKHeX.Core;

namespace pk2pk
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            DragEnter += ddEnter;
            DragDrop += ddDrop;
            RTB_Output.DragEnter += ddEnter;
            RTB_Output.DragDrop += ddDrop;

            RTB_Output.Text = "Select Input and Output Generation." + Environment.NewLine 
                + Environment.NewLine 
                + "Drag & Drop each Pokémon to transfer." + Environment.NewLine;
            RTB_Output.AppendText("----------" + Environment.NewLine);

            CB_PKMTypes.Items.AddRange(PKMTypes.Select(t => t.Name).ToArray());
            CB_PKMTypes.SelectedIndex = 0;
        }
        
        private static readonly Type[] PKMTypes = typeof(PKM).Assembly.GetTypes()
                    .Where(type => type.IsSubclassOf(typeof(PKM)))
                    .OrderByDescending(f => f.Name.Last())
                    .ToArray();

        private PKM getBlank(Type t) => (PKM)Activator.CreateInstance(t, Enumerable.Repeat(null as PKM, t.GetConstructors()[0].GetParameters().Length).ToArray());
        private Type getType() => PKMTypes.FirstOrDefault(x => x.Name == CB_PKMTypes.Text);

        private SaveFile SAV;
        private PKM Blank;
        private bool reflectiveConvertPrompted;
        private bool reflectiveConvertAllowed;

        private ConcurrentBag<string[]> output = new ConcurrentBag<string[]>();
        private bool log(string path, bool success, string comment)
        {
            string line1 = success ? "Converted" : "Did not convert" + ": " + path;
            string line2 = comment;

            Console.WriteLine(line1 + Environment.NewLine);
            if (!string.IsNullOrWhiteSpace(line2))
            {
                output.Add(new[] {line1, line2});
                Console.WriteLine(line2);
            }
            else
                output.Add(new[] {line1});
            return success;
        }

        private bool checkCompatible(PKM pk)
        {
            if (pk.Species > SAV.MaxSpeciesID)
                return false;

            if (pk.HeldItem > SAV.MaxItemID)
                pk.HeldItem = 0;
            if (pk.Nickname.Length > SAV.NickLength)
                pk.Nickname = pk.Nickname.Substring(0, SAV.NickLength);
            if (pk.OT_Name.Length > SAV.OTLength)
                pk.OT_Name = pk.OT_Name.Substring(0, SAV.OTLength);
            if (pk.Moves.Any(move => move > SAV.MaxMoveID))
            {
                pk.Moves = pk.Moves.Select(move => move <= SAV.MaxMoveID ? move : 0).ToArray();
                pk.FixMoves();
            }
            if (pk.EVs.Any(ev => ev > SAV.MaxEV))
                pk.EVs = pk.EVs.Select(ev => Math.Min(SAV.MaxEV, ev)).ToArray();
            if (pk.IVs.Any(ev => ev > SAV.MaxEV))
                pk.IVs = pk.IVs.Select(iv => Math.Min(SAV.MaxIV, iv)).ToArray();

            return true;
        }
        private bool convert(string path, Type t)
        {
            FileInfo fi = new FileInfo(path);
            bool prefer7 = fi.Extension.EndsWith("7");
            int genPref = prefer7 ? 7 : 6;

            if (!PKX.getIsPKM(fi.Length))
                return log(path, false, "Not a valid PKM size.");

            var pk = PKMConverter.getPKMfromBytes(File.ReadAllBytes(path), prefer: genPref);
            if (pk.GetType() == t)
                return log(path, false, "Matches desired format.");

            if (pk.Species <= 0)
                return log(path, false, "Not a valid PKM.");

            string comment;
            var converted = PKMConverter.convertToFormat(pk, t, out comment);
            if (converted == null)
            {
                if (!reflectiveConvertPrompted)
                {
                    reflectiveConvertPrompted = true;
                    var dr = Prompt(MessageBoxButtons.YesNo, "Incompatible conversion detected.", "Try reflective conversion?");
                    if (dr == DialogResult.Yes)
                        reflectiveConvertAllowed = true;
                }
                if (!reflectiveConvertAllowed)
                    return log(path, false, "Not converting via reflection.");

                try
                {
                    if (!checkCompatible(pk))
                        return log(path, false, "Unable to transfer with reflection.");

                    converted = Blank.Clone();
                    pk.TransferPropertiesWithReflection(pk, converted);
                    comment = "Converted via reflection.";
                }
                catch (Exception e)
                {
                    return log(path, false, e.Message);
                }
            }

            // Write File
            try
            {
                string foldername = Path.GetDirectoryName(path);
                if (foldername == null)
                    return log(path, false, "Invalid Folder.");

                File.WriteAllBytes(Path.Combine(foldername, converted.FileName), converted.DecryptedBoxData);
                return log(path, true, comment);
            }
            catch (Exception e)
            {
                return log(path, false, e.Message);
            }
        }
        
        private static void ddEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
        private void ddDrop(object sender, DragEventArgs e)
        {
            Type t = getType();
            if (t == null)
                return;
            Blank = getBlank(t);
            SAV = SaveUtil.getBlankSAV(Blank.Format, PKMConverter.OT_Name);

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string path = files[0]; // open first D&D
            if (Directory.Exists(path))
                files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

            output = new ConcurrentBag<string[]>();
            var convertCount = new ConcurrentBag<bool>();
            RTB_Output.AppendText("----------" + Environment.NewLine);
            Parallel.ForEach(files, file => { convertCount.Add(convert(file, t));});
            RTB_Output.AppendText(string.Join(Environment.NewLine, output.SelectMany(s => s)));
            Alert($"Converted {convertCount.Count(a => a)} of {files.Length} to {t.Name}.");
        }
        private void B_Open_Click(object sender, EventArgs e)
        {
            Type t = getType();
            if (t == null)
                return;
            Blank = getBlank(t);
            SAV = SaveUtil.getBlankSAV(Blank.Format, PKMConverter.OT_Name);

            OpenFileDialog ofd = new OpenFileDialog { Filter = "PKM File|*.pkm|All Files|*.*" };
            if (ofd.ShowDialog() != DialogResult.OK) return;
            string path = ofd.FileName;

            output = new ConcurrentBag<string[]>();
            convert(path, t);
            RTB_Output.AppendText(string.Join(Environment.NewLine, output.SelectMany(s => s)));
        }

        private void ClearOutput(object sender, EventArgs e) => RTB_Output.Clear();
        private void B_Options_Click(object sender, EventArgs e) => new Options().ShowDialog();
        private void B_Help_Click(object sender, EventArgs e)
        {
            Alert("Drag and drop files/folder into the program window" + Environment.NewLine + Environment.NewLine + "Program by Kaphotics");
        }

        private static DialogResult Alert(params string[] lines)
        {
            System.Media.SystemSounds.Asterisk.Play();
            string msg = string.Join(Environment.NewLine + Environment.NewLine, lines);
            return MessageBox.Show(msg, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private static DialogResult Prompt(MessageBoxButtons btn, params string[] lines)
        {
            System.Media.SystemSounds.Question.Play();
            string msg = string.Join(Environment.NewLine + Environment.NewLine, lines);
            return MessageBox.Show(msg, "Prompt", btn, MessageBoxIcon.Asterisk);
        }
    }
}
