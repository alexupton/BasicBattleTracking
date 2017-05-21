using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using GemBox.Document;
namespace BasicBattleTracking
{
    public partial class NotesTab : UserControl
    {
        private string filePath;
        private List<string> recentPaths;
        bool pathUpdatePending;
        private List<string> notes;
        bool isDirty = false;

        private string currentNote;
        public NotesTab()
        {
            InitializeComponent();
            recentPaths = new List<string>();
            pathUpdatePending = false;
            filePath = Program.defaultPath + @"\Notes";
            notes = new List<string>();
            fileList.Items.Clear();
            mainTextField.DetectUrls = true;


            filePathBox.LostFocus += filePathBox_LostFocus;
            mainTextField.LinkClicked += mainTextField_LinkClicked;

        }

        void mainTextField_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void NotesTab_Load(object sender, EventArgs e)
        {
            
            if(Program.UserNotesDirectory != "")
            {
                filePath = Program.UserNotesDirectory;
            }
            else
            {
                filePath = Program.defaultPath + @"\Notes";
            }

            


                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }


            filePathBox.Text = filePath;
            UpdatePathList(filePath);
        }

        private void LoadFiles(string path)
        {
            notes.Clear();
            if(Directory.Exists(path))
            {
                fileList.Items.Clear();
                filePathBox.Text = path;
                string[] files = Directory.GetFiles(path);
                foreach(string file in files)
                {
                    if (file.Split('.').Length > 1)
                    {
                        if (file.Split('.')[1] == "txt")
                        {
                            fileList.Items.Add(Path.GetFileName(file));
                            string load = File.ReadAllText(file);

                            notes.Add(load);

                        }
                    }
                }
            }
            
        }

        private void filePathBox_TextChanged(object sender, EventArgs e)
        {
            string candidatePath = filePathBox.Text;
            if(Directory.Exists(candidatePath))
            {
                filePath = candidatePath;
                pathUpdatePending = true;
            }
            else
            {
                pathUpdatePending = false;
            }
        }

        private void UpdatePathList(string newPath)
        {
            if(recentPaths.Count >= 10)
            {
                recentPaths.RemoveAt(0);
                recentPathsBox.Items.RemoveAt(0);
            }
            if (!recentPaths.Contains(newPath) && Path.GetFileName(newPath)!="") 
            {
                recentPaths.Add(newPath);
                recentPathsBox.Items.Add(Path.GetFileName(newPath));
                filePathBox.Text = newPath;
                LoadFiles(newPath);
                if (recentPathsBox.SelectedIndex + 1 < recentPathsBox.Items.Count)
                {
                    recentPathsBox.SelectedIndex++;
                }
            }
        }

        private void filePathBox_LostFocus(object sender, EventArgs e)
        {
            if(pathUpdatePending)
            {
                UpdatePathList(filePath);
                LoadFiles(filePath);
                pathUpdatePending = false;
            }
        }

        private void fileBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog selector = new FolderBrowserDialog();

            string startDirectory = Program.defaultPath + @"\Notes";

            if(startDirectory != filePath && Directory.Exists(filePath))
            {
                startDirectory = filePath;
            }

