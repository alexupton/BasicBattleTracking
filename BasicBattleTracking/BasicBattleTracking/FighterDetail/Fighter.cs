using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using BasicBattleTracking.FighterDetail;

namespace BasicBattleTracking
{
    [Serializable()]
    public class Fighter
    {
        public string Name { get; set; }
        public int Initiative { get; set; }
        public int Level { get; set; }
        public int InitBonus { get; set; }
        public bool isPC { get; set; }
        public bool HoldAction { get; set; }
        public string Notes { get; set; }
        public string Alignment { get; set; }

        public List<Attack> attacks { get; set; }
        public List<Status> StatusEffects { get; set; }
        public List<Skill> skills { get; set; }
        public List<Feat> Feats { get; set; }

        public Save Will { get; set; }
        public Save Reflex { get; set; }
        public Save Fort { get; set; }

        public int will { get {
            if (Will != null)
            {
                return Will.total;
            }
            else
            {
                return willSave;
            }
        }
            set
            {
                if(Will != null)
                {
                    Will.total = value;
                }
                else
                {
                    willSave = value;
                }
            }
        }
        public int reflex
        {
            get
            {
                if (Reflex != null)
                {
                    return Reflex.total;
                }
                else
                {
                    return reflexSave;
                }
            }
            set
            {
                if (Reflex != null)
                {
                    Reflex.total = value;
                }
                else
                {
                    reflexSave = value;
                }
            }
        }
        public int fort {get {
            if (Fort != null)
            {
                return Fort.total;
            }
            else
            {
                return fortSave;
            }
        }
            set
            {
                if(Fort != null)
                {
                    Fort.total = value;
                }
                else
                {
                    fortSave = value;
                }
            }
        }

        private int willSave;
        private int reflexSave;
        private int fortSave;


        public int AC { get; set; }
        public int FlatFootedAC { get; set; }
        public int TouchAC { get; set; }

        public int HP { get; set; }
        public int HPMult { get; set; }
        public int HPDieType { get; set; }
        public int HPAdd { get; set; }
        public int MaxHP { get; set; }

        public int CMB { get; set; }
        public int CMD { get; set; }

        public int SpellPoints { get; set; }
        public int SpellResist { get; set; }

        public int DamageReduce { get; set; }

        public int Str { get; set; }
        public int Dex { get; set; }
        public int Con { get; set; }
        public int Int { get; set; }
        public int Wis { get; set; }
        public int Cha { get; set; }

        public int tempStr { get; set; }
        public int tempDex { get; set; }
        public int tempCon { get; set; }
        public int tempInt { get; set; }
        public int tempWis { get; set; }
        public int tempCha { get; set; }

        public int NegativeLevels { get; set; }
        public int LastNegLvlValue { get; set; }

        public int attackMod { get; set; }

        public string savePath { get; set; }


        public Fighter(string name, int initBonus, bool PC)
        {
            Name = name;
            Initiative = 0;
            InitBonus = initBonus;
            HP = 0;
            isPC = PC;
            tempStr = -1;
            tempDex = -1;
            tempCon = -1;
            tempInt = -1;
            tempWis = -1;
            tempCha = -1;
            HoldAction = false;
            StatusEffects = new List<Status>();
            attacks = new List<Attack>();
            skills = new List<Skill>();
            Feats = new List<Feat>();
            Fort = new Save();
            Reflex = new Save();
            Will = new Save();
        }
        public Fighter()
        {
            Name = "";
            Initiative = 0;
            InitBonus = 0;
            HP = 0;
            isPC = true;
            HoldAction = false;
            tempStr = -1;
            tempDex = -1;
            tempCon = -1;
            tempInt = -1;
            tempWis = -1;
            tempCha = -1;
            StatusEffects = new List<Status>();
            attacks = new List<Attack>();
            skills = new List<Skill>();
            Feats = new List<Feat>();
            Fort = new Save();
            Reflex = new Save();
            Will = new Save();
        }

        public void ApplyNegativeLevels(int count)
        {
            int difference = count - NegativeLevels;
                if (difference > 0)
                {
                    for (int i = 0; i < difference; i++)
                    {
                        HP -= 5;
                        CMD -= 1;
                        CMB -= 1;
                        Fort.total -= 1;
                        Will.total -= 1;
                        Reflex.total -= 1;

                        foreach (Attack atk in attacks)
                        {
                            atk.atkBonus -= 1;
                            for (int j = 0; j < atk.atkBonuses.Count; j++)
                            {
                                atk.atkBonuses[j] -= 1;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < Math.Abs(difference); i++)
                    {
                        HP += 5;
                        CMD += 1;
                        CMB += 1;
                        Fort.total += 1;
                        Will.total += 1;
                        Reflex.total += 1;

                        foreach (Attack atk in attacks)
                        {
                            atk.atkBonus += 1;
                            for (int j = 0; j < atk.atkBonuses.Count; j++)
                            {
                                atk.atkBonuses[j] += 1;
                            }
                        }
                    }
                }
                NegativeLevels = count;
        }

        public void ApplyGlobalAttackMod(int count)
        {
            int difference = attackMod - count;
            if (difference > 0)
            {
                for(int i = 0; i < difference; i ++)
                {
                    for(int j = 0; j < attacks.Count; j++)
                    {
                        for(int k = 0; k < attacks.ElementAt(j).atkBonuses.Count; k++)
                        {
                            int newValue = attacks.ElementAt(j).atkBonuses.ElementAt(k) - 1;
                            attacks.ElementAt(j).atkBonuses.RemoveAt(k);
                            attacks.ElementAt(j).atkBonuses.Insert(k, newValue);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < Math.Abs(difference); i++)
                {
                    for (int j = 0; j < attacks.Count; j++)
                    {
                        for (int k = 0; k < attacks.ElementAt(j).atkBonuses.Count; k++)
                        {
                            int newValue = attacks.ElementAt(j).atkBonuses.ElementAt(k) + 1;
                            attacks.ElementAt(j).atkBonuses.RemoveAt(k);
                            attacks.ElementAt(j).atkBonuses.Insert(k, newValue);
                        }
                    }
                }
            }
            attackMod = count;
        }

        public void UpdateStatusTargets()
        {
            foreach(Status effect in StatusEffects)
            {
                effect.SetTarget(this);
            }
        }


    }
}
