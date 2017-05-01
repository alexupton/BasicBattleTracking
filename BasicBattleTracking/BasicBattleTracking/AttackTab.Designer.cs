namespace BasicBattleTracking
{
    partial class AttackTab
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
            this.deleteButton = new System.Windows.Forms.Button();
            this.CritMultBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CritMinBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.AttackCountBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.DamageAddBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DamageDMultBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DamageDTypeBox = new System.Windows.Forms.ComboBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(229, 5);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 32;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // CritMultBox
            // 
            this.CritMultBox.Location = new System.Drawing.Point(240, 106);
            this.CritMultBox.Margin = new System.Windows.Forms.Padding(2);
            this.CritMultBox.Name = "CritMultBox";
            this.CritMultBox.Size = new System.Drawing.Size(28, 20);
            this.CritMultBox.TabIndex = 31;
            this.CritMultBox.Text = "2";
            this.CritMultBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(158, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Crit. Multiplier   x";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(115, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "- 20";
            // 
            // CritMinBox
            // 
            this.CritMinBox.Location = new System.Drawing.Point(82, 106);
            this.CritMinBox.Margin = new System.Windows.Forms.Padding(2);
            this.CritMinBox.Name = "CritMinBox";
            this.CritMinBox.Size = new System.Drawing.Size(28, 20);
            this.CritMinBox.TabIndex = 28;
            this.CritMinBox.Text = "20";
            this.CritMinBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Crit Range";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.AttackCountBox);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(2, 143);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 241);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Attack Bonuses";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Number of Attacks";
            // 
            // AttackCountBox
            // 
            this.AttackCountBox.Location = new System.Drawing.Point(163, 13);
            this.AttackCountBox.Name = "AttackCountBox";
            this.AttackCountBox.Size = new System.Drawing.Size(23, 20);
            this.AttackCountBox.TabIndex = 9;
            this.AttackCountBox.Text = "1";
            this.AttackCountBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AttackCountBox.TextChanged += new System.EventHandler(this.AttackCountBox_TextChanged);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.textBox6);
            this.panel1.Location = new System.Drawing.Point(6, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 194);
            this.panel1.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Attack Bonus 1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(98, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(34, 20);
            this.textBox1.TabIndex = 13;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Attack Bonus 1";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(98, 11);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(34, 20);
            this.textBox6.TabIndex = 11;
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DamageAddBox
            // 
            this.DamageAddBox.Location = new System.Drawing.Point(197, 67);
            this.DamageAddBox.Margin = new System.Windows.Forms.Padding(2);
            this.DamageAddBox.Name = "DamageAddBox";
            this.DamageAddBox.Size = new System.Drawing.Size(42, 20);
            this.DamageAddBox.TabIndex = 25;
            this.DamageAddBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(179, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "+";
            // 
            // DamageDMultBox
            // 
            this.DamageDMultBox.Location = new System.Drawing.Point(67, 67);
            this.DamageDMultBox.Margin = new System.Windows.Forms.Padding(2);
            this.DamageDMultBox.Name = "DamageDMultBox";
            this.DamageDMultBox.Size = new System.Drawing.Size(29, 20);
            this.DamageDMultBox.TabIndex = 20;
            this.DamageDMultBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "x  d";
            // 
            // DamageDTypeBox
            // 
            this.DamageDTypeBox.FormattingEnabled = true;
            this.DamageDTypeBox.Items.AddRange(new object[] {
            "4",
            "6",
            "8",
            "10",
            "12"});
            this.DamageDTypeBox.Location = new System.Drawing.Point(128, 67);
            this.DamageDTypeBox.Name = "DamageDTypeBox";
            this.DamageDTypeBox.Size = new System.Drawing.Size(45, 21);
            this.DamageDTypeBox.TabIndex = 21;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(51, 21);
            this.nameBox.Margin = new System.Windows.Forms.Padding(2);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(107, 20);
            this.nameBox.TabIndex = 18;
            this.nameBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Damage";
            // 
            // AttackTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.CritMultBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CritMinBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DamageAddBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DamageDMultBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DamageDTypeBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label2);
            this.Name = "AttackTab";
            this.Size = new System.Drawing.Size(307, 387);
            this.Load += new System.EventHandler(this.AttackTab_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TextBox CritMultBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CritMinBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox AttackCountBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox DamageAddBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DamageDMultBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox DamageDTypeBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox1;
    }
}
