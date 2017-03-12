using System;
using System.Windows.Forms;
using PKHeX.Core;

namespace pk2pk
{
    public partial class Options : Form
    {
        public Options()
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

            loadFields();
        }
        private void loadFields()
        {
            CB_Country.SelectedValue = PKMConverter.Country;
            CB_SubRegion.SelectedValue = PKMConverter.Region;
            CB_3DSReg.SelectedValue = PKMConverter.ConsoleRegion;
            RB_F.Checked = PKMConverter.OT_Gender == 1;
            TB_TR.Text = PKMConverter.OT_Name;
        }
        private void saveFields()
        {
            PKMConverter.Country = (int)CB_Country.SelectedValue;
            PKMConverter.Region = (int)CB_SubRegion.SelectedValue;
            PKMConverter.ConsoleRegion = (int)CB_3DSReg.SelectedValue;
            PKMConverter.OT_Gender = Convert.ToByte(RB_F.Checked);
            PKMConverter.OT_Name = TB_TR.Text;
            PKMConverter.Language = 2;
        }
        private void B_Close_Click(object sender, EventArgs e) => Close();
        private void B_Save_Click(object sender, EventArgs e) 
        {
            saveFields();
            Close();
        }

        // Utility
        private static int getIndex(ListControl cb) => (int)(cb?.SelectedValue ?? 0);
        private static void setCountrySubRegion(ComboBox CB, string type)
        {
            int index = getIndex(CB);
            CB.DataSource = Util.getCBList(type, "countries");

            if (index > 0 && index < CB.Items.Count)
                CB.SelectedValue = index;
        }
        private void updateCountry(object sender, EventArgs e)
        {
            if (getIndex(sender as ComboBox) > 0)
                setCountrySubRegion(CB_SubRegion, "sr_" + getIndex(sender as ComboBox).ToString("000"));
        }
    }
}
