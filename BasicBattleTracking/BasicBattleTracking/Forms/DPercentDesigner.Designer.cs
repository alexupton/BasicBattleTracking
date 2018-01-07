namespace BasicBattleTracking
{
    partial class DPercentDesigner
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
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LinePanel = new System.Windows.Forms.Panel();
            this.newLineButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.recalcButton = new System.Windows.Forms.Button();
            this.optionsBox = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancButton = new System.Windows.Forms.Button();
            this.LinePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(64, 12);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(262, 26);
            this.nameBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Min";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Max";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(361, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Effect";
            // 
            // LinePanel
            // 
            this.LinePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LinePanel.AutoScroll = true;
            this.LinePanel.Controls.Add(this.newLineButton);
            this.LinePanel.Location = new System.Drawing.Point(11, 106);
            this.LinePanel.Name = "LinePanel";
            this.LinePanel.Size = new System.Drawing.Size(730, 421);
            this.LinePanel.TabIndex = 7;
            this.LinePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.LinePanel_Paint);
            // 
            // newLineButton
            // 
            this.newLineButton.Location = new System.Drawing.Point(9, 103);
            this.newLineButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.newLineButton.Name = "newLineButton";
            this.newLineButton.Size = new System.Drawing.Size(118, 35);
            this.newLineButton.TabIndex = 48;
            this.newLineButton.Text = "New Line";
            this.newLineButton.UseVisualStyleBackColor = true;
            this.newLineButton.Click += new System.EventHandler(this.newLineButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(638, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Remove";
            // 
            // recalcButton
            // 
            this.recalcButton.Location = new System.Drawing.Point(181, 552);
            this.recalcButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.recalcButton.Name = "recalcButton";
            this.recalcButton.Size = new System.Drawing.Size(175, 35);
            this.recalcButton.TabIndex = 49;
            this.recalcButton.Text = "Recalculate Values";
            this.recalcButton.UseVisualStyleBackColor = true;
            this.recalcButton.Click += new System.EventHandler(this.recalcButton_Click);
            // 
            // optionsBox
            // 
            this.optionsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.optionsBox.FormattingEnabled = true;
            this.optionsBox.Items.AddRange(new object[] {
            "Standard (100-based)",
            "Use Current Max (100)"});
            this.optionsBox.Location = new System.Drawing.Point(365, 556);
            this.optionsBox.Name = "optionsBox";
            this.optionsBox.Size = new System.Drawing.Size(217, 28);
            this.optionsBox.TabIndex = 50;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(11, 552);
            this.okButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(125, 35);
            this.okButton.TabIndex = 51;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancButton
            // 
            this.cancButton.Location = new System.Drawing.Point(616, 552);
            this.cancButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancButton.Name = "cancButton";
            this.cancButton.Size = new System.Drawing.Size(125, 35);
            this.cancButton.TabIndex = 52;
            this.cancButton.Text = "Cancel";
            this.cancButton.UseVisualStyleBackColor = true;
            this.cancButton.Click += new System.EventHandler(this.cancButton_Click);
            // 
            // DPercentDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 613);
            this.Controls.Add(this.cancButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.optionsBox);
            this.Controls.Add(this.recalcButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LinePanel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label1);
            this.Name = "DPercentDesigner";
            this.Text = "New Table";
            this.Load += new System.EventHandler(this.DPercentDesigner_Load);
            this.LinePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel LinePanel;
        private System.Windows.Forms.Button newLineButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button recalcButton;
        private System.Windows.Forms.ComboBox optionsBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancButton;
    }
}