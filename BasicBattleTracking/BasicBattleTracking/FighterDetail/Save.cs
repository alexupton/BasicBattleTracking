using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBattleTracking.FighterDetail
{
    [Serializable]
    public class Save
    {
        public int total { get; set; }
        private int baseValue;
        private int Ability;
        private int Magic;
        private int Temp;
        public int baseVal { get { return this.baseValue; } set { baseValue = value; CalculateTotal(); } }
        public int abilityMod { get { return this.Ability; } set { Ability = value; CalculateTotal(); } }
        public int magicMod { get { return this.Magic; } set { Magic = value; CalculateTotal(); } }
        public int tempMod { get { return this.Temp; } set { Temp = value; CalculateTotal(); } }

        public Save()
        {
            total = 0;
        }

        public override string ToString()
        {
            return total.ToString();
        }

        private void CalculateTotal()
        {
            total = baseVal + abilityMod + magicMod + tempMod;
        }


    }
}
