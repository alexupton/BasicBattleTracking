using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBattleTracking
{
    class DiceRoller
    {
        public int LastResult{get; private set;}
        public List<int> DiceRolls { get; private set; }
        private int dieAmt;
        private int dieMax;
        private int add;
        public int RawDieTotal { get; private set; }
        public DiceRoller(int dieCount, int dieType, int bonus)
        {
            dieAmt = dieCount;
            dieMax = dieType;
            add = bonus;
            DiceRolls = new List<int>();
        }

        public int RollDice()
        {
            DiceRolls.Clear();
            int result = 0;
            Random randy = new Random();
            if (dieMax < 1)
            {
                return 1;
            }
            else
            {
                if(dieAmt > 999)
                {
                    dieAmt = 999;
                }
                for (int i = 0; i < dieAmt; i++)
                {
                    int temp = randy.Next(dieMax) + 1;
                    DiceRolls.Add(temp);
                    result += temp;
                }
                RawDieTotal = result;
                result += add;
                return result;
            }
        }
    }
}
