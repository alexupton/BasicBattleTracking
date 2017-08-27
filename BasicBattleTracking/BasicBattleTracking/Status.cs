using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBattleTracking
{
    [Serializable()]
    public class Status
    {
        public string Name { get; set; }
        public int Turns { get; set; }
        public string Description { get; set; }
        public Fighter target { get; set; }

        public Status(string name, int turns)
        {
            Name = name;
            Turns = turns;
            Description = "";
        }


    }
}
