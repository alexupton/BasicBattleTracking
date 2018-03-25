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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionScreen));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.sessionBrowseBox = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.sessionBox = new System.Windows.Forms.TextBox();
            this.browseButton4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.notesPathBox = new System.Windows.Forms.TextBox();
            this.browseButton3 = new System.Windows.Forms.Button();
            this.browseButton2 = new System.Windows.Forms.Button();
            this.BrowseButton1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.logPathBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.autoPathBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statPathBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.critConfirmBox = new System.Windows.Forms.CheckBox();
            this.initOptionBox = new System.Windows.Forms.CheckBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancButton = new System.Windows.Forms.Button();
            this.brianBox = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(18, 18);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(548, 518);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.sessionBrowseBox);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.sessionBox);
            this.tabPage1.Controls.Add(this.browseButton4);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.notesPathBox);
            this.tabPage1.Controls.Add(this.browseButton3);
            this.tabPage1.Controls.Add(this.browseButton2);
            this.tabPage1.Controls.Add(this.BrowseButton1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.logPathBox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.autoPathBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.statPathBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(540, 485);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Directories";
            // 
            // sessionBrowseBox
            // 
            this.sessionBrowseBox.Location = new System.Drawing.Point(420, 342);
            this.sessionBrowseBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sessionBrowseBox.Name = "sessionBrowseBox";
            this.sessionBrowseBox.Size = new System.Drawing.Size(88, 35);
            this.sessionBrowseBox.TabIndex = 14;
            this.sessionBrowseBox.Text = "Browse...";
            this.sessionBrowseBox.UseVisualStyleBackColor = true;
            this.sessionBrowseBox.Click += new System.EventHandler(this.sessionBrowseBox_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 349);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Sessions";
            // 
            // sessionBox
            // 
            this.sessionBox.Location = new System.Drawing.Point(134, 345);
            this.sessionBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sessionBox.Name = "sessionBox";
            this.sessionBox.Size = new System.Drawing.Size(276, 26);
            this.sessionBox.TabIndex = 12;
            // 
            // browseButton4
            // 
            this.browseButton4.Location = new System.Drawing.Point(420, 277);
            this.browseButton4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.browseButton4.Name = "browseButton4";
            this.browseButton4.Size = new System.Drawing.Size(88, 35);
            this.browseButton4.TabIndex = 11;
            this.browseButton4.Text = "Browse...";
            this.browseButton4.UseVisualStyleBackColor = true;
            this.browseButton4.Click += new System.EventHandler(this.browseButton4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 285);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Notes";
            // 
            // notesPathBox
            // 
            this.notesPathBox.Location = new System.Drawing.Point(134, 280);
            this.notesPathBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.notesPathBox.Name = "notesPathBox";
            this.notesPathBox.Size = new System.Drawing.Size(276, 26);
            this.notesPathBox.TabIndex = 9;
            // 
            // browseButton3
            // 
            this.browseButton3.Location = new System.Drawing.Point(420, 209);
            this.browseButton3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.browseButton3.Name = "browseButton3";
            this.browseButton3.Size = new System.Drawing.Size(88, 35);
            this.browseButton3.TabIndex = 8;
            this.browseButton3.Text = "Browse...";
            this.browseButton3.UseVisualStyleBackColor = true;
            this.browseButton3.Click += new System.EventHandler(this.browseButton3_Click);
            // 
            // browseButton2
            // 
            this.browseButton2.Location = new System.Drawing.Point(420, 131);
            this.browseButton2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.browseButton2.Name = "browseButton2";
            this.browseButton2.Size = new System.Drawing.Size(88, 35);
            this.browseButton2.TabIndex = 7;
            this.browseButton2.Text = "Browse...";
            this.browseButton2.UseVisualStyleBackColor = true;
            this.browseButton2.Click += new System.EventHandler(this.browseButton2_Click);
            // 
            // BrowseButton1
            // 
            this.BrowseButton1.Location = new System.Drawing.Point(420, 58);
            this.BrowseButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BrowseButton1.Name = "BrowseButton1";
            this.BrowseButton1.Size = new System.Drawing.Size(88, 35);
            this.BrowseButton1.TabIndex = 6;
            this.BrowseButton1.Text = "Browse...";
            this.BrowseButton1.UseVisualStyleBackColor = true;
            this.BrowseButton1.Click += new System.EventHandler(this.BrowseButton1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 217);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Log";
            // 
            // logPathBox
            // 
            this.logPathBox.Location = new System.Drawing.Point(134, 212);
            this.logPathBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.logPathBox.Name = "logPathBox";
            this.logPathBox.Size = new System.Drawing.Size(276, 26);
            this.logPathBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 138);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Auto Save";
            // 
            // autoPathBox
            // 
            this.autoPathBox.Location = new System.Drawing.Point(134, 134);
            this.autoPathBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.autoPathBox.Name = "autoPathBox";
            this.autoPathBox.Size = new System.Drawing.Size(276, 26);
            this.autoPathBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Stat Blocks";
            // 
            // statPathBox
            // 
            this.statPathBox.Location = new System.Drawing.Point(134, 63);
            this.statPathBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.statPathBox.Name = "statPathBox";
            this.statPathBox.Size = new System.Drawing.Size(276, 26);
            this.statPathBox.TabIndex = 0;
            this.statPathBox.TextChanged += new System.EventHandler(this.statPathBox_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.brianBox);
            this.tabPage2.Controls.Add(this.critConfirmBox);
            this.tabPage2.Controls.Add(this.initOptionBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(540, 485);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Options";
            // 
            // critConfirmBox
            // 
            this.critConfirmBox.AutoSize = true;
            this.critConfirmBox.Checked = true;
            this.critConfirmBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.critConfirmBox.Location = new System.Drawing.Point(23, 80);
            this.critConfirmBox.Name = "critConfirmBox";
            this.critConfirmBox.Size = new System.Drawing.Size(271, 24);
            this.critConfirmBox.TabIndex = 1;
            this.critConfirmBox.Text = "Automatically Confirm Critical Hits";
            this.critConfirmBox.UseVisualStyleBackColor = true;
            // 
            // initOptionBox
            // 
            this.initOptionBox.AutoSize = true;
            this.initOptionBox.Checked = true;
            this.initOptionBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.initOptionBox.Location = new System.Drawing.Point(23, 50);
            this.initOptionBox.Name = "initOptionBox";
            this.initOptionBox.Size = new System.Drawing.Size(208, 24);
            this.initOptionBox.TabIndex = 0;
            this.initOptionBox.Text = "Roll initiative every round";
            this.initOptionBox.UseVisualStyleBackColor = true;
            this.initOptionBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(24, 611);
            this.okButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(153, 35);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "Save Settings";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancButton
            // 
            this.cancButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancButton.Location = new System.Drawing.Point(447, 611);
            this.cancButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancButton.Name = "cancButton";
            this.cancButton.Size = new System.Drawing.Size(112, 35);
            this.cancButton.TabIndex = 2;
            this.cancButton.Text = "Cancel";
            this.cancButton.UseVisualStyleBackColor = true;
            this.cancButton.Click += new System.EventHandler(this.cancButton_Click);
            // 
            // brianBox
            // 
            this.brianBox.AutoSize = true;
            this.brianBox.Checked = true;
            this.brianBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.brianBox.Location = new System.Drawing.Point(23, 157);
            this.brianBox.Name = "brianBox";
            this.brianBox.Size = new System.Drawing.Size(116, 24);
            this.brianBox.TabIndex = 2;
            this.brianBox.Text = "Brian Mode";
            this.brianBox.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // OptionScreen
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancButton;
            this.ClientSize = new System.Drawing.Size(579, 665);
            this.Controls.Add(this.cancButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "OptionScreen";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.OptionScreen_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
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
        private System.Windows.Forms.Button browseButton4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox notesPathBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox initOptionBox;
        private System.Windows.Forms.CheckBox critConfirmBox;
        private System.Windows.Forms.Button sessionBrowseBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox sessionBox;
        private System.Windows.Forms.CheckBox brianBox;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}