using System;
using System.Windows.Forms;

namespace pk2pk
{
    public partial class G6Options : Form
    {
        public G6Options()
        {
            InitializeComponent();
            var dsregion_list = new[] {
                    new { Text = "Americas (NA/SA)", Value = 1 },
                    new { Text = "Europe (EU)", Value = 2 },
                    new { Text = "Japan (日本)", Value = 0 },
                    new { Text = "China (中国)", Value = 4 },
                    new { Text = "Korea (한국)", Value = 5 },
                    new { Text = "Taiwan (臺灣)", Value = 6 }
                };

            // Set ComboBox Fields

            CB_3DSReg.DisplayMember = "Text";
            CB_3DSReg.ValueMember = "Value";
            CB_3DSReg.DataSource = dsregion_list;

            CB_SubRegion.DisplayMember = "Text";
            CB_SubRegion.ValueMember = "Value";
            CB_Country.DisplayMember = "Text";
            CB_Country.ValueMember = "Value";
            setCountrySubRegion(CB_Country, "countries");


            CB_3DSReg.SelectedValue = Form1._3DSreg;
            CB_Country.SelectedValue = Form1.country;
            CB_SubRegion.SelectedValue = Form1.subreg;

            RB_F.Checked = Convert.ToBoolean(Form1.g6trgend);
            TB_TR.Text = Form1.g6trname;
        }

        private void B_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void B_Save_Click(object sender, EventArgs e)
        {
            Form1.country = (int)CB_Country.SelectedValue;
            Form1.subreg = (int)CB_SubRegion.SelectedValue;
            Form1._3DSreg = (int)CB_3DSReg.SelectedValue;
            Form1.g6trgend = Convert.ToByte(RB_F.Checked);
            Form1.g6trname = TB_TR.Text;
            Form1.g6trname = TB_TR.Text.Length == 0 ? "PKHeX" : TB_TR.Text;

            Close();
        }

        private void updateCountry(object sender, EventArgs e)
        {
            if (Util.getIndex(sender as ComboBox) > 0)
                setCountrySubRegion(CB_SubRegion, "sr_" + Util.getIndex(sender as ComboBox).ToString("000"));
        }
        private void setCountrySubRegion(ComboBox CB, string type)
        {
            int index = Util.getIndex(CB);
            CB.DataSource = Util.getCBList(type, "en");

            if (index > 0 && index < CB.Items.Count)
                CB.SelectedValue = index;
        }
    }
}
