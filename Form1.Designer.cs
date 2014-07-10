namespace pk2pk
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.RB_I3 = new System.Windows.Forms.RadioButton();
            this.GB_InGen = new System.Windows.Forms.GroupBox();
            this.RB_I5 = new System.Windows.Forms.RadioButton();
            this.RB_I4 = new System.Windows.Forms.RadioButton();
            this.GB_OutGen = new System.Windows.Forms.GroupBox();
            this.RB_O6 = new System.Windows.Forms.RadioButton();
            this.RB_O5 = new System.Windows.Forms.RadioButton();
            this.RB_O4 = new System.Windows.Forms.RadioButton();
            this.GB_Settings = new System.Windows.Forms.GroupBox();
            this.B_Options = new System.Windows.Forms.Button();
            this.RB_PKM = new System.Windows.Forms.RadioButton();
            this.RB_PKN = new System.Windows.Forms.RadioButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.B_Clear = new System.Windows.Forms.Button();
            this.pBar1 = new System.Windows.Forms.ProgressBar();
            this.B_Help = new System.Windows.Forms.Button();
            this.B_Open = new System.Windows.Forms.Button();
            this.GB_InGen.SuspendLayout();
            this.GB_OutGen.SuspendLayout();
            this.GB_Settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // RB_I3
            // 
            this.RB_I3.AutoSize = true;
            this.RB_I3.Checked = true;
            this.RB_I3.Location = new System.Drawing.Point(18, 19);
            this.RB_I3.Name = "RB_I3";
            this.RB_I3.Size = new System.Drawing.Size(74, 17);
            this.RB_I3.TabIndex = 1;
            this.RB_I3.TabStop = true;
            this.RB_I3.Text = "Gen 3 / III";
            this.RB_I3.UseVisualStyleBackColor = true;
            this.RB_I3.Click += new System.EventHandler(this.changeIOSetting);
            // 
            // GB_InGen
            // 
            this.GB_InGen.Controls.Add(this.RB_I5);
            this.GB_InGen.Controls.Add(this.RB_I4);
            this.GB_InGen.Controls.Add(this.RB_I3);
            this.GB_InGen.Location = new System.Drawing.Point(12, 12);
            this.GB_InGen.Name = "GB_InGen";
            this.GB_InGen.Size = new System.Drawing.Size(110, 90);
            this.GB_InGen.TabIndex = 2;
            this.GB_InGen.TabStop = false;
            this.GB_InGen.Text = "Input Generation";
            // 
            // RB_I5
            // 
            this.RB_I5.AutoSize = true;
            this.RB_I5.Location = new System.Drawing.Point(18, 65);
            this.RB_I5.Name = "RB_I5";
            this.RB_I5.Size = new System.Drawing.Size(72, 17);
            this.RB_I5.TabIndex = 3;
            this.RB_I5.Text = "Gen 5 / V";
            this.RB_I5.UseVisualStyleBackColor = true;
            this.RB_I5.Click += new System.EventHandler(this.changeIOSetting);
            // 
            // RB_I4
            // 
            this.RB_I4.AutoSize = true;
            this.RB_I4.Location = new System.Drawing.Point(18, 42);
            this.RB_I4.Name = "RB_I4";
            this.RB_I4.Size = new System.Drawing.Size(75, 17);
            this.RB_I4.TabIndex = 2;
            this.RB_I4.Text = "Gen 4 / IV";
            this.RB_I4.UseVisualStyleBackColor = true;
            this.RB_I4.Click += new System.EventHandler(this.changeIOSetting);
            // 
            // GB_OutGen
            // 
            this.GB_OutGen.Controls.Add(this.RB_O6);
            this.GB_OutGen.Controls.Add(this.RB_O5);
            this.GB_OutGen.Controls.Add(this.RB_O4);
            this.GB_OutGen.Location = new System.Drawing.Point(128, 12);
            this.GB_OutGen.Name = "GB_OutGen";
            this.GB_OutGen.Size = new System.Drawing.Size(110, 90);
            this.GB_OutGen.TabIndex = 3;
            this.GB_OutGen.TabStop = false;
            this.GB_OutGen.Text = "Output Generation";
            // 
            // RB_O6
            // 
            this.RB_O6.AutoSize = true;
            this.RB_O6.Location = new System.Drawing.Point(18, 65);
            this.RB_O6.Name = "RB_O6";
            this.RB_O6.Size = new System.Drawing.Size(75, 17);
            this.RB_O6.TabIndex = 3;
            this.RB_O6.Text = "Gen 6 / VI";
            this.RB_O6.UseVisualStyleBackColor = true;
            this.RB_O6.Click += new System.EventHandler(this.changeIOSetting);
            // 
            // RB_O5
            // 
            this.RB_O5.AutoSize = true;
            this.RB_O5.Location = new System.Drawing.Point(18, 42);
            this.RB_O5.Name = "RB_O5";
            this.RB_O5.Size = new System.Drawing.Size(72, 17);
            this.RB_O5.TabIndex = 2;
            this.RB_O5.Text = "Gen 5 / V";
            this.RB_O5.UseVisualStyleBackColor = true;
            this.RB_O5.Click += new System.EventHandler(this.changeIOSetting);
            // 
            // RB_O4
            // 
            this.RB_O4.AutoSize = true;
            this.RB_O4.Checked = true;
            this.RB_O4.Location = new System.Drawing.Point(18, 19);
            this.RB_O4.Name = "RB_O4";
            this.RB_O4.Size = new System.Drawing.Size(75, 17);
            this.RB_O4.TabIndex = 1;
            this.RB_O4.TabStop = true;
            this.RB_O4.Text = "Gen 4 / IV";
            this.RB_O4.UseVisualStyleBackColor = true;
            this.RB_O4.Click += new System.EventHandler(this.changeIOSetting);
            // 
            // GB_Settings
            // 
            this.GB_Settings.Controls.Add(this.B_Options);
            this.GB_Settings.Controls.Add(this.RB_PKM);
            this.GB_Settings.Controls.Add(this.RB_PKN);
            this.GB_Settings.Location = new System.Drawing.Point(244, 12);
            this.GB_Settings.Name = "GB_Settings";
            this.GB_Settings.Size = new System.Drawing.Size(100, 65);
            this.GB_Settings.TabIndex = 6;
            this.GB_Settings.TabStop = false;
            this.GB_Settings.Text = "Output Settings";
            // 
            // B_Options
            // 
            this.B_Options.Location = new System.Drawing.Point(72, 28);
            this.B_Options.Name = "B_Options";
            this.B_Options.Size = new System.Drawing.Size(22, 22);
            this.B_Options.TabIndex = 11;
            this.B_Options.Text = "☀";
            this.B_Options.UseVisualStyleBackColor = true;
            this.B_Options.Visible = false;
            this.B_Options.Click += new System.EventHandler(this.B_Options_Click);
            // 
            // RB_PKM
            // 
            this.RB_PKM.AutoSize = true;
            this.RB_PKM.Location = new System.Drawing.Point(18, 42);
            this.RB_PKM.Name = "RB_PKM";
            this.RB_PKM.Size = new System.Drawing.Size(48, 17);
            this.RB_PKM.TabIndex = 2;
            this.RB_PKM.Text = "PKM";
            this.RB_PKM.UseVisualStyleBackColor = true;
            // 
            // RB_PKN
            // 
            this.RB_PKN.AutoSize = true;
            this.RB_PKN.Checked = true;
            this.RB_PKN.Location = new System.Drawing.Point(18, 19);
            this.RB_PKN.Name = "RB_PKN";
            this.RB_PKN.Size = new System.Drawing.Size(46, 17);
            this.RB_PKN.TabIndex = 1;
            this.RB_PKN.TabStop = true;
            this.RB_PKN.Text = "PK#";
            this.RB_PKN.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 108);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(332, 150);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            // 
            // B_Clear
            // 
            this.B_Clear.Location = new System.Drawing.Point(285, 80);
            this.B_Clear.Name = "B_Clear";
            this.B_Clear.Size = new System.Drawing.Size(40, 22);
            this.B_Clear.TabIndex = 8;
            this.B_Clear.Text = "Clear";
            this.B_Clear.UseVisualStyleBackColor = true;
            this.B_Clear.Click += new System.EventHandler(this.clear);
            // 
            // pBar1
            // 
            this.pBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pBar1.Location = new System.Drawing.Point(12, 260);
            this.pBar1.Name = "pBar1";
            this.pBar1.Size = new System.Drawing.Size(332, 10);
            this.pBar1.TabIndex = 9;
            // 
            // B_Help
            // 
            this.B_Help.Location = new System.Drawing.Point(324, 80);
            this.B_Help.Name = "B_Help";
            this.B_Help.Size = new System.Drawing.Size(20, 22);
            this.B_Help.TabIndex = 10;
            this.B_Help.Text = "?";
            this.B_Help.UseVisualStyleBackColor = true;
            this.B_Help.Click += new System.EventHandler(this.B_Help_Click);
            // 
            // B_Open
            // 
            this.B_Open.Location = new System.Drawing.Point(244, 80);
            this.B_Open.Name = "B_Open";
            this.B_Open.Size = new System.Drawing.Size(42, 22);
            this.B_Open.TabIndex = 11;
            this.B_Open.Text = "Open";
            this.B_Open.UseVisualStyleBackColor = true;
            this.B_Open.Click += new System.EventHandler(this.B_Open_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 272);
            this.Controls.Add(this.B_Open);
            this.Controls.Add(this.B_Help);
            this.Controls.Add(this.pBar1);
            this.Controls.Add(this.B_Clear);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.GB_Settings);
            this.Controls.Add(this.GB_OutGen);
            this.Controls.Add(this.GB_InGen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(370, 600);
            this.MinimumSize = new System.Drawing.Size(370, 300);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Time Capsule";
            this.GB_InGen.ResumeLayout(false);
            this.GB_InGen.PerformLayout();
            this.GB_OutGen.ResumeLayout(false);
            this.GB_OutGen.PerformLayout();
            this.GB_Settings.ResumeLayout(false);
            this.GB_Settings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton RB_I3;
        private System.Windows.Forms.GroupBox GB_InGen;
        private System.Windows.Forms.RadioButton RB_I5;
        private System.Windows.Forms.RadioButton RB_I4;
        private System.Windows.Forms.GroupBox GB_OutGen;
        private System.Windows.Forms.RadioButton RB_O6;
        private System.Windows.Forms.RadioButton RB_O5;
        private System.Windows.Forms.RadioButton RB_O4;
        private System.Windows.Forms.GroupBox GB_Settings;
        private System.Windows.Forms.RadioButton RB_PKM;
        private System.Windows.Forms.RadioButton RB_PKN;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button B_Clear;
        private System.Windows.Forms.ProgressBar pBar1;
        private System.Windows.Forms.Button B_Help;
        private System.Windows.Forms.Button B_Options;
        private System.Windows.Forms.Button B_Open;
    }
}

