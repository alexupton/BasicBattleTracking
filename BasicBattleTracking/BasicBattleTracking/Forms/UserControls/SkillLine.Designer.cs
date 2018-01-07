namespace BasicBattleTracking
{
    partial class SkillLine
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.xBox = new System.Windows.Forms.Button();
            this.miscBox = new System.Windows.Forms.TextBox();
            this.rankBox = new System.Windows.Forms.TextBox();
            this.abilityBonusBox = new System.Windows.Forms.TextBox();
            this.abilitySourceBox = new System.Windows.Forms.ComboBox();
            this.skillNameBox = new System.Windows.Forms.TextBox();
            this.totalBox = new System.Windows.Forms.TextBox();
            this.classSkillCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // xBox
            // 
            this.xBox.Location = new System.Drawing.Point(510, 1);
            this.xBox.Name = "xBox";
            this.xBox.Size = new System.Drawing.Size(25, 23);
            this.xBox.TabIndex = 42;
            this.xBox.Text = "X";
            this.xBox.UseVisualStyleBackColor = true;
            this.xBox.Click += new System.EventHandler(this.xBox_Click);
            // 
            // miscBox
            // 
            this.miscBox.Location = new System.Drawing.Point(397, 3);
            this.miscBox.Name = "miscBox";
            this.miscBox.Size = new System.Drawing.Size(36, 20);
            this.miscBox.TabIndex = 41;
            this.miscBox.TextChanged += new System.EventHandler(this.miscBox_TextChanged);
            // 
            // rankBox
            // 
            this.rankBox.Location = new System.Drawing.Point(350, 3);
            this.rankBox.Name = "rankBox";
            this.rankBox.Size = new System.Drawing.Size(36, 20);
            this.rankBox.TabIndex = 40;
            this.rankBox.TextChanged += new System.EventHandler(this.rankBox_TextChanged);
            // 
            // abilityBonusBox
            // 
            this.abilityBonusBox.Location = new System.Drawing.Point(294, 3);
            this.abilityBonusBox.Name = "abilityBonusBox";
            this.abilityBonusBox.Size = new System.Drawing.Size(36, 20);
            this.abilityBonusBox.TabIndex = 39;
            this.abilityBonusBox.TextChanged += new System.EventHandler(this.abilityBonusBox_TextChanged);
            // 
            // abilitySourceBox
            // 
            this.abilitySourceBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.abilitySourceBox.FormattingEnabled = true;
            this.abilitySourceBox.Items.AddRange(new object[] {
            "Str",
            "Dex",
            "Con",
            "Int",
            "Wis",
            "Cha"});
            this.abilitySourceBox.Location = new System.Drawing.Point(221, 3);
            this.abilitySourceBox.Name = "abilitySourceBox";
            this.abilitySourceBox.Size = new System.Drawing.Size(46, 21);
            this.abilitySourceBox.TabIndex = 38;
            this.abilitySourceBox.SelectedIndexChanged += new System.EventHandler(this.abilitySourceBox_SelectedIndexChanged);
            // 
            // skillNameBox
            // 
            this.skillNameBox.Location = new System.Drawing.Point(0, 3);
            this.skillNameBox.Name = "skillNameBox";
            this.skillNameBox.Size = new System.Drawing.Size(129, 20);
            this.skillNameBox.TabIndex = 37;
            // 
            // totalBox
            // 
            this.totalBox.Location = new System.Drawing.Point(155, 3);
            this.totalBox.Name = "totalBox";
            this.totalBox.ReadOnly = true;
            this.totalBox.Size = new System.Drawing.Size(36, 20);
            this.totalBox.TabIndex = 43;
            this.totalBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // classSkillCheckBox
            // 
            this.classSkillCheckBox.AutoSize = true;
            this.classSkillCheckBox.Location = new System.Drawing.Point(456, 6);
            this.classSkillCheckBox.Name = "classSkillCheckBox";
            this.classSkillCheckBox.Size = new System.Drawing.Size(15, 14);
            this.classSkillCheckBox.TabIndex = 44;
            this.classSkillCheckBox.UseVisualStyleBackColor = true;
            this.classSkillCheckBox.CheckedChanged += new System.EventHandler(this.classSkillCheckBox_CheckedChanged);
            // 
            // SkillLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.classSkillCheckBox);
            this.Controls.Add(this.totalBox);
            this.Controls.Add(this.xBox);
            this.Controls.Add(this.miscBox);
            this.Controls.Add(this.rankBox);
            this.Controls.Add(this.abilityBonusBox);
            this.Controls.Add(this.abilitySourceBox);
            this.Controls.Add(this.skillNameBox);
            this.Name = "SkillLine";
            this.Size = new System.Drawing.Size(540, 29);
            this.Load += new System.EventHandler(this.SkillLine_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button xBox;
        private System.Windows.Forms.TextBox miscBox;
        private System.Windows.Forms.TextBox rankBox;
        private System.Windows.Forms.TextBox abilityBonusBox;
        private System.Windows.Forms.ComboBox abilitySourceBox;
        private System.Windows.Forms.TextBox skillNameBox;
        private System.Windows.Forms.TextBox totalBox;
        private System.Windows.Forms.CheckBox classSkillCheckBox;
    }
}
