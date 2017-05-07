using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicBattleTracking
{
    static class Program
    {
        public static string UserStatBlockDirectory;
        public static string UserLogDirectory;
        public static string UserAutoSaveDirectory;
        public static string UserNotesDirectory;
        public static string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\BasicBattleTracking";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        
        static void Main()
        {
            UserAutoSaveDirectory = "";
            UserStatBlockDirectory = "";
            UserLogDirectory = "";
            UserNotesDirectory = "";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
