using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBattleTracking
{
    [Serializable]
    public class Settings
    {
        public bool initEachRound { get; set; }
        public bool confirmCrits { get; set; }
        public string UserStatBlockDirectory { get; set; }
        public string UserLogDirectory { get; set; }
        public string UserAutoSaveDirectory { get; set; }
        public string UserNotesDirectory { get; set; }
        public string UserSessionDirectory { get; set; }
        public string UserSpellFilePath { get; set; }
        public List<Skill> defaultSkillLoadout;

        public Settings()
        {
            UserAutoSaveDirectory = "";
            UserStatBlockDirectory = "";
            UserLogDirectory = "";
            UserNotesDirectory = "";
            initEachRound = true;
        }
    }
}
