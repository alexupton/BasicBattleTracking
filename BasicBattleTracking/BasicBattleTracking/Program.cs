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
        public static List<Skill> defaultSkillLoadout;
        

        public static bool initEachRound;
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
            defaultSkillLoadout = new List<Skill>();

            initEachRound = true;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }

        public static int getAbilityMod(int abilityScore)
        {
            int mod = 0;
            if (abilityScore >= 10)
            {
                mod = (abilityScore - 10) / 2;
            }
            else
            {
                mod = (abilityScore - 11) / 2;
            }
            return mod;
        }
    }
}
