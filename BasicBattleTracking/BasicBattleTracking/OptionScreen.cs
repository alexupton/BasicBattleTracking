using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicBattleTracking
{
    public partial class OptionScreen : Form
    {
        public string StatBlockPath { get; private set; }
        public string AutoSavePath { get; private set; }
        public string LogPath { get; private set; }
        public string NotesPath { get; private set; }
        public OptionScreen()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            StatBlockPath = statPathBox.Text;
            AutoSavePath = autoPathBox.Text;
            LogPath = logPathBox.Text;
            NotesPath = notesPathBox.Text;

            BattleIO saver = new BattleIO();
            if(saver.SaveSettings(this))
            {
                Program.UserStatBlockDirectory = StatBlockPath;
                Program.UserAutoSaveDirectory = AutoSavePath;
                Program.UserLogDirectory = LogPath;
                Program.UserNotesDirectory = NotesPath;
                this.Close();
            }
        }

        private void OptionScreen_Load(object sender, EventArgs e)
        {
            if(Program.UserAutoSaveDirectory != "")
            {
                autoPathBox.Text = Program.UserAutoSaveDirectory;
            }
            else
            {
                autoPathBox.Text = Program.defaultPath + @"\Save";
            }

            if (Program.UserLogDirectory != "")
            {
                 logPathBox.Text = Program.UserLogDirectory;
            }
            else
            {
                logPathBox.Text = Program.defaultPath + @"\Save\Log";
            }

            if (Program.UserStatBlockDirectory!= "")
            {
                statPathBox.Text = Program.UserStatBlockDirectory;
            }
            else
            {
                statPathBox.Text = Program.defaultPath + @"\Stat Blocks";
            }

            if(Program.UserNotesDirectory != "")
            {
                notesPathBox.Text = Program.UserNotesDirectory;
            }
            else
            {
                notesPathBox.Text = Program.defaultPath + @"\Notes";
            }

            
        }

        private void UpdatePathBox(TextBox target, int stringDestinationValue)
        {
            FolderBrowserDialog selector = new FolderBrowserDialog();

            string startDirectory = "";
            switch(stringDestinationValue)
            {
                case 1: startDirectory = autoPathBox.Text; break;
                case 2: startDirectory = logPathBox.Text; break;
                case 3: startDirectory = notesPathBox.Text; break;
                default: startDirectory = statPathBox.Text; break;
            }
            try
            {
                selector.SelectedPath = startDirectory;
            }
            catch
            {
                selector.SelectedPath = Program.defaultPath;
            }

            DialogResult result = selector.ShowDialog();
            if(result == DialogResult.OK)
            {
                target.Text = selector.SelectedPath;
            }
        }


        private void BrowseButton1_Click(object sender, EventArgs e)
        {
            UpdatePathBox(statPathBox, 0);
        }

        private void browseButton2_Click(object sender, EventArgs e)
        {
            UpdatePathBox(autoPathBox, 1);
        }

        private void browseButton3_Click(object sender, EventArgs e)
        {
            UpdatePathBox(logPathBox, 2);
        }

        private void cancButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void browseButton4_Click(object sender, EventArgs e)
        {
            UpdatePathBox(notesPathBox, 3);
        }

        private void statPathBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
