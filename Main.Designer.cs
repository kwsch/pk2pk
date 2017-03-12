namespace pk2pk
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.B_Options = new System.Windows.Forms.Button();
            this.RTB_Output = new System.Windows.Forms.RichTextBox();
            this.B_Clear = new System.Windows.Forms.Button();
            this.B_Help = new System.Windows.Forms.Button();
            this.B_Open = new System.Windows.Forms.Button();
            this.CB_PKMTypes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // B_Options
            // 
            this.B_Options.Location = new System.Drawing.Point(185, 26);
            this.B_Options.Name = "B_Options";
            this.B_Options.Size = new System.Drawing.Size(68, 22);
            this.B_Options.TabIndex = 11;
            this.B_Options.Text = "Options ☀";
            this.B_Options.UseVisualStyleBackColor = true;
            this.B_Options.Click += new System.EventHandler(this.B_Options_Click);
            // 
            // RTB_Output
            // 
            this.RTB_Output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTB_Output.Location = new System.Drawing.Point(12, 54);
            this.RTB_Output.Name = "RTB_Output";
            this.RTB_Output.ReadOnly = true;
            this.RTB_Output.Size = new System.Drawing.Size(332, 168);
            this.RTB_Output.TabIndex = 7;
            this.RTB_Output.Text = "";
            this.RTB_Output.WordWrap = false;
            // 
            // B_Clear
            // 
            this.B_Clear.Location = new System.Drawing.Point(257, 26);
            this.B_Clear.Name = "B_Clear";
            this.B_Clear.Size = new System.Drawing.Size(64, 22);
            this.B_Clear.TabIndex = 8;
            this.B_Clear.Text = "Clear Log";
            this.B_Clear.UseVisualStyleBackColor = true;
            this.B_Clear.Click += new System.EventHandler(this.ClearOutput);
            // 
            // B_Help
            // 
            this.B_Help.Location = new System.Drawing.Point(325, 26);
            this.B_Help.Name = "B_Help";
            this.B_Help.Size = new System.Drawing.Size(20, 22);
            this.B_Help.TabIndex = 10;
            this.B_Help.Text = "?";
            this.B_Help.UseVisualStyleBackColor = true;
            this.B_Help.Click += new System.EventHandler(this.B_Help_Click);
            // 
            // B_Open
            // 
            this.B_Open.Location = new System.Drawing.Point(139, 26);
            this.B_Open.Name = "B_Open";
            this.B_Open.Size = new System.Drawing.Size(42, 22);
            this.B_Open.TabIndex = 11;
            this.B_Open.Text = "Open";
            this.B_Open.UseVisualStyleBackColor = true;
            this.B_Open.Click += new System.EventHandler(this.B_Open_Click);
            // 
            // CB_PKMTypes
            // 
            this.CB_PKMTypes.FormattingEnabled = true;
            this.CB_PKMTypes.Location = new System.Drawing.Point(12, 27);
            this.CB_PKMTypes.Name = "CB_PKMTypes";
            this.CB_PKMTypes.Size = new System.Drawing.Size(121, 21);
            this.CB_PKMTypes.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Destination Format:";
            // 
            // Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 231);
            this.Controls.Add(this.B_Options);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CB_PKMTypes);
            this.Controls.Add(this.B_Open);
            this.Controls.Add(this.B_Help);
            this.Controls.Add(this.B_Clear);
            this.Controls.Add(this.RTB_Output);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimumSize = new System.Drawing.Size(370, 102);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Time Capsule";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox RTB_Output;
        private System.Windows.Forms.Button B_Clear;
        private System.Windows.Forms.Button B_Help;
        private System.Windows.Forms.Button B_Options;
        private System.Windows.Forms.Button B_Open;
        private System.Windows.Forms.ComboBox CB_PKMTypes;
        private System.Windows.Forms.Label label1;
    }
}

