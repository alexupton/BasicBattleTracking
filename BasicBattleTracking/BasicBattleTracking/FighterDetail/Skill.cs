using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBattleTracking
{
    [Serializable()]
    public class Skill
    {
        public string name{get; set;}
        public int abilityMod { get; set; }
        public string abilitySource { get; set; }
        public int ranks { get; set; }
        public int miscMod { get; set; }
        public bool isClassSkill { get; set; }

        public bool classModifierApplied { get; set; }

        public int totalModifier { get; set; }

        public int LastD20 { get; set; }

        public Skill(string Name)
        {
            name = Name;
            abilityMod = 0;
            abilitySource = "Null";
            ranks = 0;
            miscMod = 0;
            classModifierApplied = false;
        }

        public Skill()
        {
            name = "NewSkill";
            abilityMod = 0;
            abilitySource = "Null";
            ranks = 0;
            miscMod = 0;
            classModifierApplied = false;

        }
        public int RollSkillCheck()
        {
            int result = 0;
            Random randy = new Random();
            LastD20 = randy.Next(20) + 1;
            result = LastD20 + abilityMod + ranks + miscMod;
            totalModifier = abilityMod + ranks + miscMod;
            return result;
        }
    }
}
