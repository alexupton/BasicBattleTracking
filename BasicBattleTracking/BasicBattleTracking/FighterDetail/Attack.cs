using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBattleTracking
{
    [Serializable()]
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
        public int RawDamageTotal { get; set; }

        private int atkStrBonus { get; set; }
        private int atkDexBonus { get; set; }
        private int dmgStrBonus { get; set; }
        private int dmgDexBonus { get; set; }

        public bool strBonusAppliedToAtk { get; set; }
        public bool strBonusAppliedToDmg { get; set; }
        public bool dexBonusAppliedToAtk { get; set; }
        public bool dexBonusAppliedToDmg { get; set; }
        public Attack(string Name)
        {
            name = Name;
            CritMin = 20;
            atkBonuses = new List<int>();
            atkCount = 0;
            damageRollResults = new List<int>();
        }

        public Attack()
        {
            name = "";
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

        public void UpdateStrBonusToAttack(int newBonus)
        {
            int diff = newBonus -atkStrBonus;
            atkStrBonus = newBonus;
            for (int i = 0; i < atkBonuses.Count; i++)
            {
                atkBonuses[i] += diff;
            }
            strBonusAppliedToAtk = true;
        }

        public void UpdateStrBonusToDamage(int newBonus)
        {
            int diff = newBonus -dmgStrBonus;
            dmgStrBonus = newBonus;
            dmgBonus += diff;
            strBonusAppliedToDmg = true;
        }
        
        public void UpdateDexBonusToAttack(int newBonus)
        {
            int diff =newBonus - atkDexBonus ;
            atkDexBonus = newBonus;
            for (int i = 0; i < atkBonuses.Count; i++)
            {
                atkBonuses[i] += diff;
            }
            dexBonusAppliedToAtk = true;
        }

        public void UpdateDexBonusToDamage(int newBonus)
        {
            int diff = newBonus -dmgDexBonus;
            dmgDexBonus = newBonus;
            dmgBonus += diff;
            dexBonusAppliedToDmg = true;
        }

        public void ResetAtkStrBonus()
        {
            for(int i = 0; i < atkBonuses.Count; i++)
            {
                atkBonuses[i] -= atkStrBonus;
            }
            atkStrBonus = 0;
            strBonusAppliedToAtk = false;
        }

        public void ResetAtkDexBonus()
        {
            for(int i = 0; i < atkBonuses.Count; i++)
            {
                atkBonuses[i] -= atkDexBonus;
            }
            atkDexBonus = 0;
            dexBonusAppliedToAtk = false;
        }

        public void ResetDmgStrBonus()
        {
            dmgBonus -= dmgStrBonus;
            dmgStrBonus = 0;
            strBonusAppliedToDmg = false;
        }

        public void ResetDmgDexBonus()
        {
            dmgBonus -= dmgDexBonus;
            dmgDexBonus = 0;
            dexBonusAppliedToDmg = false;
        }
    }
}
