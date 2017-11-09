using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBattleTracking
{
    [Serializable()]
    public class SessionDetail
    {
        public List<Fighter> combatants { get; set; }
        public List<String> fighterOrder { get; set; }
        public List<Status> statusEffects { get; set; }
        public int combatRound { get; set; }
        public int activeIndex { get; set; }
        public int selectedFighter { get; set; }
        public int selectedStatus { get; set; }
        public bool holdFlag { get; set; }
        public int savedIndex { get; set; }
        public List<int> statuses { get; set; }
        public bool multiStatus { get; set; }
        public Fighter selectedFighterObject { get; set; }
        public Fighter editFighter { get; set; }
        public int selectedAttack { get; set; }
        public SessionController session { get; set; }


        public bool cancelInit { get; set; }

        public List<Status> recentlyUsedStatuses { get; set; }

        public static string FilePath { get; set; }
        public Settings settings { get; set; }
        public string SessionName { get; set; }

        public SessionDetail()
        {

        }

        public void CopySessionFieldsFromWindow(MainWindow sendingForm, string sessionName)
        {
            combatants = sendingForm.combatants;
            fighterOrder = sendingForm.fighterOrder;
            statusEffects = sendingForm.statusEffects;
            combatRound = sendingForm.combatRound;
            activeIndex = sendingForm.activeIndex;
            selectedFighter = sendingForm.selectedFighter;
            selectedStatus = sendingForm.selectedStatus;
            holdFlag = sendingForm.holdFlag;
            savedIndex = sendingForm.savedIndex;
            statuses = sendingForm.statuses;
            multiStatus = sendingForm.multiStatus;
            selectedFighterObject = sendingForm.selectedFighterObject;
            editFighter = sendingForm.editFighter;
            selectedAttack = sendingForm.selectedAttack;
            session = sendingForm.session;


            cancelInit = sendingForm.cancelInit;

            recentlyUsedStatuses = sendingForm.recentlyUsedStatuses;
            SessionName = sessionName;
        }

        
    }
}
