using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBattleTracking
{
    [Serializable()]
    public class Spell
    {

        public int SpellID { get; set; }
        public string Name { get; set; }
        public string School { get; set; }
        public string SubSchool { get; set; }
        public List<string> CharClass { get; set; }
        public List<int> CharLevel { get; set; }
        public int castingTime { get; set; }
        public string castingActionType { get; set; }
        public List<string> Components { get; set; }
        public int costlyComponentCount { get; set; }
        public string range { get; set; }
        public string area { get; set; }
        public string effect { get; set; }
        public string targets { get; set; }
        public string duration { get; set; }
        public bool dismissable { get; set; }
        public bool shapeable { get; set; }
        public string saveType { get; set; }
        public int saveDC { get; set; }

        public Spell()
        {

        }
    }
}
