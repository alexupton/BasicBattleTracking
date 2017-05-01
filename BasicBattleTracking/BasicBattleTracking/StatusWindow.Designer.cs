namespace BasicBattleTracking
{
    partial class StatusWindow
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.targetBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.turnsBox = new System.Windows.Forms.TextBox();
            this.Duration = new System.Windows.Forms.Label();
            this.effectsBox = new System.Windows.Forms.TextBox();
            this.statusBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(340, 312);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 34);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 312);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Target";
            // 
            // targetBox
            // 
            this.targetBox.FormattingEnabled = true;
            this.targetBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.targetBox.Location = new System.Drawing.Point(96, 6);
            this.targetBox.Name = "targetBox";
            this.targetBox.Size = new System.Drawing.Size(178, 28);
            this.targetBox.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Effect (Optional)";
            // 
            // turnsBox
            // 
            this.turnsBox.Location = new System.Drawing.Point(96, 108);
            this.turnsBox.Name = "turnsBox";
            this.turnsBox.Size = new System.Drawing.Size(66, 26);
            this.turnsBox.TabIndex = 2;
            // 
            // Duration
            // 
            this.Duration.AutoSize = true;
            this.Duration.Location = new System.Drawing.Point(12, 114);
            this.Duration.Name = "Duration";
            this.Duration.Size = new System.Drawing.Size(70, 20);
            this.Duration.TabIndex = 14;
            this.Duration.Text = "Duration";
            // 
            // effectsBox
            // 
            this.effectsBox.Location = new System.Drawing.Point(84, 178);
            this.effectsBox.Multiline = true;
            this.effectsBox.Name = "effectsBox";
            this.effectsBox.Size = new System.Drawing.Size(280, 113);
            this.effectsBox.TabIndex = 3;
            // 
            // statusBox
            // 
            this.statusBox.FormattingEnabled = true;
            this.statusBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.statusBox.Location = new System.Drawing.Point(96, 60);
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(178, 28);
            this.statusBox.TabIndex = 1;
            this.statusBox.SelectedIndexChanged += new System.EventHandler(this.statusBox_SelectedIndexChanged);
            // 
            // StatusWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 398);
            this.Controls.Add(this.statusBox);
            this.Controls.Add(this.effectsBox);
            this.Controls.Add(this.Duration);
            this.Controls.Add(this.turnsBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.targetBox);
            this.Name = "StatusWindow";
            this.Text = "StatusWindow";
            this.Load += new System.EventHandler(this.StatusWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox targetBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox turnsBox;
        private System.Windows.Forms.Label Duration;
        private System.Windows.Forms.TextBox effectsBox;
        private System.Windows.Forms.ComboBox statusBox;
    }
}