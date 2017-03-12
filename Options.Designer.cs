using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace pk2pk
{
    partial class Options
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.B_Save = new Button();
            this.B_Cancel = new Button();
            this.CB_Country = new ComboBox();
            this.CB_SubRegion = new ComboBox();
            this.CB_3DSReg = new ComboBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.RB_M = new RadioButton();
            this.RB_F = new RadioButton();
            this.TB_TR = new TextBox();
            this.label4 = new Label();
            this.SuspendLayout();
            // 
            // B_Save
            // 
            this.B_Save.Location = new Point(95, 133);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new Size(75, 23);
            this.B_Save.TabIndex = 0;
            this.B_Save.Text = "Save";
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new EventHandler(this.B_Save_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.Location = new Point(14, 133);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new Size(75, 23);
            this.B_Cancel.TabIndex = 1;
            this.B_Cancel.Text = "Cancel";
            this.B_Cancel.UseVisualStyleBackColor = true;
            this.B_Cancel.Click += new EventHandler(this.B_Close_Click);
            // 
            // CB_Country
            // 
            this.CB_Country.FormattingEnabled = true;
            this.CB_Country.Location = new Point(52, 12);
            this.CB_Country.Name = "CB_Country";
            this.CB_Country.Size = new Size(121, 21);
            this.CB_Country.TabIndex = 2;
            this.CB_Country.SelectedIndexChanged += new EventHandler(this.updateCountry);
            // 
            // CB_SubRegion
            // 
            this.CB_SubRegion.FormattingEnabled = true;
            this.CB_SubRegion.Location = new Point(52, 39);
            this.CB_SubRegion.Name = "CB_SubRegion";
            this.CB_SubRegion.Size = new Size(121, 21);
            this.CB_SubRegion.TabIndex = 3;
            // 
            // CB_3DSReg
            // 
            this.CB_3DSReg.DropDownStyle = ComboBoxStyle.DropDownList;
            this.CB_3DSReg.FormattingEnabled = true;
            this.CB_3DSReg.Location = new Point(52, 66);
            this.CB_3DSReg.Name = "CB_3DSReg";
            this.CB_3DSReg.Size = new Size(121, 21);
            this.CB_3DSReg.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new Size(46, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Country:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(8, 42);
            this.label2.Name = "label2";
            this.label2.Size = new Size(44, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Region:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new Point(1, 69);
            this.label3.Name = "label3";
            this.label3.Size = new Size(51, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "3DSReg:";
            // 
            // RB_M
            // 
            this.RB_M.AutoSize = true;
            this.RB_M.Checked = true;
            this.RB_M.Location = new Point(133, 98);
            this.RB_M.Name = "RB_M";
            this.RB_M.Size = new Size(33, 17);
            this.RB_M.TabIndex = 8;
            this.RB_M.TabStop = true;
            this.RB_M.Text = "♂";
            this.RB_M.UseVisualStyleBackColor = true;
            // 
            // RB_F
            // 
            this.RB_F.AutoSize = true;
            this.RB_F.Location = new Point(133, 113);
            this.RB_F.Name = "RB_F";
            this.RB_F.Size = new Size(31, 17);
            this.RB_F.TabIndex = 9;
            this.RB_F.Text = "♀";
            this.RB_F.UseVisualStyleBackColor = true;
            // 
            // TB_TR
            // 
            this.TB_TR.Location = new Point(14, 105);
            this.TB_TR.MaxLength = 12;
            this.TB_TR.Name = "TB_TR";
            this.TB_TR.Size = new Size(110, 20);
            this.TB_TR.TabIndex = 10;
            this.TB_TR.Text = "PKHeX";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new Point(6, 89);
            this.label4.Name = "label4";
            this.label4.Size = new Size(125, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Receiving Trainer Name:";
            // 
            // G6Options
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(184, 166);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TB_TR);
            this.Controls.Add(this.RB_F);
            this.Controls.Add(this.RB_M);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CB_3DSReg);
            this.Controls.Add(this.CB_SubRegion);
            this.Controls.Add(this.CB_Country);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_Save);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Name = "G6Options";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Transfer Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button B_Save;
        private Button B_Cancel;
        private ComboBox CB_Country;
        private ComboBox CB_SubRegion;
        private ComboBox CB_3DSReg;
        private Label label1;
        private Label label2;
        private Label label3;
        private RadioButton RB_M;
        private RadioButton RB_F;
        private TextBox TB_TR;
        private Label label4;
    }
}