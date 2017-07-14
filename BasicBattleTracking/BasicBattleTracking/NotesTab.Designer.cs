namespace BasicBattleTracking
{
    partial class NotesTab
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("An Item");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Another Item");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("A Third Item");
            this.mainTextField = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.recentPathsBox = new System.Windows.Forms.ComboBox();
            this.fileList = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.fileBrowseButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.filePathBox = new System.Windows.Forms.TextBox();
            this.titleBox = new System.Windows.Forms.TextBox();
            this.newNoteButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.saveAsButton = new System.Windows.Forms.Button();
            this.openNoteDialog = new System.Windows.Forms.OpenFileDialog();
            this.laodNoteButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTextField
            // 
            this.mainTextField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainTextField.Location = new System.Drawing.Point(4, 66);
            this.mainTextField.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mainTextField.Name = "mainTextField";
            this.mainTextField.Size = new System.Drawing.Size(1411, 1116);
            this.mainTextField.TabIndex = 0;
            this.mainTextField.Text = "";
            this.mainTextField.TextChanged += new System.EventHandler(this.mainTextField_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.recentPathsBox);
            this.groupBox1.Controls.Add(this.fileList);
            this.groupBox1.Controls.Add(this.fileBrowseButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.filePathBox);
            this.groupBox1.Location = new System.Drawing.Point(1426, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(693, 537);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Browser";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(375, 140);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.Location = new System.Drawing.Point(250, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Recent Folders";
            // 
            // recentPathsBox
            // 
            this.recentPathsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.recentPathsBox.FormattingEnabled = true;
            this.recentPathsBox.Location = new System.Drawing.Point(502, 135);
            this.recentPathsBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.recentPathsBox.Name = "recentPathsBox";
            this.recentPathsBox.Size = new System.Drawing.Size(164, 28);
            this.recentPathsBox.Location = new System.Drawing.Point(335, 88);
            this.recentPathsBox.Name = "recentPathsBox";
            this.recentPathsBox.Size = new System.Drawing.Size(111, 21);

            this.recentPathsBox.TabIndex = 4;
            this.recentPathsBox.SelectedIndexChanged += new System.EventHandler(this.recentPathsBox_SelectedIndexChanged);
            // 
            // fileList
            // 
            this.fileList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.fileList.Location = new System.Drawing.Point(14, 88);
            this.fileList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(328, 438);
            this.fileList.SmallImageList = this.imageList1;
            this.fileList.TabIndex = 3;
            this.fileList.UseCompatibleStateImageBehavior = false;
            this.fileList.View = System.Windows.Forms.View.SmallIcon;
            this.fileList.SelectedIndexChanged += new System.EventHandler(this.fileList_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // fileBrowseButton
            // 
            this.fileBrowseButton.Location = new System.Drawing.Point(572, 26);
            this.fileBrowseButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fileBrowseButton.Name = "fileBrowseButton";
            this.fileBrowseButton.Size = new System.Drawing.Size(98, 35);

            this.fileBrowseButton.Location = new System.Drawing.Point(381, 17);
            this.fileBrowseButton.Name = "fileBrowseButton";
            this.fileBrowseButton.Size = new System.Drawing.Size(65, 23);
            this.fileBrowseButton.TabIndex = 2;
            this.fileBrowseButton.Text = "Browse...";
            this.fileBrowseButton.UseVisualStyleBackColor = true;
            this.fileBrowseButton.Click += new System.EventHandler(this.fileBrowseButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Directory";
            // 
            // filePathBox
            // 
            this.filePathBox.Location = new System.Drawing.Point(147, 29);
            this.filePathBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.filePathBox.Name = "filePathBox";
            this.filePathBox.Size = new System.Drawing.Size(418, 26);

            this.filePathBox.Location = new System.Drawing.Point(98, 19);
            this.filePathBox.Name = "filePathBox";
            this.filePathBox.Size = new System.Drawing.Size(280, 20);

            this.filePathBox.TabIndex = 0;
            this.filePathBox.TextChanged += new System.EventHandler(this.filePathBox_TextChanged);
            // 
            // titleBox
            // 
            this.titleBox.Location = new System.Drawing.Point(476, 26);
            this.titleBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(482, 26);
            this.titleBox.TabIndex = 2;
            // 
            // newNoteButton
            // 
            this.newNoteButton.Location = new System.Drawing.Point(161, 1190);
            this.newNoteButton.Name = "newNoteButton";
            this.newNoteButton.Size = new System.Drawing.Size(118, 55);
            this.newNoteButton.TabIndex = 3;
            this.newNoteButton.Text = "New Note";
            this.newNoteButton.UseVisualStyleBackColor = true;
            this.newNoteButton.Click += new System.EventHandler(this.newNoteButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(74, 1252);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(148, 55);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save Note";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // saveAsButton
            // 
            this.saveAsButton.Location = new System.Drawing.Point(229, 1252);
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(152, 55);
            this.saveAsButton.TabIndex = 5;
            this.saveAsButton.Text = "Save Note As...";
            this.saveAsButton.UseVisualStyleBackColor = true;
            this.saveAsButton.Click += new System.EventHandler(this.saveAsButton_Click);
            // 
            // openNoteDialog
            // 
            this.openNoteDialog.FileName = "openFileDialog1";
            this.openNoteDialog.Filter = "Text Files (*.txt) | *.txt";
            // 
            // laodNoteButton
            // 
            this.laodNoteButton.Location = new System.Drawing.Point(278, 848);
            this.laodNoteButton.Margin = new System.Windows.Forms.Padding(2);
            this.laodNoteButton.Name = "laodNoteButton";
            this.laodNoteButton.Size = new System.Drawing.Size(99, 36);
            this.laodNoteButton.TabIndex = 6;
            this.laodNoteButton.Text = "Load Note";
            this.laodNoteButton.UseVisualStyleBackColor = true;
            this.laodNoteButton.Click += new System.EventHandler(this.laodNoteButton_Click);
            // 
            // NotesTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.laodNoteButton);
            this.Controls.Add(this.saveAsButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.newNoteButton);
            this.Controls.Add(this.titleBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mainTextField);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "NotesTab";
            this.Size = new System.Drawing.Size(1900, 1200);
            this.Load += new System.EventHandler(this.NotesTab_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox mainTextField;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button fileBrowseButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox filePathBox;
        private System.Windows.Forms.ListView fileList;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox recentPathsBox;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.Button newNoteButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button saveAsButton;
        private System.Windows.Forms.OpenFileDialog openNoteDialog;
        private System.Windows.Forms.Button laodNoteButton;
    }
}
