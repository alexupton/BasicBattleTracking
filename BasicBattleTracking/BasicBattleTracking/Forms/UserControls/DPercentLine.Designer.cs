namespace BasicBattleTracking
{
    partial class DPercentLine
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
            this.effectBox = new System.Windows.Forms.TextBox();
            this.maxBox = new System.Windows.Forms.TextBox();
            this.minBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // xBox
            // 
            this.xBox.Location = new System.Drawing.Point(633, 3);
            this.xBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xBox.Name = "xBox";
            this.xBox.Size = new System.Drawing.Size(38, 35);
            this.xBox.TabIndex = 51;
            this.xBox.Text = "X";
            this.xBox.UseVisualStyleBackColor = true;
            this.xBox.Click += new System.EventHandler(this.xBox_Click);
            // 
            // effectBox
            // 
            this.effectBox.Location = new System.Drawing.Point(167, 7);
            this.effectBox.Name = "effectBox";
            this.effectBox.Size = new System.Drawing.Size(440, 26);
            this.effectBox.TabIndex = 50;
            this.effectBox.TextChanged += new System.EventHandler(this.effectBox_TextChanged);
            // 
            // maxBox
            // 
            this.maxBox.Location = new System.Drawing.Point(76, 7);
            this.maxBox.Name = "maxBox";
            this.maxBox.Size = new System.Drawing.Size(47, 26);
            this.maxBox.TabIndex = 49;
            this.maxBox.TextChanged += new System.EventHandler(this.maxBox_TextChanged);
            // 
            // minBox
            // 
            this.minBox.Location = new System.Drawing.Point(1, 7);
            this.minBox.Name = "minBox";
            this.minBox.Size = new System.Drawing.Size(47, 26);
            this.minBox.TabIndex = 48;
            // 
            // DPercentLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.xBox);
            this.Controls.Add(this.effectBox);
            this.Controls.Add(this.maxBox);
            this.Controls.Add(this.minBox);
            this.Name = "DPercentLine";
            this.Size = new System.Drawing.Size(675, 43);
            this.Load += new System.EventHandler(this.DPercentLine_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button xBox;
        private System.Windows.Forms.TextBox effectBox;
        private System.Windows.Forms.TextBox maxBox;
        private System.Windows.Forms.TextBox minBox;
    }
}
