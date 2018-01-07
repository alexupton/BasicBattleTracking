namespace BasicBattleTracking
{
    partial class SkillsTab
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
            this.rollBox = new System.Windows.Forms.TextBox();
            this.skillList = new System.Windows.Forms.ListView();
            this.Skill = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Modifier = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClassSkill = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.skillCheckButton = new System.Windows.Forms.Button();
            this.skillNameBox = new System.Windows.Forms.TextBox();
            this.classCheckBox = new System.Windows.Forms.CheckBox();
            this.abilityBonusBox = new System.Windows.Forms.TextBox();
            this.rankBonusBox = new System.Windows.Forms.TextBox();
            this.miscBonusBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.abilitySourceBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Misc = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.atkModBox = new System.Windows.Forms.Label();
            this.d20Label = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.rollResultLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rollBox
            // 
            this.rollBox.Location = new System.Drawing.Point(435, 163);
            this.rollBox.Margin = new System.Windows.Forms.Padding(2);
            this.rollBox.Multiline = true;
            this.rollBox.Name = "rollBox";
            this.rollBox.ReadOnly = true;
            this.rollBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.rollBox.Size = new System.Drawing.Size(237, 156);
            this.rollBox.TabIndex = 22;
            // 
            // skillList
            // 
            this.skillList.AutoArrange = false;
            this.skillList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Skill,
            this.Modifier,
            this.ClassSkill});
            this.skillList.FullRowSelect = true;
            this.skillList.Location = new System.Drawing.Point(29, 14);
            this.skillList.Margin = new System.Windows.Forms.Padding(2);
            this.skillList.MultiSelect = false;
            this.skillList.Name = "skillList";
            this.skillList.Size = new System.Drawing.Size(374, 260);
            this.skillList.TabIndex = 23;
            this.skillList.UseCompatibleStateImageBehavior = false;
            this.skillList.View = System.Windows.Forms.View.Details;
            this.skillList.SelectedIndexChanged += new System.EventHandler(this.skillList_SelectedIndexChanged);
            // 
            // Skill
            // 
            this.Skill.Text = "Skill";
            this.Skill.Width = 105;
            // 
            // Modifier
            // 
            this.Modifier.Text = "Modifier (Abilities, Ranks, Misc)";
            this.Modifier.Width = 178;
            // 
            // ClassSkill
            // 
            this.ClassSkill.Text = "Class Skill?";
            this.ClassSkill.Width = 75;
            // 
            // skillCheckButton
            // 
            this.skillCheckButton.Enabled = false;
            this.skillCheckButton.Location = new System.Drawing.Point(488, 20);
            this.skillCheckButton.Margin = new System.Windows.Forms.Padding(2);
            this.skillCheckButton.Name = "skillCheckButton";
            this.skillCheckButton.Size = new System.Drawing.Size(104, 36);
            this.skillCheckButton.TabIndex = 24;
            this.skillCheckButton.Text = "Roll Check";
            this.skillCheckButton.UseVisualStyleBackColor = true;
            this.skillCheckButton.Click += new System.EventHandler(this.skillCheckButton_Click);
            // 
            // skillNameBox
            // 
            this.skillNameBox.Location = new System.Drawing.Point(488, 61);
            this.skillNameBox.Name = "skillNameBox";
            this.skillNameBox.Size = new System.Drawing.Size(104, 20);
            this.skillNameBox.TabIndex = 25;
            this.skillNameBox.TextChanged += new System.EventHandler(this.skillNameBox_TextChanged);
            // 
            // classCheckBox
            // 
            this.classCheckBox.AutoSize = true;
            this.classCheckBox.Location = new System.Drawing.Point(488, 141);
            this.classCheckBox.Name = "classCheckBox";
            this.classCheckBox.Size = new System.Drawing.Size(73, 17);
            this.classCheckBox.TabIndex = 26;
            this.classCheckBox.Text = "Class Skill";
            this.classCheckBox.UseVisualStyleBackColor = true;
            this.classCheckBox.CheckedChanged += new System.EventHandler(this.classCheckBox_CheckedChanged);
            // 
            // abilityBonusBox
            // 
            this.abilityBonusBox.Location = new System.Drawing.Point(435, 118);
            this.abilityBonusBox.Name = "abilityBonusBox";
            this.abilityBonusBox.Size = new System.Drawing.Size(36, 20);
            this.abilityBonusBox.TabIndex = 27;
            this.abilityBonusBox.TextChanged += new System.EventHandler(this.abilityBonusBox_TextChanged);
            // 
            // rankBonusBox
            // 
            this.rankBonusBox.Location = new System.Drawing.Point(507, 118);
            this.rankBonusBox.Name = "rankBonusBox";
            this.rankBonusBox.Size = new System.Drawing.Size(36, 20);
            this.rankBonusBox.TabIndex = 28;
            this.rankBonusBox.TextChanged += new System.EventHandler(this.rankBonusBox_TextChanged);
            // 
            // miscBonusBox
            // 
            this.miscBonusBox.Location = new System.Drawing.Point(579, 118);
            this.miscBonusBox.Name = "miscBonusBox";
            this.miscBonusBox.Size = new System.Drawing.Size(36, 20);
            this.miscBonusBox.TabIndex = 29;
            this.miscBonusBox.TextChanged += new System.EventHandler(this.miscBonusBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(411, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Ability";
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
            this.abilitySourceBox.Location = new System.Drawing.Point(446, 91);
            this.abilitySourceBox.Name = "abilitySourceBox";
            this.abilitySourceBox.Size = new System.Drawing.Size(46, 21);
            this.abilitySourceBox.TabIndex = 31;
            this.abilitySourceBox.SelectedIndexChanged += new System.EventHandler(this.abilitySourceBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(505, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Ranks";
            // 
            // Misc
            // 
            this.Misc.AutoSize = true;
            this.Misc.Location = new System.Drawing.Point(580, 94);
            this.Misc.Name = "Misc";
            this.Misc.Size = new System.Drawing.Size(29, 13);
            this.Misc.TabIndex = 33;
            this.Misc.Text = "Misc";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(153, 276);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(65, 20);
            this.label39.TabIndex = 99;
            this.label39.Text = "Modifier";
            // 
            // atkModBox
            // 
            this.atkModBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.atkModBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.atkModBox.Location = new System.Drawing.Point(147, 296);
            this.atkModBox.Name = "atkModBox";
            this.atkModBox.Size = new System.Drawing.Size(82, 23);
            this.atkModBox.TabIndex = 100;
            this.atkModBox.Text = "0";
            this.atkModBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // d20Label
            // 
            this.d20Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d20Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d20Label.Location = new System.Drawing.Point(29, 296);
            this.d20Label.Name = "d20Label";
            this.d20Label.Size = new System.Drawing.Size(82, 23);
            this.d20Label.TabIndex = 98;
            this.d20Label.Text = "0";
            this.d20Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(49, 276);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 20);
            this.label13.TabIndex = 97;
            this.label13.Text = "D20";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(270, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 95;
            this.label3.Text = "Roll Result";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(244, 298);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(18, 20);
            this.label44.TabIndex = 102;
            this.label44.Text = "=";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(121, 297);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(18, 20);
            this.label42.TabIndex = 101;
            this.label42.Text = "+";
            // 
            // rollResultLabel
            // 
            this.rollResultLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rollResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rollResultLabel.Location = new System.Drawing.Point(276, 296);
            this.rollResultLabel.Name = "rollResultLabel";
            this.rollResultLabel.Size = new System.Drawing.Size(82, 23);
            this.rollResultLabel.TabIndex = 96;
            this.rollResultLabel.Text = "0";
            this.rollResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SkillsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label39);
            this.Controls.Add(this.atkModBox);
            this.Controls.Add(this.d20Label);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.rollResultLabel);
            this.Controls.Add(this.Misc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.abilitySourceBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.miscBonusBox);
            this.Controls.Add(this.rankBonusBox);
            this.Controls.Add(this.abilityBonusBox);
            this.Controls.Add(this.classCheckBox);
            this.Controls.Add(this.skillNameBox);
            this.Controls.Add(this.skillCheckButton);
            this.Controls.Add(this.skillList);
            this.Controls.Add(this.rollBox);
            this.Name = "SkillsTab";
            this.Size = new System.Drawing.Size(697, 340);
            this.Load += new System.EventHandler(this.SkillsTab_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox rollBox;
        private System.Windows.Forms.ListView skillList;
        private System.Windows.Forms.ColumnHeader Skill;
        private System.Windows.Forms.ColumnHeader Modifier;
        private System.Windows.Forms.ColumnHeader ClassSkill;
        private System.Windows.Forms.Button skillCheckButton;
        private System.Windows.Forms.TextBox skillNameBox;
        private System.Windows.Forms.CheckBox classCheckBox;
        private System.Windows.Forms.TextBox abilityBonusBox;
        private System.Windows.Forms.TextBox rankBonusBox;
        private System.Windows.Forms.TextBox miscBonusBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox abilitySourceBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Misc;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label atkModBox;
        private System.Windows.Forms.Label d20Label;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label rollResultLabel;
    }
}
