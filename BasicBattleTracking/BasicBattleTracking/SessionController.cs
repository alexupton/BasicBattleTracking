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

        public SessionController()
        {
        }
        public SessionController(MainWindow sender)
        {
            isDirty = false;
            saver = new BattleIO();
            sendingForm = sender;
            startFolder = "";
        }

        public void SetDirty(bool value)
        {
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
                    sendingForm.ExtractFields(newParent);
                    sendingForm.WriteToLog("===============  SESSION LOADED ON " + DateTime.Now.Date + " ===============");
                    startFolder = Path.GetDirectoryName(FilePath);
                    isDirty = false;
                }
            }
            
            
        }

        private bool Save()
        {
            SaveFileDialog saveBox = new SaveFileDialog();
            saveBox.Filter = "Session File (*.ssn)|*.ssn";
            if (startFolder != "")
                saveBox.InitialDirectory = startFolder;
            DialogResult result = saveBox.ShowDialog();
            if (result == DialogResult.OK)
            {
                saver = new BattleIO();
                FilePath = saveBox.FileName;
                startFolder = Path.GetDirectoryName(FilePath);
                SessionDetail sessionData = new SessionDetail();
                sessionData.CopySessionFieldsFromWindow(sendingForm);
                //List<SerializableObject> saveableData = SerializableObject.PackageObjectList(sessionData);
                if (saver.SaveObject<SessionDetail>(sessionData, FilePath))
                {
                    sendingForm.WriteToLog("Session Saved as \"" + FilePath + "\"");
                    isDirty = false;
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
                sessionData.CopySessionFieldsFromWindow(sendingForm);
                saver = new BattleIO();
                //List<SerializableObject> saveableData = SerializableObject.PackageObjectList(sessionData);
                saver.SaveObject<SessionDetail>(sessionData, FilePath);
                sendingForm.WriteToLog("Session Saved as \"" + FilePath + "\"");
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

        
    }
}
