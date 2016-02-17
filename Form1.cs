using System;
using System.Windows.Forms;
using System.IO;

namespace pk2pk
{
    public partial class Form1 : Form
    {
        public Form1()
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

            Converter.updateConfig(subreg, country, _3DSreg, g6trname, g6trgend);
        }
        internal static int country = 0x31; // US
        internal static int subreg = 0x7;   // California
        internal static int _3DSreg = 0x1;  // Americas
        internal static string g6trname = "PKHeX";
        internal static byte g6trgend = 0;
        
        private void convert(string path)
        {
            FileInfo fi = new FileInfo(path);
            string filename = Path.GetFileNameWithoutExtension(path);
            string foldername = Path.GetDirectoryName(path);
            string extension = Path.GetExtension(path);
            long len = fi.Length;
            byte[] data;
            byte[] newdata = new byte[136];
            int game;

            if ((len == PK3.SIZE_STORED || len == PK3.SIZE_PARTY) && RB_I3.Checked)
            {
                game = 4;
                data = File.ReadAllBytes(path);
                if (!PKX.verifychk(data))
                    goto invalidchk;
                newdata = new PK3(data).convertToPK4().Data;
                if (RB_O5.Checked)
                {
                    newdata = new PK4(newdata).convertToPK5().Data;
                    game = 5;
                }
                else if (RB_O6.Checked)
                {
                    newdata = new PK4(newdata).convertToPK5().Data;
                    newdata = new PK5(newdata).convertToPK6().Data;
                    game = 6;
                }
            }
            else if ((len == PK4.SIZE_STORED || len == PK4.SIZE_PARTY) && RB_I4.Checked)
            {
                game = 5;
                data = File.ReadAllBytes(path);
                if (!PKX.verifychk(data))
                    goto invalidchk;
                newdata = new PK4(data).convertToPK5().Data;
                if (RB_O6.Checked)
                {
                    newdata = new PK5(newdata).convertToPK6().Data;
                    game = 6;
                }
            }
            else if ((len == PK5.SIZE_STORED || len == PK5.SIZE_PARTY) && RB_I5.Checked)
            {
                game = 6;
                data = File.ReadAllBytes(path);
                if (!PKX.verifychk(data))
                    goto invalidchk;
                if (BitConverter.ToUInt32(data, 0x44) != 0) // if PTHGSS met data exists
                    data = new PK4(data).convertToPK5().Data;

                newdata = new PK5(data).convertToPK6().Data;
            }
            else
            {
                RTB_Output.AppendText($"Invalid file supplied. ({filename}{extension})" + Environment.NewLine);
                goto quit;
            }

        invalidchk:
            {
                if (!PKX.verifychk(data))
                {
                    RTB_Output.AppendText($"Invalid checksum. Is the file encrypted? ({filename}{extension})" + Environment.NewLine);
                    goto quit;
                }
            } 
            
            // Output
            string ext;
            if (RB_O6.Checked)
                ext = ".pk6";
            else if (RB_O5.Checked)
                ext = ".pk5";
            else ext = ".pk4";
            if (RB_PKM.Checked)
                ext = ".pkm";
            if (RB_PKM.Checked && RB_O6.Checked)
                ext = ".pkx";
            string newname = Path.Combine(foldername, filename + ext);
            if (newname == path) 
                newname = Path.Combine(foldername, filename + " - " + game + "th" + ext);
            File.WriteAllBytes(newname,newdata);

            var pk6 = new PK6();
            if (game == 4)
                pk6 = new PK4(newdata).convertToPK5().convertToPK6();
            else if (game == 5)
                pk6 = new PK5(newdata).convertToPK6();
            else
                pk6 = new PK6(newdata);

            RTB_Output.AppendText(
                $"{pk6.Nickname} converted to Gen {game} @ {pk6.OT_Name} ({pk6.TID.ToString("00000")}/{pk6.SID.ToString("00000")}){Environment.NewLine}");
            quit:
            {
                RTB_Output.AppendText("----------" + Environment.NewLine);
                RTB_Output.SelectionStart = RTB_Output.Text.Length;
                RTB_Output.ScrollToCaret();
            }
        }

        private void ddEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
        private void ddDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string path = files[0]; // open first D&D

            // detect if it is a folder (load into boxes or not)
            FileAttributes attr = File.GetAttributes(path);
            bool isFolder = (attr & FileAttributes.Directory) == FileAttributes.Directory;
            if (isFolder)
            {
                files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            }

            ProgressInit(files.Length);

            // files are loaded, parse them.
            foreach (string pkm in files)
            {
                convert(pkm);
                pBar1.PerformStep();
            }
        }
        private void ProgressInit(int count)
        {
            // Display the ProgressBar control.
            pBar1.Visible = true;
            pBar1.Minimum = 1;
            pBar1.Maximum = count;
            pBar1.Step = 1;
            pBar1.Value = 1;
        }
        private void clear(object sender, EventArgs e)
        {
            RTB_Output.Clear();
        }
        private void changeIOSetting(object sender, EventArgs e)
        {
            if (RB_I3.Checked)
            {
                RB_O4.Enabled = true;
                RB_O5.Enabled = true;
                RB_O6.Enabled = true;
            }
            else if (RB_I4.Checked)
            {
                RB_O4.Enabled = false;
                RB_O5.Enabled = true;
                RB_O6.Enabled = true;
                if (RB_O4.Checked)
                {
                    RB_O5.Checked = true;
                }
            }
            else if (RB_I5.Checked)
            {
                RB_O4.Enabled = false;
                RB_O5.Enabled = false;
                RB_O6.Enabled = true;

                RB_O6.Checked = true;
            }

            B_Options.Visible = RB_O6.Checked;
        }
        private void B_Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Drag and drop files/folder into the program window" + Environment.NewLine + Environment.NewLine + "Program by Kaphotics", "Help/About");
        }

        private void B_Options_Click(object sender, EventArgs e)
        {
            G6Options f = new G6Options();
            f.ShowDialog();
        }

        private void B_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog {Filter = "PKM File|*.pkm;*.3gpkm|All Files|*.*"};
            if (ofd.ShowDialog() != DialogResult.OK) return;
            string path = ofd.FileName;
            convert(path);
        }
    }
}