            selector.SelectedPath = startDirectory;
            DialogResult result = selector.ShowDialog();
            if(result == DialogResult.OK)
            {
                LoadFiles(selector.SelectedPath);
                UpdatePathList(selector.SelectedPath);
                filePathBox.Text = selector.SelectedPath;
            }


        }

        private void recentPathsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFiles(recentPaths.ElementAt(recentPathsBox.SelectedIndex));
        }

        private void fileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fileList.SelectedIndices.Count > 0)
            {
                int candidateIndex = fileList.SelectedIndices[0];
                

                if (candidateIndex < notes.Count)
                {
                    if (isDirty)
                    {
                        string title = titleBox.Text;
                        if (title == "")
                        {
                            title = "untitled.txt";
                        }
                        DialogResult result = MessageBox.Show("Save changes to " + title + "?", "Save?", MessageBoxButtons.YesNoCancel);

                        if (result == DialogResult.Cancel)
                        {
                            return;
                        }
                        else if(result == DialogResult.No)
                        {
                            mainTextField.Text = notes.ElementAt(candidateIndex);
                            titleBox.Text = fileList.SelectedItems[0].Text;
                            isDirty = false;
                        }
                        else
                        {
                            BattleIO save = new BattleIO();
                            string newPath = save.SaveNoteAs(mainTextField.Text);
                            if(newPath != "")
                            {
                                if(!recentPaths.Contains(newPath))
                                {
                                    UpdatePathList(Path.GetDirectoryName(newPath));
                                }
                                mainTextField.Text = notes.ElementAt(candidateIndex);
                                titleBox.Text = fileList.SelectedItems[0].Text;
                                isDirty = false;
                            }
                           
                        }
                    }
                    else
                    {
                        mainTextField.Text = notes.ElementAt(candidateIndex);
                        titleBox.Text = fileList.SelectedItems[0].Text;
                        isDirty = false;
                    }
                }
            }
        }

        private void newNoteButton_Click(object sender, EventArgs e)
        {
            if (isDirty)
            {
                string title = titleBox.Text;
                if (title == "")
                {
                    title = "untitled.txt";
                }
                DialogResult result = MessageBox.Show("Save changes to " + title + "?", "Save?", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Cancel)
                {
                    return;
                }
                else if (result == DialogResult.No)
                {
                    mainTextField.Clear();
                    titleBox.Clear();
                    isDirty = false;
                }
                else
                {
                    BattleIO save = new BattleIO();
                    string newPath = "";
                     newPath = save.SaveNoteAs(mainTextField.Text);
                    if (newPath != "")
                    {
                        if (!recentPaths.Contains(newPath))
                        {
                            UpdatePathList(Path.GetDirectoryName(newPath));
                        }
                    }
                    mainTextField.Clear();
                    titleBox.Clear();
                    isDirty = false;
                }
            }
            else
            {
                mainTextField.Clear();
                titleBox.Clear();
                isDirty = false;
            }
        }

        private void mainTextField_TextChanged(object sender, EventArgs e)
        {
            isDirty = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Save(false);
        }

        private void Save(bool SaveAs)
        {
            if(SaveAs)
            {
                BattleIO save = new BattleIO();
                string newPath = save.SaveNoteAs(mainTextField.Text);
                if (newPath != "")
                {
                    if (!recentPaths.Contains(newPath))
                    {
                        UpdatePathList(Path.GetDirectoryName(newPath));
                        LoadFiles(Path.GetDirectoryName(newPath));
                    }
                }
                isDirty = false;
            }
            else
            {
                string newPath = filePath + @"\" + titleBox.Text;
                if(newPath.Split('.').Length > 1)
                {
                    if(newPath.Split('.').Last<string>() != "txt")
                    {
                        newPath += ".txt";
                    }
                }
                if(Directory.GetFiles(filePath).Contains(newPath))
                {
                    BattleIO save = new BattleIO();
                    save.SaveNote(mainTextField.Text, newPath);
                    LoadFiles(Path.GetDirectoryName(newPath));
                }
                else
                {
                    BattleIO save = new BattleIO();
                    newPath = save.SaveNoteAs(mainTextField.Text);
                    if (!recentPaths.Contains(newPath) && newPath != "")
                    {
                        UpdatePathList(Path.GetDirectoryName(newPath));
                        LoadFiles(Path.GetDirectoryName(newPath));
                    }
                }

                isDirty = false;
            }
        }

        private void laodNoteButton_Click(object sender, EventArgs e)
        {
            openNoteDialog.ShowDialog();

            if(openNoteDialog.FileName != "")
            {
                string text = LoadNote(openNoteDialog.FileName);
                if(text != "")
                {
                    mainTextField.Text = text;
                }

                if (!recentPaths.Contains(openNoteDialog.FileName))
                {
                    UpdatePathList(Path.GetDirectoryName(openNoteDialog.FileName));
                    LoadFiles(openNoteDialog.FileName);
                }
            }
        }

        private string LoadNote(string path)
        {
            if (isDirty)
            {
                string title = titleBox.Text;
                if (title == "")
                {
                    title = "untitled.txt";
                }
                DialogResult result = MessageBox.Show("Save changes to " + title + "?", "Save?", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Cancel)
                {
                    return "";
                }
                else if (result == DialogResult.No)
                {
                    BattleIO load = new BattleIO();
                    string output = load.LoadNote(path);
                    return output;
                }
                else
                {
                    BattleIO save = new BattleIO();
                    string newPath = save.SaveNoteAs(mainTextField.Text);

                    if(newPath != "")
                    {
                        BattleIO load = new BattleIO();
                        string output = load.LoadNote(path);
                        return output;
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            else
            {
                BattleIO load = new BattleIO();
                string output = load.LoadNote(path);
                return output;
            }
        }



   
    }
}
