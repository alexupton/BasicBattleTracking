namespace BasicBattleTracking
{
    partial class OptionScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionScreen));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.okButton = new System.Windows.Forms.Button();
            this.cancButton = new System.Windows.Forms.Button();
            this.statPathBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.autoPathBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.logPathBox = new System.Windows.Forms.TextBox();
            this.BrowseButton1 = new System.Windows.Forms.Button();
            this.browseButton2 = new System.Windows.Forms.Button();
            this.browseButton3 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(365, 337);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.browseButton3);
            this.tabPage1.Controls.Add(this.browseButton2);
            this.tabPage1.Controls.Add(this.BrowseButton1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.logPathBox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.autoPathBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.statPathBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(357, 311);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Directories";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(16, 397);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(102, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "Save Settings";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancButton
            // 
            this.cancButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancButton.Location = new System.Drawing.Point(298, 397);
            this.cancButton.Name = "cancButton";
            this.cancButton.Size = new System.Drawing.Size(75, 23);
            this.cancButton.TabIndex = 2;
            this.cancButton.Text = "Cancel";
            this.cancButton.UseVisualStyleBackColor = true;
            this.cancButton.Click += new System.EventHandler(this.cancButton_Click);
            // 
            // statPathBox
            // 
            this.statPathBox.Location = new System.Drawing.Point(89, 41);
            this.statPathBox.Name = "statPathBox";
            this.statPathBox.Size = new System.Drawing.Size(185, 20);
            this.statPathBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Stat Blocks";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Auto Save";
            // 
            // autoPathBox
            // 
            this.autoPathBox.Location = new System.Drawing.Point(89, 99);
            this.autoPathBox.Name = "autoPathBox";
            this.autoPathBox.Size = new System.Drawing.Size(185, 20);
            this.autoPathBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Log";
            // 
            // logPathBox
            // 
            this.logPathBox.Location = new System.Drawing.Point(89, 150);
            this.logPathBox.Name = "logPathBox";
            this.logPathBox.Size = new System.Drawing.Size(185, 20);
            this.logPathBox.TabIndex = 4;
            // 
            // BrowseButton1
            // 
            this.BrowseButton1.Location = new System.Drawing.Point(280, 38);
            this.BrowseButton1.Name = "BrowseButton1";
            this.BrowseButton1.Size = new System.Drawing.Size(59, 23);
            this.BrowseButton1.TabIndex = 6;
            this.BrowseButton1.Text = "Browse...";
            this.BrowseButton1.UseVisualStyleBackColor = true;
            this.BrowseButton1.Click += new System.EventHandler(this.BrowseButton1_Click);
            // 
            // browseButton2
            // 
            this.browseButton2.Location = new System.Drawing.Point(280, 97);
            this.browseButton2.Name = "browseButton2";
            this.browseButton2.Size = new System.Drawing.Size(59, 23);
            this.browseButton2.TabIndex = 7;
            this.browseButton2.Text = "Browse...";
            this.browseButton2.UseVisualStyleBackColor = true;
            this.browseButton2.Click += new System.EventHandler(this.browseButton2_Click);
            // 
            // browseButton3
            // 
            this.browseButton3.Location = new System.Drawing.Point(280, 148);
            this.browseButton3.Name = "browseButton3";
            this.browseButton3.Size = new System.Drawing.Size(59, 23);
            this.browseButton3.TabIndex = 8;
            this.browseButton3.Text = "Browse...";
            this.browseButton3.UseVisualStyleBackColor = true;
            this.browseButton3.Click += new System.EventHandler(this.browseButton3_Click);
            // 
            // OptionScreen
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancButton;
            this.ClientSize = new System.Drawing.Size(386, 432);
            this.Controls.Add(this.cancButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OptionScreen";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.OptionScreen_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox statPathBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox autoPathBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button browseButton3;
        private System.Windows.Forms.Button browseButton2;
        private System.Windows.Forms.Button BrowseButton1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox logPathBox;
    }
}