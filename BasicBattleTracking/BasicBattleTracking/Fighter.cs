using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBattleTracking
{
    public class Fighter
    {
        public string Name { get; set; }
        public int Initiative { get; set; }
        public int InitBonus { get; set; }
        public bool isPC { get; set; }
        public bool HoldAction { get; set; }

        public List<Attack> attacks { get; set; }
        public List<Status> StatusEffects { get; set; }

        public int will { get; set; }
        public int reflex { get; set; }
        public int fort { get; set; }


        public int AC { get; set; }
        public int FlatFootedAC { get; set; }
        public int TouchAC { get; set; }

        public int HP { get; set; }
        public int HPMult { get; set; }
        public int HPDieType { get; set; }
        public int HPAdd { get; set; }

        public int CMB { get; set; }
        public int CMD { get; set; }

        public int SpellPoints { get; set; }
        public int SpellResist { get; set; }

        public int Str { get; set; }
        public int Dex { get; set; }
        public int Con { get; set; }
        public int Int { get; set; }
        public int Wis { get; set; }
        public int Cha { get; set; }


        public Fighter(string name, int initBonus, bool PC)
        {
            Name = name;
            Initiative = 0;
            InitBonus = initBonus;
            HP = 0;
            isPC = PC;
            HoldAction = false;
            StatusEffects = new List<Status>();
            attacks = new List<Attack>();
        }

    }
}
