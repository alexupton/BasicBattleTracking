using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBattleTracking
{
    public class Attack
    {
        public string name { get; set; }
        public int atkBonus { get; set; }
        public int dmgBonus { get; set; }
        public int dieType { get; set; }
        public int dieAmt { get; set; }
        public int CritMin { get; set; }
        public int CritMult { get; set; }
        public List<int> atkBonuses { get; set; }
        public int atkCount { get; set; }

        public int AtkRollResult { get; set; }
        public List<int> damageRollResults { get; set; }
        public int RawDamageTotal { get; private set; }
        public Attack(string Name)
        {
            name = Name;
            CritMin = 20;
            atkBonuses = new List<int>();
            atkCount = 0;
            damageRollResults = new List<int>();
        }

        public int RollAttack()
        {
            if (atkBonuses.Count - atkCount <= 0)
                atkCount = 0;
            int result = 0;
            Random randy = new Random();

            AtkRollResult = randy.Next(20) + 1;
            result = AtkRollResult + atkBonuses.ElementAt(atkCount);
            atkCount++;
            return result;
        }

        public int RollDamage()
        {
            int result = 0;
            Random randy = new Random();
            damageRollResults.Clear();
            for (int i = 0; i < dieAmt; i++)
            {
                int temp = randy.Next(dieType) + 1;
                damageRollResults.Add(temp);
                result += temp;
            }
            RawDamageTotal = result;
            result += dmgBonus;
            return result;
        }

        public int ConfirmCritCheck()
        {
            int confirm = 0;
            Random randy = new Random();
            atkCount--;
            confirm = randy.Next(20) + 1 + atkBonuses.ElementAt(atkCount);
            return confirm;
        }

    }
}
