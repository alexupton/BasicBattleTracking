namespace BasicBattleTracking
{
    partial class FeatsTab
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
            this.skillList = new System.Windows.Forms.ListView();
            this.Feat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.descBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // skillList
            // 
            this.skillList.AutoArrange = false;
            this.skillList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Feat,
            this.Description});
            this.skillList.FullRowSelect = true;
            this.skillList.Location = new System.Drawing.Point(44, 22);
            this.skillList.MultiSelect = false;
            this.skillList.Name = "skillList";
            this.skillList.Size = new System.Drawing.Size(559, 398);
            this.skillList.TabIndex = 24;
            this.skillList.UseCompatibleStateImageBehavior = false;
            this.skillList.View = System.Windows.Forms.View.Details;
            // 
            // Feat
            // 
            this.Feat.Text = "Feat";
            this.Feat.Width = 105;
            // 
            // Description
            // 
            this.Description.Text = "Description";
            this.Description.Width = 450;
            // 
            // AddButton
            // 
            this.AddButton.Enabled = false;
            this.AddButton.Location = new System.Drawing.Point(44, 426);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(156, 55);
            this.AddButton.TabIndex = 25;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            // 
            // removeButton
            // 
            this.removeButton.Enabled = false;
            this.removeButton.Location = new System.Drawing.Point(447, 426);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(156, 55);
            this.removeButton.TabIndex = 26;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            // 
            // descBox
            // 
            this.descBox.Location = new System.Drawing.Point(652, 251);
            this.descBox.Multiline = true;
            this.descBox.Name = "descBox";
            this.descBox.ReadOnly = true;
            this.descBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descBox.Size = new System.Drawing.Size(354, 238);
            this.descBox.TabIndex = 27;
            // 
            // FeatsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.descBox);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.skillList);
            this.Name = "FeatsTab";
            this.Size = new System.Drawing.Size(1058, 563);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView skillList;
        private System.Windows.Forms.ColumnHeader Feat;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.TextBox descBox;
    }
}
