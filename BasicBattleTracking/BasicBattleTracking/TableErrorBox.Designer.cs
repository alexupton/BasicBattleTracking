namespace BasicBattleTracking
{
    partial class TableErrorBox
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
            this.label1 = new System.Windows.Forms.Label();
            this.recalcButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.addBlankButton = new System.Windows.Forms.Button();
            this.cancButton = new System.Windows.Forms.Button();
            this.gapsBox = new System.Windows.Forms.TextBox();
            this.recalcTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(410, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "The following values are unaccounted for in the d% table:";
            // 
            // recalcButton
            // 
            this.recalcButton.Location = new System.Drawing.Point(12, 302);
            this.recalcButton.Name = "recalcButton";
            this.recalcButton.Size = new System.Drawing.Size(156, 36);
            this.recalcButton.TabIndex = 1;
            this.recalcButton.Text = "Recalculate Values";
            this.recalcButton.UseVisualStyleBackColor = true;
            this.recalcButton.Click += new System.EventHandler(this.recalcButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Choose an option to proceed:";
            // 
            // addBlankButton
            // 
            this.addBlankButton.Location = new System.Drawing.Point(174, 302);
            this.addBlankButton.Name = "addBlankButton";
            this.addBlankButton.Size = new System.Drawing.Size(156, 36);
            this.addBlankButton.TabIndex = 3;
            this.addBlankButton.Text = "Add Blank Results";
            this.addBlankButton.UseVisualStyleBackColor = true;
            // 
            // cancButton
            // 
            this.cancButton.Location = new System.Drawing.Point(336, 302);
            this.cancButton.Name = "cancButton";
            this.cancButton.Size = new System.Drawing.Size(156, 36);
            this.cancButton.TabIndex = 4;
            this.cancButton.Text = "Cancel";
            this.cancButton.UseVisualStyleBackColor = true;
            this.cancButton.Click += new System.EventHandler(this.cancButton_Click);
            // 
            // gapsBox
            // 
            this.gapsBox.Location = new System.Drawing.Point(16, 32);
            this.gapsBox.Multiline = true;
            this.gapsBox.Name = "gapsBox";
            this.gapsBox.ReadOnly = true;
            this.gapsBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.gapsBox.Size = new System.Drawing.Size(454, 232);
            this.gapsBox.TabIndex = 5;
            // 
            // TableErrorBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 365);
            this.Controls.Add(this.gapsBox);
            this.Controls.Add(this.cancButton);
            this.Controls.Add(this.addBlankButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.recalcButton);
            this.Controls.Add(this.label1);
            this.Name = "TableErrorBox";
            this.Text = "Error";
            this.Load += new System.EventHandler(this.TableErrorBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button recalcButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addBlankButton;
        private System.Windows.Forms.Button cancButton;
        private System.Windows.Forms.TextBox gapsBox;
        private System.Windows.Forms.ToolTip recalcTip;
    }
}