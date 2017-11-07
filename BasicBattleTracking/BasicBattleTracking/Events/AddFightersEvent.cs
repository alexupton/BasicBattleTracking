using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBattleTracking.Events
{
    public class AddFightersEvent : EncounterEvent
    {
        public List<Fighter> FighterDropList { get; set; }
        public override int StartTurnID { get; set; }
        public override int EndTurnID { get; set; }
    
        public AddFightersEvent()
        {
            StartTurnID = 1;
            EndTurnID = -1;
        }

        public override void Execute()
        {

        }
    }
}
