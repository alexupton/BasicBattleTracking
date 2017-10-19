namespace BasicBattleTracking
{
    partial class DPercentPanel
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.resultBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rollResultLabel = new System.Windows.Forms.Label();
            this.npcAttackButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.logBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tableList = new System.Windows.Forms.ComboBox();
            this.resultsView = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addFighterButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.addFighterButton);
            this.groupBox5.Controls.Add(this.resultBox);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.rollResultLabel);
            this.groupBox5.Controls.Add(this.npcAttackButton);
            this.groupBox5.Controls.Add(this.groupBox1);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.tableList);
            this.groupBox5.Controls.Add(this.resultsView);
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Size = new System.Drawing.Size(795, 649);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "d% Tables";
            this.groupBox5.Enter += new System.EventHandler(this.groupBox5_Enter);
            // 
            // resultBox
            // 
            this.resultBox.Location = new System.Drawing.Point(393, 266);
            this.resultBox.Multiline = true;
            this.resultBox.Name = "resultBox";
            this.resultBox.ReadOnly = true;
            this.resultBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultBox.Size = new System.Drawing.Size(389, 135);
            this.resultBox.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(507, 198);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 29);
            this.label2.TabIndex = 25;
            this.label2.Text = "Roll Result";
            // 
            // rollResultLabel
            // 
            this.rollResultLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rollResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rollResultLabel.Location = new System.Drawing.Point(516, 229);
            this.rollResultLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rollResultLabel.Name = "rollResultLabel";
            this.rollResultLabel.Size = new System.Drawing.Size(122, 34);
            this.rollResultLabel.TabIndex = 26;
            this.rollResultLabel.Text = "0";
            this.rollResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // npcAttackButton
            // 
            this.npcAttackButton.Location = new System.Drawing.Point(501, 127);
            this.npcAttackButton.Name = "npcAttackButton";
            this.npcAttackButton.Size = new System.Drawing.Size(156, 55);
            this.npcAttackButton.TabIndex = 24;
            this.npcAttackButton.Text = "Roll";
            this.npcAttackButton.UseVisualStyleBackColor = true;
            this.npcAttackButton.Click += new System.EventHandler(this.npcAttackButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.logBox);
            this.groupBox1.Location = new System.Drawing.Point(7, 423);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(781, 218);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log";
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(6, 25);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(769, 187);
            this.logBox.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(580, 34);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(115, 20);
            this.label14.TabIndex = 2;
            this.label14.Text = "Selected Table";
            // 
            // tableList
            // 
            this.tableList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tableList.FormattingEnabled = true;
            this.tableList.Location = new System.Drawing.Point(390, 29);
            this.tableList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableList.Name = "tableList";
            this.tableList.Size = new System.Drawing.Size(180, 28);
            this.tableList.TabIndex = 1;
            this.tableList.SelectedIndexChanged += new System.EventHandler(this.tableList_SelectedIndexChanged);
            // 
            // resultsView
            // 
            this.resultsView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.resultsView.Location = new System.Drawing.Point(4, 29);
            this.resultsView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.resultsView.Name = "resultsView";
            this.resultsView.Size = new System.Drawing.Size(378, 386);
            this.resultsView.TabIndex = 0;
            this.resultsView.UseCompatibleStateImageBehavior = false;
            this.resultsView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "d%";
            this.columnHeader5.Width = 45;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Result";
            this.columnHeader6.Width = 315;
            // 
            // addFighterButton
            // 
            this.addFighterButton.Location = new System.Drawing.Point(405, 76);
            this.addFighterButton.Name = "addFighterButton";
            this.addFighterButton.Size = new System.Drawing.Size(140, 32);
            this.addFighterButton.TabIndex = 28;
            this.addFighterButton.Text = "New Table";
            this.addFighterButton.UseVisualStyleBackColor = true;
            this.addFighterButton.Click += new System.EventHandler(this.addFighterButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(584, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 32);
            this.button1.TabIndex = 29;
            this.button1.Text = "Delete Table";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // DPercentPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.groupBox5);
            this.Name = "DPercentPanel";
            this.Size = new System.Drawing.Size(874, 654);
            this.Load += new System.EventHandler(this.DPercentPanel_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox tableList;
        private System.Windows.Forms.ListView resultsView;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.Button npcAttackButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label rollResultLabel;
        private System.Windows.Forms.TextBox resultBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button addFighterButton;

    }
}
