namespace BasicBattleTracking
{
    partial class AttackForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttackForm));
            this.targetBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DamageBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.drCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.drBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.totalBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // targetBox
            // 
            this.targetBox.FormattingEnabled = true;
            this.targetBox.Location = new System.Drawing.Point(10, 36);
            this.targetBox.Margin = new System.Windows.Forms.Padding(2);
            this.targetBox.Name = "targetBox";
            this.targetBox.Size = new System.Drawing.Size(82, 21);
            this.targetBox.TabIndex = 0;
            this.targetBox.SelectedIndexChanged += new System.EventHandler(this.targetBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Target";
            // 
            // DamageBox
            // 
            this.DamageBox.Location = new System.Drawing.Point(109, 37);
            this.DamageBox.Margin = new System.Windows.Forms.Padding(2);
            this.DamageBox.Name = "DamageBox";
            this.DamageBox.Size = new System.Drawing.Size(68, 20);
            this.DamageBox.TabIndex = 2;
            this.DamageBox.TextChanged += new System.EventHandler(this.DamageBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Damage";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 130);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 22);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(203, 130);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 22);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // drCheckBox
            // 
            this.drCheckBox.AutoSize = true;
            this.drCheckBox.Location = new System.Drawing.Point(187, 38);
            this.drCheckBox.Name = "drCheckBox";
            this.drCheckBox.Size = new System.Drawing.Size(71, 17);
            this.drCheckBox.TabIndex = 6;
            this.drCheckBox.Text = "Apply DR";
            this.drCheckBox.UseVisualStyleBackColor = true;
            this.drCheckBox.CheckedChanged += new System.EventHandler(this.drCheckBox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Damage Reduction";
            // 
            // drBox
            // 
            this.drBox.Location = new System.Drawing.Point(128, 93);
            this.drBox.Margin = new System.Windows.Forms.Padding(2);
            this.drBox.Name = "drBox";
            this.drBox.Size = new System.Drawing.Size(50, 20);
            this.drBox.TabIndex = 7;
            this.drBox.TextChanged += new System.EventHandler(this.drBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(275, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Total";
            // 
            // totalBox
            // 
            this.totalBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalBox.Location = new System.Drawing.Point(263, 37);
            this.totalBox.Margin = new System.Windows.Forms.Padding(2);
            this.totalBox.Name = "totalBox";
            this.totalBox.ReadOnly = true;
            this.totalBox.Size = new System.Drawing.Size(68, 20);
            this.totalBox.TabIndex = 9;
            this.totalBox.Text = "0";
            this.totalBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AttackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 172);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.totalBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.drBox);
            this.Controls.Add(this.drCheckBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DamageBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.targetBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AttackForm";
            this.Text = "AttackForm";
            this.Load += new System.EventHandler(this.AttackForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox targetBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DamageBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox drCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox drBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox totalBox;
    }
}