using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pk2pk
{
    public partial class G6Options : Form
    {
        Form1 m_parent;
        public G6Options(Form1 frm1)
        {
            InitializeComponent();
            m_parent = frm1;
            #region var tables

            var language_list = new[] {
                    new { Text = "ENG (English)", Value = 2 },
                    new { Text = "JPN (日本語)", Value = 1 },
                    new { Text = "FRE (Français)", Value = 3 },
                    new { Text = "ITA (Italiano)", Value = 4 },
                    new { Text = "GER (Deutsch)", Value = 5 },
                    new { Text = "ESP (Español)", Value = 7 },
                    new { Text = "KOR (한국어)", Value = 8 }
                };

            var dsregion_list = new[] {
                    new { Text = "Americas (NA/SA)", Value = 1 },
                    new { Text = "Europe (EU)", Value = 2 },
                    new { Text = "Japan (日本)", Value = 0 },
                    new { Text = "China (中国)", Value = 4 },
                    new { Text = "Korea (한국)", Value = 5 },
                    new { Text = "Taiwan (臺灣)", Value = 6 }
                };
            var subreg_list = new[] {
                    new { Text = "sr_0", Value = 0 },
                    new { Text = "sr_1", Value = 1 },
                    new { Text = "sr_2", Value = 2 },
                    new { Text = "sr_3", Value = 3 },
                    new { Text = "sr_4", Value = 4 },
                    new { Text = "sr_5", Value = 5 },
                    new { Text = "sr_6", Value = 6 },
                    new { Text = "sr_7", Value = 7 },
                    new { Text = "sr_8", Value = 8 },
                    new { Text = "sr_9", Value = 9 },
                    new { Text = "sr_10", Value = 10 },
                    new { Text = "sr_11", Value = 11 },
                    new { Text = "sr_12", Value = 12 },
                    new { Text = "sr_13", Value = 13 },
                    new { Text = "sr_14", Value = 14 },
                    new { Text = "sr_15", Value = 15 },
                    new { Text = "sr_16", Value = 16 },
                    new { Text = "sr_17", Value = 17 },
                    new { Text = "sr_18", Value = 18 },
                    new { Text = "sr_19", Value = 19 },
                    new { Text = "sr_20", Value = 20 },
                    new { Text = "sr_21", Value = 21 },
                    new { Text = "sr_22", Value = 22 },
                    new { Text = "sr_23", Value = 23 },
                    new { Text = "sr_24", Value = 24 },
                    new { Text = "sr_25", Value = 25 },
                    new { Text = "sr_26", Value = 26 },
                    new { Text = "sr_27", Value = 27 },
                    new { Text = "sr_28", Value = 28 },
                    new { Text = "sr_29", Value = 29 },
                    new { Text = "sr_30", Value = 30 },
                    new { Text = "sr_31", Value = 31 },
                    new { Text = "sr_32", Value = 32 },
                    new { Text = "sr_33", Value = 33 },
                    new { Text = "sr_34", Value = 34 },
                    new { Text = "sr_35", Value = 35 },
                    new { Text = "sr_36", Value = 36 },
                    new { Text = "sr_37", Value = 37 },
                    new { Text = "sr_38", Value = 38 },
                    new { Text = "sr_39", Value = 39 },
                    new { Text = "sr_40", Value = 40 },
                    new { Text = "sr_41", Value = 41 },
                    new { Text = "sr_42", Value = 42 },
                    new { Text = "sr_43", Value = 43 },
                    new { Text = "sr_44", Value = 44 },
                    new { Text = "sr_45", Value = 45 },
                    new { Text = "sr_46", Value = 46 },
                    new { Text = "sr_47", Value = 47 },
                    new { Text = "sr_48", Value = 48 },
                    new { Text = "sr_49", Value = 49 },
                    new { Text = "sr_50", Value = 50 },
                    new { Text = "sr_51", Value = 51 },
                    new { Text = "sr_52", Value = 52 },
                    new { Text = "sr_53", Value = 53 },
                    new { Text = "sr_54", Value = 54 },
                    new { Text = "sr_55", Value = 55 },
                    new { Text = "sr_56", Value = 56 },
                    new { Text = "sr_57", Value = 57 },
                    new { Text = "sr_58", Value = 58 },
                    new { Text = "sr_59", Value = 59 },
                    new { Text = "sr_60", Value = 60 },
                    new { Text = "sr_61", Value = 61 },
                    new { Text = "sr_62", Value = 62 },
                    new { Text = "sr_63", Value = 63 },
                    new { Text = "sr_64", Value = 64 },
                    new { Text = "sr_65", Value = 65 },
                    new { Text = "sr_66", Value = 66 },
                    new { Text = "sr_67", Value = 67 },
                    new { Text = "sr_68", Value = 68 },
                    new { Text = "sr_69", Value = 69 },
                    new { Text = "sr_70", Value = 70 },
                    new { Text = "sr_71", Value = 71 },
                    new { Text = "sr_72", Value = 72 },
                    new { Text = "sr_73", Value = 73 },
                    new { Text = "sr_74", Value = 74 },
                    new { Text = "sr_75", Value = 75 },
                    new { Text = "sr_76", Value = 76 },
                    new { Text = "sr_77", Value = 77 },
                    new { Text = "sr_78", Value = 78 },
                    new { Text = "sr_79", Value = 79 },
                    new { Text = "sr_80", Value = 80 },
                };
            #endregion

            // Set ComboBox Fields

            CB_3DSReg.DataSource = dsregion_list;
            CB_3DSReg.DisplayMember = "Text";
            CB_3DSReg.ValueMember = "Value";

            setcountry(CB_Country);

            CB_Region.DataSource = subreg_list;
            CB_Region.DisplayMember = "Text";
            CB_Region.ValueMember = "Value";

            CB_3DSReg.SelectedValue = m_parent._3DSreg;
            CB_Country.SelectedValue = m_parent.country;
            CB_Region.SelectedValue = m_parent.subreg;

            RB_F.Checked = Convert.ToBoolean(m_parent.g6trgend);
            TB_TR.Text = m_parent.g6trname;
        }
        public void setcountry(object sender)
        {
            #region country table
            var country_list = new[] {
                            new { Text = "---", Value = 0 },
                            new { Text = "Albania", Value = 64 },
                            new { Text = "Andorra", Value = 122 },
                            new { Text = "Anguilla", Value = 8 },
                            new { Text = "Antigua and Barbuda", Value = 9 },
                            new { Text = "Argentina", Value = 10 },
                            new { Text = "Aruba", Value = 11 },
                            new { Text = "Australia", Value = 65 },
                            new { Text = "Austria", Value = 66 },
                            new { Text = "Azerbaijan", Value = 113 },
                            new { Text = "Bahamas", Value = 12 },
                            new { Text = "Barbados", Value = 13 },
                            new { Text = "Belgium", Value = 67 },
                            new { Text = "Belize", Value = 14 },
                            new { Text = "Bermuda", Value = 186 },
                            new { Text = "Bolivia", Value = 15 },
                            new { Text = "Bosnia and Herzegovina", Value = 68 },
                            new { Text = "Botswana", Value = 69 },
                            new { Text = "Brazil", Value = 16 },
                            new { Text = "British Virgin Islands", Value = 17 },
                            new { Text = "Bulgaria", Value = 70 },
                            new { Text = "Canada", Value = 18 },
                            new { Text = "Cayman Islands", Value = 19 },
                            new { Text = "Chad", Value = 117 },
                            new { Text = "Chile", Value = 20 },
                            new { Text = "China", Value = 160 },
                            new { Text = "Colombia", Value = 21 },
                            new { Text = "Costa Rica", Value = 22 },
                            new { Text = "Croatia", Value = 71 },
                            new { Text = "Cyprus", Value = 72 },
                            new { Text = "Czech Republic", Value = 73 },
                            new { Text = "Denmark (Kingdom of)", Value = 74 },
                            new { Text = "Djibouti", Value = 120 },
                            new { Text = "Dominica", Value = 23 },
                            new { Text = "Dominican Republic", Value = 24 },
                            new { Text = "Ecuador", Value = 25 },
                            new { Text = "El Salvador", Value = 26 },
                            new { Text = "Eritrea", Value = 119 },
                            new { Text = "Estonia", Value = 75 },
                            new { Text = "Finland", Value = 76 },
                            new { Text = "France", Value = 77 },
                            new { Text = "French Guiana", Value = 27 },
                            new { Text = "Germany", Value = 78 },
                            new { Text = "Gibraltar", Value = 123 },
                            new { Text = "Greece", Value = 79 },
                            new { Text = "Grenada", Value = 28 },
                            new { Text = "Guadeloupe", Value = 29 },
                            new { Text = "Guatemala", Value = 30 },
                            new { Text = "Guernsey", Value = 124 },
                            new { Text = "Guyana", Value = 31 },
                            new { Text = "Haiti", Value = 32 },
                            new { Text = "Honduras", Value = 33 },
                            new { Text = "Hong Kong", Value = 144 },
                            new { Text = "Hungary", Value = 80 },
                            new { Text = "Iceland", Value = 81 },
                            new { Text = "India", Value = 169 },
                            new { Text = "Ireland", Value = 82 },
                            new { Text = "Isle of Man", Value = 125 },
                            new { Text = "Italy", Value = 83 },
                            new { Text = "Jamaica", Value = 34 },
                            new { Text = "Japan", Value = 1 },
                            new { Text = "Jersey", Value = 126 },
                            new { Text = "Latvia", Value = 84 },
                            new { Text = "Lesotho", Value = 85 },
                            new { Text = "Liechtenstein", Value = 86 },
                            new { Text = "Lithuania", Value = 87 },
                            new { Text = "Luxembourg", Value = 88 },
                            new { Text = "Macedonia (Republic of)", Value = 89 },
                            new { Text = "Malaysia", Value = 156 },
                            new { Text = "Mali", Value = 115 },
                            new { Text = "Malta", Value = 90 },
                            new { Text = "Martinique", Value = 35 },
                            new { Text = "Mauritania", Value = 114 },
                            new { Text = "Mexico", Value = 36 },
                            new { Text = "Monaco", Value = 127 },
                            new { Text = "Montenegro", Value = 91 },
                            new { Text = "Montserrat", Value = 37 },
                            new { Text = "Mozambique", Value = 92 },
                            new { Text = "Namibia", Value = 93 },
                            new { Text = "Netherlands", Value = 94 },
                            new { Text = "Netherlands Antilles", Value = 38 },
                            new { Text = "New Zealand", Value = 95 },
                            new { Text = "Nicaragua", Value = 39 },
                            new { Text = "Niger", Value = 116 },
                            new { Text = "Norway", Value = 96 },
                            new { Text = "Panama", Value = 40 },
                            new { Text = "Paraguay", Value = 41 },
                            new { Text = "Peru", Value = 42 },
                            new { Text = "Poland", Value = 97 },
                            new { Text = "Portugal", Value = 98 },
                            new { Text = "Romania", Value = 99 },
                            new { Text = "Russia", Value = 100 },
                            new { Text = "San Marino", Value = 184 },
                            new { Text = "Saudi Arabia", Value = 174 },
                            new { Text = "Serbia and Kosovo", Value = 101 },
                            new { Text = "Singapore", Value = 153 },
                            new { Text = "Slovakia", Value = 102 },
                            new { Text = "Slovenia", Value = 103 },
                            new { Text = "Somalia", Value = 121 },
                            new { Text = "South Africa", Value = 104 },
                            new { Text = "South Korea", Value = 136 },
                            new { Text = "Spain", Value = 105 },
                            new { Text = "St. Kitts and Nevis", Value = 43 },
                            new { Text = "St. Lucia", Value = 44 },
                            new { Text = "St. Vincent and the Grenadines", Value = 45 },
                            new { Text = "Sudan", Value = 118 },
                            new { Text = "Suriname", Value = 46 },
                            new { Text = "Swaziland", Value = 106 },
                            new { Text = "Sweden", Value = 107 },
                            new { Text = "Switzerland", Value = 108 },
                            new { Text = "Taiwan", Value = 128 },
                            new { Text = "Trinidad and Tobago", Value = 47 },
                            new { Text = "Turkey", Value = 109 },
                            new { Text = "Turks and Caicos Islands", Value = 48 },
                            new { Text = "U.A.E.", Value = 168 },
                            new { Text = "United Kingdom", Value = 110 },
                            new { Text = "United States", Value = 49 },
                            new { Text = "Uruguay", Value = 50 },
                            new { Text = "US Virgin Islands", Value = 51 },
                            new { Text = "Vatican City", Value = 185 },
                            new { Text = "Venezuela", Value = 52 },
                            new { Text = "Zambia", Value = 111 },
                            new { Text = "Zimbabwe", Value = 112 },
            };
            #endregion
            ComboBox CB = sender as ComboBox;
            CB.DataSource = country_list;
            CB.DisplayMember = "Text";
            CB.ValueMember = "Value";
        }

        private void B_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void B_Save_Click(object sender, EventArgs e)
        {
            m_parent.country = (int)CB_Country.SelectedValue;
            m_parent.subreg = (int)CB_Region.SelectedValue;
            m_parent._3DSreg = (int)CB_3DSReg.SelectedValue;
            m_parent.g6trgend = Convert.ToByte(RB_F.Checked);
            m_parent.g6trname = TB_TR.Text;
            if (TB_TR.Text.Length == 0)
                m_parent.g6trname = "PKHeX";
            else
                m_parent.g6trname = TB_TR.Text;

            this.Close();
        }
    }
}
