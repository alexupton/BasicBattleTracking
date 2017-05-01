namespace BasicBattleTracking
{
    partial class AddFighterWindow
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
            this.InitBox = new System.Windows.Forms.TextBox();
            this.HPBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PCCheckBox = new System.Windows.Forms.CheckBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.cButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(135, 9);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(188, 26);
            this.nameBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Initiative Bonus";
            // 
            // InitBox
            // 
            this.InitBox.Location = new System.Drawing.Point(135, 45);
            this.InitBox.Name = "InitBox";
            this.InitBox.Size = new System.Drawing.Size(52, 26);
            this.InitBox.TabIndex = 3;
            this.InitBox.Text = "0";
            // 
            // HPBox
            // 
            this.HPBox.Location = new System.Drawing.Point(135, 77);
            this.HPBox.Name = "HPBox";
            this.HPBox.Size = new System.Drawing.Size(52, 26);
            this.HPBox.TabIndex = 4;
            this.HPBox.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "HP";
            // 
            // PCCheckBox
            // 
            this.PCCheckBox.AutoSize = true;
            this.PCCheckBox.Checked = true;
            this.PCCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PCCheckBox.Enabled = false;
            this.PCCheckBox.Location = new System.Drawing.Point(135, 140);
            this.PCCheckBox.Name = "PCCheckBox";
            this.PCCheckBox.Size = new System.Drawing.Size(125, 24);
            this.PCCheckBox.TabIndex = 6;
            this.PCCheckBox.Text = "Fighter is PC";
            this.PCCheckBox.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(82, 205);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(108, 35);
            this.OKButton.TabIndex = 7;
            this.OKButton.Text = "Create";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // cButton
            // 
            this.cButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cButton.Location = new System.Drawing.Point(254, 205);
            this.cButton.Name = "cButton";
            this.cButton.Size = new System.Drawing.Size(100, 35);
            this.cButton.TabIndex = 8;
            this.cButton.Text = "Cancel";
            this.cButton.UseVisualStyleBackColor = true;
            // 
            // AddFighterWindow
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 262);
            this.Controls.Add(this.cButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.PCCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.HPBox);
            this.Controls.Add(this.InitBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameBox);
            this.Name = "AddFighterWindow";
            this.Text = "AddFighterWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox InitBox;
        private System.Windows.Forms.TextBox HPBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox PCCheckBox;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button cButton;
    }
}