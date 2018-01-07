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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFighterWindow));
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.InitBox = new System.Windows.Forms.TextBox();
            this.HPBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PCCheckBox = new System.Windows.Forms.CheckBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.cButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dexBox = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(90, 6);
            this.nameBox.Margin = new System.Windows.Forms.Padding(2);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(127, 20);
            this.nameBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Initiative Bonus";
            // 
            // InitBox
            // 
            this.InitBox.Location = new System.Drawing.Point(90, 29);
            this.InitBox.Margin = new System.Windows.Forms.Padding(2);
            this.InitBox.Name = "InitBox";
            this.InitBox.Size = new System.Drawing.Size(36, 20);
            this.InitBox.TabIndex = 3;
            this.InitBox.Text = "0";
            // 
            // HPBox
            // 
            this.HPBox.Location = new System.Drawing.Point(90, 50);
            this.HPBox.Margin = new System.Windows.Forms.Padding(2);
            this.HPBox.Name = "HPBox";
            this.HPBox.Size = new System.Drawing.Size(36, 20);
            this.HPBox.TabIndex = 4;
            this.HPBox.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "HP";
            // 
            // PCCheckBox
            // 
            this.PCCheckBox.AutoSize = true;
            this.PCCheckBox.Checked = true;
            this.PCCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PCCheckBox.Enabled = false;
            this.PCCheckBox.Location = new System.Drawing.Point(90, 91);
            this.PCCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.PCCheckBox.Name = "PCCheckBox";
            this.PCCheckBox.Size = new System.Drawing.Size(85, 17);
            this.PCCheckBox.TabIndex = 6;
            this.PCCheckBox.Text = "Fighter is PC";
            this.PCCheckBox.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(55, 133);
            this.OKButton.Margin = new System.Windows.Forms.Padding(2);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(72, 23);
            this.OKButton.TabIndex = 7;
            this.OKButton.Text = "Create";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // cButton
            // 
            this.cButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cButton.Location = new System.Drawing.Point(169, 133);
            this.cButton.Margin = new System.Windows.Forms.Padding(2);
            this.cButton.Name = "cButton";
            this.cButton.Size = new System.Drawing.Size(67, 23);
            this.cButton.TabIndex = 8;
            this.cButton.Text = "Cancel";
            this.cButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(170, 53);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Dex";
            // 
            // dexBox
            // 
            this.dexBox.Location = new System.Drawing.Point(200, 50);
            this.dexBox.Margin = new System.Windows.Forms.Padding(2);
            this.dexBox.Name = "dexBox";
            this.dexBox.Size = new System.Drawing.Size(36, 20);
            this.dexBox.TabIndex = 9;
            this.dexBox.Text = "0";
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // AddFighterWindow
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cButton;
            this.ClientSize = new System.Drawing.Size(312, 170);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dexBox);
            this.Controls.Add(this.cButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.PCCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.HPBox);
            this.Controls.Add(this.InitBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddFighterWindow";
            this.Text = "Add Player Character";
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox dexBox;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}