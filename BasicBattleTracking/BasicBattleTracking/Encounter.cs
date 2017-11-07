using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBattleTracking
{
    public class Encounter
    {
        public List<Event.EncounterEvent> eventsList { get; set; }
        public int Turn { get; set; }


    }
}
