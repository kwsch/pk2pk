namespace pk2pk
{
    partial class G6Options
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.B_Save = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.CB_Country = new System.Windows.Forms.ComboBox();
            this.CB_SubRegion = new System.Windows.Forms.ComboBox();
            this.CB_3DSReg = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RB_M = new System.Windows.Forms.RadioButton();
            this.RB_F = new System.Windows.Forms.RadioButton();
            this.TB_TR = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // B_Save
            // 
            this.B_Save.Location = new System.Drawing.Point(95, 133);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(75, 23);
            this.B_Save.TabIndex = 0;
            this.B_Save.Text = "Save";
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.Location = new System.Drawing.Point(14, 133);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(75, 23);
            this.B_Cancel.TabIndex = 1;
            this.B_Cancel.Text = "Cancel";
            this.B_Cancel.UseVisualStyleBackColor = true;
            this.B_Cancel.Click += new System.EventHandler(this.B_Close_Click);
            // 
            // CB_Country
            // 
            this.CB_Country.FormattingEnabled = true;
            this.CB_Country.Location = new System.Drawing.Point(52, 12);
            this.CB_Country.Name = "CB_Country";
            this.CB_Country.Size = new System.Drawing.Size(121, 21);
            this.CB_Country.TabIndex = 2;
            this.CB_Country.SelectedIndexChanged += new System.EventHandler(this.updateCountry);
            // 
            // CB_SubRegion
            // 
            this.CB_SubRegion.FormattingEnabled = true;
            this.CB_SubRegion.Location = new System.Drawing.Point(52, 39);
            this.CB_SubRegion.Name = "CB_SubRegion";
            this.CB_SubRegion.Size = new System.Drawing.Size(121, 21);
            this.CB_SubRegion.TabIndex = 3;
            // 
            // CB_3DSReg
            // 
            this.CB_3DSReg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_3DSReg.FormattingEnabled = true;
            this.CB_3DSReg.Location = new System.Drawing.Point(52, 66);
            this.CB_3DSReg.Name = "CB_3DSReg";
            this.CB_3DSReg.Size = new System.Drawing.Size(121, 21);
            this.CB_3DSReg.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Country:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Region:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "3DSReg:";
            // 
            // RB_M
            // 
            this.RB_M.AutoSize = true;
            this.RB_M.Checked = true;
            this.RB_M.Location = new System.Drawing.Point(133, 98);
            this.RB_M.Name = "RB_M";
            this.RB_M.Size = new System.Drawing.Size(33, 17);
            this.RB_M.TabIndex = 8;
            this.RB_M.TabStop = true;
            this.RB_M.Text = "♂";
            this.RB_M.UseVisualStyleBackColor = true;
            // 
            // RB_F
            // 
            this.RB_F.AutoSize = true;
            this.RB_F.Location = new System.Drawing.Point(133, 113);
            this.RB_F.Name = "RB_F";
            this.RB_F.Size = new System.Drawing.Size(31, 17);
            this.RB_F.TabIndex = 9;
            this.RB_F.Text = "♀";
            this.RB_F.UseVisualStyleBackColor = true;
            // 
            // TB_TR
            // 
            this.TB_TR.Location = new System.Drawing.Point(14, 105);
            this.TB_TR.MaxLength = 12;
            this.TB_TR.Name = "TB_TR";
            this.TB_TR.Size = new System.Drawing.Size(110, 20);
            this.TB_TR.TabIndex = 10;
            this.TB_TR.Text = "PKHeX";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Receiving Trainer Name:";
            // 
            // G6Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 166);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "G6Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Transfer Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.ComboBox CB_Country;
        private System.Windows.Forms.ComboBox CB_SubRegion;
        private System.Windows.Forms.ComboBox CB_3DSReg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton RB_M;
        private System.Windows.Forms.RadioButton RB_F;
        private System.Windows.Forms.TextBox TB_TR;
        private System.Windows.Forms.Label label4;
    }
}