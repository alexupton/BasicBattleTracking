using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BasicBattleTracking
{
    [Serializable()]
    public class SessionController
    {
        private bool isDirty;
        private string FilePath;
       [NonSerialized] private BattleIO saver;
       [NonSerialized] private MainWindow sendingForm;

       
        private string startFolder;
        public Settings settings { get; set; }

        public SessionController()
        {
        }
        public SessionController(MainWindow sender)
        {
            isDirty = false;
            saver = new BattleIO();
            settings = new Settings();
            sendingForm = sender;
            startFolder = "";
        }

        public void SetDirty(bool value)
        {
            if(Program.activeSessionName != null && value == true && sendingForm != null)
            {
                sendingForm.Text = Program.ProgramName + " - " + Program.activeSessionName + "*";
            }
            else if(sendingForm != null)
            {
                sendingForm.Text = Program.ProgramName + " - " + Program.activeSessionName;
            }
            isDirty = value;
        }

        public bool Exit()
        {
            if (isDirty)
            {
                DialogResult result = MessageBox.Show("Save current session before exiting?", "Exit", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    if (File.Exists(FilePath))
                    {
                        saver.SaveObject<MainWindow>(sendingForm, FilePath);
                        return true;
                    }
                    else
                    {

                        return Save();

                    }
                }
                else if (result == DialogResult.No)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }

        }

        public void LoadSession()
        {
            if (isDirty)
            {
                if (!Exit())
                {
                    return;
                }
            }
            OpenFileDialog load = new OpenFileDialog();
            if (startFolder != "")
                load.InitialDirectory = startFolder;
            
            load.Filter = "Session File (*.ssn)|*.ssn";
            DialogResult result = load.ShowDialog();
            FilePath = load.FileName;
            SessionDetail.FilePath = load.FileName;
            
            if (result == DialogResult.OK)
            {
                if (File.Exists(FilePath))
                {
                    saver = new BattleIO();
                    SessionDetail newParent = saver.LoadObject<SessionDetail>(FilePath);
                    if (newParent == null)
                    {
                        sendingForm.WriteToLog("Load failed. Invalid file loaded.");
                    }
                    else
                    {
                        sendingForm.ExtractFields(newParent);
                        if (newParent.combatants.Count > 0)
                        {
                            sendingForm.enableGlobalButtons(); sendingForm.enableTurnButtons();
                        }
                        else
                            sendingForm.ResetControls();

                        sendingForm.WriteToLog("===============  SESSION LOADED ON " + DateTime.Now + " ===============");
                        startFolder = Path.GetDirectoryName(FilePath);
                        Program.activeSessionName = Path.GetFileName(FilePath);
                        sendingForm.Text = Program.ProgramName + " - " + Path.GetFileName(FilePath);
                        
                        isDirty = false;
                    }
                }
            }
            
            
        }

        public void LoadSettings(string path)
        {
            string settingsName = Path.GetDirectoryName(path) + @"\" + Path.GetFileNameWithoutExtension(path) + "_settings.xml";
            if (File.Exists(settingsName))
            {
                Settings newSettings = saver.LoadObject<Settings>(settingsName);
                if (newSettings == null)
                {
                    sendingForm.WriteToLog("No settings found for this session. Using defaults");
                }
                else
                {
                    settings = newSettings;
                }
            }
        }
        public void SaveSettings(string path)
        {
            saver = new BattleIO();
            string settingsName = Path.GetDirectoryName(path) + @"\" + Path.GetFileNameWithoutExtension(FilePath) + "_settings.xml";
            saver.SaveObject<Settings>(settings, settingsName);
        }
        private bool Save()
        {
            SaveFileDialog saveBox = new SaveFileDialog();
            saveBox.Filter = "Session File (*.ssn)|*.ssn";
            if (startFolder != "")
                saveBox.InitialDirectory = startFolder;
            saveBox.FileName = Program.activeSessionName;
            DialogResult result = saveBox.ShowDialog();
            if (result == DialogResult.OK)
            {
                saver = new BattleIO();
                FilePath = saveBox.FileName;
                startFolder = Path.GetDirectoryName(FilePath);
                Program.activeSessionName = Path.GetFileName(FilePath);
                SessionDetail sessionData = new SessionDetail();
                sessionData.CopySessionFieldsFromWindow(sendingForm, Program.activeSessionName);
                //List<SerializableObject> saveableData = SerializableObject.PackageObjectList(sessionData);
                if (saver.SaveObject<SessionDetail>(sessionData, FilePath))
                {
                    sendingForm.WriteToLog("Session Saved as \"" + FilePath + "\"");

                    SaveSettings(FilePath);
                    isDirty = false;
                    sendingForm.Text = Program.ProgramName + " - " + Path.GetFileName(FilePath);
                    return true;
                }
                else
                {
                    sendingForm.WriteToLog("Save failed. Check the log for details.");
                    return true;
                }
            }
            else
                return false;
            
        }

        public void SaveSession(bool SaveAs)
        {
            if (FilePath == null)
                FilePath = SessionDetail.FilePath;
            if(File.Exists(FilePath) && !SaveAs)
            {
                SessionDetail sessionData = new SessionDetail();
                sessionData.CopySessionFieldsFromWindow(sendingForm, Program.activeSessionName);
                saver = new BattleIO();
                saver.SaveObject<SessionDetail>(sessionData, FilePath);
                sendingForm.WriteToLog("Session Saved as \"" + FilePath + "\"");
                sendingForm.Text = Program.ProgramName + " - " + Program.activeSessionName;
                isDirty = false;
            }
            else
            {
                Save();
            }
        }

        public void ReinitializeSender(MainWindow sender)
        {
            sendingForm = sender;
        }

        public void New()
        {
            FilePath = "";
        }

        public bool HasValidFilePath()
        {
            if (FilePath == null || !Directory.Exists(FilePath))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        
    }
}
