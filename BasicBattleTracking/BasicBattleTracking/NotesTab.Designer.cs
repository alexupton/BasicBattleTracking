﻿namespace BasicBattleTracking
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
            this.mainTextField.Location = new System.Drawing.Point(3, 43);
            this.mainTextField.Name = "mainTextField";
            this.mainTextField.Size = new System.Drawing.Size(942, 633);
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
            this.groupBox1.Location = new System.Drawing.Point(951, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 349);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Browser";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Recent Folders";
            // 
            // recentPathsBox
            // 
            this.recentPathsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.recentPathsBox.FormattingEnabled = true;
            this.recentPathsBox.Location = new System.Drawing.Point(290, 54);
            this.recentPathsBox.Name = "recentPathsBox";
            this.recentPathsBox.Size = new System.Drawing.Size(75, 21);
            this.recentPathsBox.TabIndex = 4;
            this.recentPathsBox.SelectedIndexChanged += new System.EventHandler(this.recentPathsBox_SelectedIndexChanged);
            // 
            // fileList
            // 
            this.fileList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.fileList.Location = new System.Drawing.Point(9, 57);
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(190, 286);
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
            this.fileBrowseButton.Location = new System.Drawing.Point(299, 8);
            this.fileBrowseButton.Name = "fileBrowseButton";
            this.fileBrowseButton.Size = new System.Drawing.Size(59, 23);
            this.fileBrowseButton.TabIndex = 2;
            this.fileBrowseButton.Text = "Browse...";
            this.fileBrowseButton.UseVisualStyleBackColor = true;
            this.fileBrowseButton.Click += new System.EventHandler(this.fileBrowseButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Directory";
            // 
            // filePathBox
            // 
            this.filePathBox.Location = new System.Drawing.Point(96, 11);
            this.filePathBox.Name = "filePathBox";
            this.filePathBox.Size = new System.Drawing.Size(188, 20);
            this.filePathBox.TabIndex = 0;
            this.filePathBox.TextChanged += new System.EventHandler(this.filePathBox_TextChanged);
            // 
            // titleBox
            // 
            this.titleBox.Location = new System.Drawing.Point(317, 17);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(323, 20);
            this.titleBox.TabIndex = 2;
            // 
            // newNoteButton
            // 
            this.newNoteButton.Location = new System.Drawing.Point(83, 681);
            this.newNoteButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.newNoteButton.Name = "newNoteButton";
            this.newNoteButton.Size = new System.Drawing.Size(79, 36);
            this.newNoteButton.TabIndex = 3;
            this.newNoteButton.Text = "New Note";
            this.newNoteButton.UseVisualStyleBackColor = true;
            this.newNoteButton.Click += new System.EventHandler(this.newNoteButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(24, 722);
            this.saveButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(99, 36);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save Note";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // saveAsButton
            // 
            this.saveAsButton.Location = new System.Drawing.Point(128, 722);
            this.saveAsButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(101, 36);
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
            this.laodNoteButton.Location = new System.Drawing.Point(262, 729);
            this.laodNoteButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.laodNoteButton.Name = "laodNoteButton";
            this.laodNoteButton.Size = new System.Drawing.Size(66, 23);
            this.laodNoteButton.TabIndex = 6;
            this.laodNoteButton.Text = "Load Note";
            this.laodNoteButton.UseVisualStyleBackColor = true;
            this.laodNoteButton.Click += new System.EventHandler(this.laodNoteButton_Click);
            // 
            // NotesTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.laodNoteButton);
            this.Controls.Add(this.saveAsButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.newNoteButton);
            this.Controls.Add(this.titleBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mainTextField);
            this.Name = "NotesTab";
            this.Size = new System.Drawing.Size(1422, 772);
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