using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBattleTracking
{
    public class Spell
    {
        private Fighter owner;
        private List<Fighter> targets;
        private List<Status> effects;
        public bool saveAllowed { get; set; }
        public int saveType { get; set; }
        public int saveDC { get; set; }
        public int level { get; set; }
        public int UseTotal { get; set; }
        public int UseCount { get; set; }

        public Spell(Fighter caster, List<Fighter> targetList, List<Status> statusList)
        {

        }
    }
}
