namespace BasicBattleTracking.Forms.UserControls
{
    partial class AttackControl
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
            this.label40 = new System.Windows.Forms.Label();
            this.AtkNameLabel = new System.Windows.Forms.Label();
            this.DmgDexBonusBox = new System.Windows.Forms.CheckBox();
            this.npcAttackButton = new System.Windows.Forms.Button();
            this.attackView = new System.Windows.Forms.ListView();
            this.Attack = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Modifier = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Damage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Count = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DmgStrBonusBox = new System.Windows.Forms.CheckBox();
            this.rollBox = new System.Windows.Forms.TextBox();
            this.rawDamageBox = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.rawDamageLabel = new System.Windows.Forms.Label();
            this.AtkDexBonusBox = new System.Windows.Forms.CheckBox();
            this.atkModBox = new System.Windows.Forms.Label();
            this.d20Label = new System.Windows.Forms.Label();
            this.AtkStrBonusBox = new System.Windows.Forms.CheckBox();
            this.dmgBonusLabel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.dmgBonusBox = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DamageLabel = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.rollResultLabel = new System.Windows.Forms.Label();
            this.damageResult = new System.Windows.Forms.Label();
            this.editButton = new System.Windows.Forms.Button();
            this.DmgButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(581, 73);
            this.label40.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(53, 13);
            this.label40.TabIndex = 130;
            this.label40.Text = "-Damage-";
            // 
            // AtkNameLabel
            // 
            this.AtkNameLabel.AutoSize = true;
            this.AtkNameLabel.Location = new System.Drawing.Point(127, 298);
            this.AtkNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AtkNameLabel.Name = "AtkNameLabel";
            this.AtkNameLabel.Size = new System.Drawing.Size(38, 13);
            this.AtkNameLabel.TabIndex = 117;
            this.AtkNameLabel.Text = "Attack";
            // 
            // DmgDexBonusBox
            // 
            this.DmgDexBonusBox.AutoSize = true;
            this.DmgDexBonusBox.Location = new System.Drawing.Point(562, 109);
            this.DmgDexBonusBox.Margin = new System.Windows.Forms.Padding(2);
            this.DmgDexBonusBox.Name = "DmgDexBonusBox";
            this.DmgDexBonusBox.Size = new System.Drawing.Size(91, 17);
            this.DmgDexBonusBox.TabIndex = 129;
            this.DmgDexBonusBox.Text = "Add Dex Mod";
            this.DmgDexBonusBox.UseVisualStyleBackColor = true;
            this.DmgDexBonusBox.CheckedChanged += new System.EventHandler(this.DmgDexBonusBox_CheckedChanged);
            // 
            // npcAttackButton
            // 
            this.npcAttackButton.Enabled = false;
            this.npcAttackButton.Location = new System.Drawing.Point(19, 286);
            this.npcAttackButton.Margin = new System.Windows.Forms.Padding(2);
            this.npcAttackButton.Name = "npcAttackButton";
            this.npcAttackButton.Size = new System.Drawing.Size(104, 36);
            this.npcAttackButton.TabIndex = 116;
            this.npcAttackButton.Text = "Roll Attack";
            this.npcAttackButton.UseVisualStyleBackColor = true;
            this.npcAttackButton.Click += new System.EventHandler(this.npcAttackButton_Click_1);
            // 
            // attackView
            // 
            this.attackView.AutoArrange = false;
            this.attackView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Attack,
            this.Modifier,
            this.Damage,
            this.Count});
            this.attackView.FullRowSelect = true;
            this.attackView.HideSelection = false;
            this.attackView.Location = new System.Drawing.Point(2, 8);
            this.attackView.Margin = new System.Windows.Forms.Padding(2);
            this.attackView.MultiSelect = false;
            this.attackView.Name = "attackView";
            this.attackView.Size = new System.Drawing.Size(426, 131);
            this.attackView.TabIndex = 115;
            this.attackView.UseCompatibleStateImageBehavior = false;
            this.attackView.View = System.Windows.Forms.View.Details;
            this.attackView.SelectedIndexChanged += new System.EventHandler(this.attackView_SelectedIndexChanged);
            // 
            // Attack
            // 
            this.Attack.Text = "Attack";
            this.Attack.Width = 84;
            // 
            // Modifier
            // 
            this.Modifier.Text = "Modifier";
            this.Modifier.Width = 87;
            // 
            // Damage
            // 
            this.Damage.Text = "Damage";
            this.Damage.Width = 122;
            // 
            // Count
            // 
            this.Count.Text = "Remaining";
            this.Count.Width = 126;
            // 
            // DmgStrBonusBox
            // 
            this.DmgStrBonusBox.AutoSize = true;
            this.DmgStrBonusBox.Location = new System.Drawing.Point(562, 89);
            this.DmgStrBonusBox.Margin = new System.Windows.Forms.Padding(2);
            this.DmgStrBonusBox.Name = "DmgStrBonusBox";
            this.DmgStrBonusBox.Size = new System.Drawing.Size(85, 17);
            this.DmgStrBonusBox.TabIndex = 128;
            this.DmgStrBonusBox.Text = "Add Str Mod";
            this.DmgStrBonusBox.UseVisualStyleBackColor = true;
            this.DmgStrBonusBox.CheckedChanged += new System.EventHandler(this.DmgStrBonusBox_CheckedChanged);
            // 
            // rollBox
            // 
            this.rollBox.Location = new System.Drawing.Point(432, 143);
            this.rollBox.Margin = new System.Windows.Forms.Padding(2);
            this.rollBox.Multiline = true;
            this.rollBox.Name = "rollBox";
            this.rollBox.ReadOnly = true;
            this.rollBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.rollBox.Size = new System.Drawing.Size(237, 156);
            this.rollBox.TabIndex = 114;
            // 
            // rawDamageBox
            // 
            this.rawDamageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rawDamageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rawDamageBox.Location = new System.Drawing.Point(19, 225);
            this.rawDamageBox.Name = "rawDamageBox";
            this.rawDamageBox.Size = new System.Drawing.Size(82, 23);
            this.rawDamageBox.TabIndex = 113;
            this.rawDamageBox.Text = "0";
            this.rawDamageBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(467, 73);
            this.label38.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(44, 13);
            this.label38.TabIndex = 127;
            this.label38.Text = "-Attack-";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(143, 145);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(65, 20);
            this.label39.TabIndex = 118;
            this.label39.Text = "Modifier";
            // 
            // rawDamageLabel
            // 
            this.rawDamageLabel.AutoSize = true;
            this.rawDamageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rawDamageLabel.Location = new System.Drawing.Point(16, 203);
            this.rawDamageLabel.Name = "rawDamageLabel";
            this.rawDamageLabel.Size = new System.Drawing.Size(92, 17);
            this.rawDamageLabel.TabIndex = 112;
            this.rawDamageLabel.Text = "Raw Damage";
            // 
            // AtkDexBonusBox
            // 
            this.AtkDexBonusBox.AutoSize = true;
            this.AtkDexBonusBox.Location = new System.Drawing.Point(446, 109);
            this.AtkDexBonusBox.Margin = new System.Windows.Forms.Padding(2);
            this.AtkDexBonusBox.Name = "AtkDexBonusBox";
            this.AtkDexBonusBox.Size = new System.Drawing.Size(91, 17);
            this.AtkDexBonusBox.TabIndex = 126;
            this.AtkDexBonusBox.Text = "Add Dex Mod";
            this.AtkDexBonusBox.UseVisualStyleBackColor = true;
            this.AtkDexBonusBox.CheckedChanged += new System.EventHandler(this.AtkDexBonusBox_CheckedChanged);
            // 
            // atkModBox
            // 
            this.atkModBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.atkModBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.atkModBox.Location = new System.Drawing.Point(137, 165);
            this.atkModBox.Name = "atkModBox";
            this.atkModBox.Size = new System.Drawing.Size(82, 23);
            this.atkModBox.TabIndex = 119;
            this.atkModBox.Text = "0";
            this.atkModBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // d20Label
            // 
            this.d20Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.d20Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d20Label.Location = new System.Drawing.Point(19, 165);
            this.d20Label.Name = "d20Label";
            this.d20Label.Size = new System.Drawing.Size(82, 23);
            this.d20Label.TabIndex = 111;
            this.d20Label.Text = "0";
            this.d20Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AtkStrBonusBox
            // 
            this.AtkStrBonusBox.AutoSize = true;
            this.AtkStrBonusBox.Location = new System.Drawing.Point(446, 89);
            this.AtkStrBonusBox.Margin = new System.Windows.Forms.Padding(2);
            this.AtkStrBonusBox.Name = "AtkStrBonusBox";
            this.AtkStrBonusBox.Size = new System.Drawing.Size(85, 17);
            this.AtkStrBonusBox.TabIndex = 125;
            this.AtkStrBonusBox.Text = "Add Str Mod";
            this.AtkStrBonusBox.UseVisualStyleBackColor = true;
            this.AtkStrBonusBox.CheckedChanged += new System.EventHandler(this.AtkStrBonusBox_CheckedChanged);
            // 
            // dmgBonusLabel
            // 
            this.dmgBonusLabel.AutoSize = true;
            this.dmgBonusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dmgBonusLabel.Location = new System.Drawing.Point(149, 203);
            this.dmgBonusLabel.Name = "dmgBonusLabel";
            this.dmgBonusLabel.Size = new System.Drawing.Size(48, 17);
            this.dmgBonusLabel.TabIndex = 120;
            this.dmgBonusLabel.Text = "Bonus";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(39, 145);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 20);
            this.label13.TabIndex = 110;
            this.label13.Text = "D20";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(230, 225);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(18, 20);
            this.label45.TabIndex = 124;
            this.label45.Text = "=";
            // 
            // dmgBonusBox
            // 
            this.dmgBonusBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dmgBonusBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dmgBonusBox.Location = new System.Drawing.Point(133, 225);
            this.dmgBonusBox.Name = "dmgBonusBox";
            this.dmgBonusBox.Size = new System.Drawing.Size(82, 23);
            this.dmgBonusBox.TabIndex = 121;
            this.dmgBonusBox.Text = "0";
            this.dmgBonusBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(260, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 106;
            this.label2.Text = "Roll Result";
            // 
            // DamageLabel
            // 
            this.DamageLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DamageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DamageLabel.Location = new System.Drawing.Point(264, 225);
            this.DamageLabel.Name = "DamageLabel";
            this.DamageLabel.Size = new System.Drawing.Size(82, 23);
            this.DamageLabel.TabIndex = 109;
            this.DamageLabel.Text = "0";
            this.DamageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(234, 167);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(18, 20);
            this.label44.TabIndex = 123;
            this.label44.Text = "=";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(111, 166);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(18, 20);
            this.label42.TabIndex = 122;
            this.label42.Text = "+";
            // 
            // rollResultLabel
            // 
            this.rollResultLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rollResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rollResultLabel.Location = new System.Drawing.Point(266, 165);
            this.rollResultLabel.Name = "rollResultLabel";
            this.rollResultLabel.Size = new System.Drawing.Size(82, 23);
            this.rollResultLabel.TabIndex = 107;
            this.rollResultLabel.Text = "0";
            this.rollResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // damageResult
            // 
            this.damageResult.AutoSize = true;
            this.damageResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.damageResult.Location = new System.Drawing.Point(270, 201);
            this.damageResult.Name = "damageResult";
            this.damageResult.Size = new System.Drawing.Size(70, 20);
            this.damageResult.TabIndex = 108;
            this.damageResult.Text = "Damage";
            // 
            // editButton
            // 
            this.editButton.Enabled = false;
            this.editButton.Location = new System.Drawing.Point(497, 8);
            this.editButton.Margin = new System.Windows.Forms.Padding(2);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(104, 36);
            this.editButton.TabIndex = 131;
            this.editButton.Text = "Edit Attacks";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // DmgButton
            // 
            this.DmgButton.Location = new System.Drawing.Point(253, 286);
            this.DmgButton.Margin = new System.Windows.Forms.Padding(2);
            this.DmgButton.Name = "DmgButton";
            this.DmgButton.Size = new System.Drawing.Size(104, 36);
            this.DmgButton.TabIndex = 132;
            this.DmgButton.Text = "Take Damage";
            this.DmgButton.UseVisualStyleBackColor = true;
            this.DmgButton.Click += new System.EventHandler(this.DmgButton_Click);
            // 
            // AttackControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DmgButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.AtkNameLabel);
            this.Controls.Add(this.DmgDexBonusBox);
            this.Controls.Add(this.npcAttackButton);
            this.Controls.Add(this.attackView);
            this.Controls.Add(this.DmgStrBonusBox);
            this.Controls.Add(this.rollBox);
            this.Controls.Add(this.rawDamageBox);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.rawDamageLabel);
            this.Controls.Add(this.AtkDexBonusBox);
            this.Controls.Add(this.atkModBox);
            this.Controls.Add(this.d20Label);
            this.Controls.Add(this.AtkStrBonusBox);
            this.Controls.Add(this.dmgBonusLabel);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.dmgBonusBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DamageLabel);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.rollResultLabel);
            this.Controls.Add(this.damageResult);
            this.Name = "AttackControl";
            this.Size = new System.Drawing.Size(675, 338);
            this.Load += new System.EventHandler(this.AttackControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label AtkNameLabel;
        private System.Windows.Forms.CheckBox DmgDexBonusBox;
        private System.Windows.Forms.Button npcAttackButton;
        private System.Windows.Forms.ListView attackView;
        private System.Windows.Forms.ColumnHeader Attack;
        private System.Windows.Forms.ColumnHeader Modifier;
        private System.Windows.Forms.ColumnHeader Damage;
        private System.Windows.Forms.ColumnHeader Count;
        private System.Windows.Forms.CheckBox DmgStrBonusBox;
        private System.Windows.Forms.TextBox rollBox;
        private System.Windows.Forms.Label rawDamageBox;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label rawDamageLabel;
        private System.Windows.Forms.CheckBox AtkDexBonusBox;
        private System.Windows.Forms.Label atkModBox;
        private System.Windows.Forms.Label d20Label;
        private System.Windows.Forms.CheckBox AtkStrBonusBox;
        private System.Windows.Forms.Label dmgBonusLabel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label dmgBonusBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label DamageLabel;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label rollResultLabel;
        private System.Windows.Forms.Label damageResult;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button DmgButton;
    }
}
