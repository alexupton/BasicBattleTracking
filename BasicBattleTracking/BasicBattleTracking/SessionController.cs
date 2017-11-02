using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BasicBattleTracking
{
    public class SessionController
    {
        private bool isDirty;
        private string FilePath;
        private BattleIO saver;
        private MainWindow sendingForm;
        private string startFolder;

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
            if (result == DialogResult.OK)
            {
                if (File.Exists(FilePath))
                {
                    List<object> newParent = saver.LoadObject<List<object>>(FilePath);
                    sendingForm.LoadSession(newParent);
                    sendingForm.WriteToLog("===============  SESSION LOADED ON " + DateTime.Now.Date + " ===============");
                    startFolder = Path.GetDirectoryName(FilePath);
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
                FilePath = saveBox.FileName;
                startFolder = Path.GetDirectoryName(FilePath);
                List<object> sessionData = sendingForm.CompileAndGetFields();
                saver.SaveObject<List<object>>(sessionData, FilePath);
                return true;
            }
            else
                return false;
            
        }

        public void SaveSession()
        {
            if(File.Exists(FilePath))
            {
                List<object> sessionData = sendingForm.CompileAndGetFields();
                saver.SaveObject<List<object>>(sessionData, FilePath);
            }
            else
            {
                Save();
            }
        }

        
    }
}
