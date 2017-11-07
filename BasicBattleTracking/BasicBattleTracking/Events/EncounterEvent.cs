using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBattleTracking.Events
{
    public abstract class EncounterEvent
    {
        public abstract int StartTurnID { get; set; }
        public abstract int EndTurnID { get; set; }
        public abstract void Execute();
    }
}
