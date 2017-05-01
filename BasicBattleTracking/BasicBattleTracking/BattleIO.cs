using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace BasicBattleTracking
{
    public class BattleIO
    {
        public void AutoSave(List<Fighter> combatants)
        {
            StringBuilder rawText = new StringBuilder();
            int npcIndex = 0;
            foreach(string file in Directory.GetFiles(Environment.CurrentDirectory + @"\Save\NPCs\"))
                    {
                        File.Delete(file);
                    }
            foreach (Fighter f in combatants)
            {
                if (f.isPC)
                {
                    rawText.AppendLine(f.Name + "," + f.Initiative.ToString() + "," + f.HP.ToString()
                        + "," + f.InitBonus.ToString() + "," + f.isPC.ToString());
                }
                else
                {
                    string npcPath = Environment.CurrentDirectory + @"\Save\NPCs\" + f.Name + npcIndex.ToString()  + ".txt";
                    
                    SaveStatBlock(npcPath, f);
                    npcIndex++;

                }
            }

            string path = Environment.CurrentDirectory + @"\Save\auto.txt";
            if(File.Exists(path))
            {
                File.Delete(path);
            }
            File.WriteAllText(path, rawText.ToString());
            

        }

        public List<Fighter> AutoLoad()
        {
            List<Fighter> fighters = new List<Fighter>();
            string path = Environment.CurrentDirectory + @"\Save\auto.txt";
            if(File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] fStats = lines[i].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    try{
                    Fighter f = new Fighter(fStats[0], Int32.Parse(fStats[3]), Boolean.Parse(fStats[4]));
                    f.Initiative = Int32.Parse(fStats[1]);
                    f.HP = Int32.Parse(fStats[2]);
                    fighters.Add(f);
                    }
                    catch
                    {
                        MessageBox.Show("Unable to parse auto.txt. No AutoLoad available", "Error");
                        return fighters;
                    }
                    
                    
                    
                }
            }

            path = Environment.CurrentDirectory + @"\Save\NPCs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            else
            {
                int fighterCount = Directory.GetFiles(path).Length;
                for (int i = 0; i < fighterCount; i++)
                {
                    fighters.Add(LoadStatBlock(Directory.GetFiles(path)[i]));
                }
            }
            
            return fighters;
        }

        public void ExportLog(string log)
        {
            if (!Directory.Exists(Environment.CurrentDirectory + @"\Save\Log\"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + @"\Save\Log\");
            }
            string path = Environment.CurrentDirectory + @"\Save\Log\" + DateTime.Now.ToLongDateString() +  ".txt";

            if (File.Exists(path))
                File.Delete(path);

            File.WriteAllText(path, log);

        }
        public void SaveStatBlock(string path, Fighter f)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(RemoveForbiddenCharacters(f.Name));//0
            sb.AppendLine(f.InitBonus.ToString()); //1

            sb.AppendLine(f.HP.ToString()); //2
            sb.AppendLine(f.HPMult.ToString()); //3
            sb.AppendLine(f.HPDieType.ToString());//4
            sb.AppendLine(f.HPAdd.ToString());//5

            sb.AppendLine(f.AC.ToString());//6
            sb.AppendLine(f.FlatFootedAC.ToString());//7
            sb.AppendLine(f.TouchAC.ToString());//8

            

            sb.AppendLine(f.CMB.ToString());//9
            sb.AppendLine(f.CMD.ToString());//10

            sb.AppendLine(f.fort.ToString());//11
            sb.AppendLine(f.reflex.ToString());//12
            sb.AppendLine(f.will.ToString());//13

            sb.AppendLine("|AttackStart|");
            foreach (Attack atk in f.attacks)
            {
                sb.AppendLine(atk.name); //i
                sb.AppendLine(atk.atkBonus.ToString());//i + 1
                sb.AppendLine(atk.dieAmt.ToString());//i + 2
                sb.AppendLine(atk.dieType.ToString());//i +3
                sb.AppendLine(atk.dmgBonus.ToString());//i + 4
                sb.AppendLine(atk.CritMin.ToString()); //i + 5
                sb.AppendLine(atk.CritMult.ToString()); //i + 6
                sb.AppendLine("Attack Bonus Count :" + atk.atkBonuses.Count);
                foreach (int i in atk.atkBonuses)
                {
                    sb.AppendLine(i.ToString());
                }
            }

            File.WriteAllText(path, sb.ToString());

        }

        public Fighter LoadStatBlock(string path)
        {
            
            try
            {
                string[] lines = File.ReadAllLines(path);
                Fighter newFighter = new Fighter(lines[0], Int32.Parse(lines[1]), false);
                int attackStart = 14;
                int attackEnd = lines.Length;

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i] == "|AttackStart|")
                    {
                        attackStart = i + 1;
                    }
                }

                int dieType = Int32.Parse(lines[4]);
                int HP = 0;
                if (dieType > 0) //check for HP formula
                {
                    Random randy = new Random();
                    int mult = Int32.Parse(lines[3]);
                    int add = Int32.Parse(lines[5]);
                    for (int i = 0; i < mult; i++)
                    {
                        HP += randy.Next(dieType) + 1;
                    }
                    HP += add;
                    newFighter.HP = HP;

                    newFighter.HPDieType = dieType;
                    newFighter.HPMult = mult;
                    newFighter.HPAdd = add;

                }
                else
                {
                    newFighter.HP = Int32.Parse(lines[2]);
                }

                newFighter.AC = Int32.Parse(lines[6]);
                newFighter.FlatFootedAC = Int32.Parse(lines[7]);
                newFighter.TouchAC = Int32.Parse(lines[8]);
                newFighter.CMB = Int32.Parse(lines[9]);
                newFighter.CMD = Int32.Parse(lines[10]);
                newFighter.fort = Int32.Parse(lines[11]);
                newFighter.reflex = Int32.Parse(lines[12]);
                newFighter.will = Int32.Parse(lines[13]);
                
                List<Attack> newAttacks = new List<Attack>();
                for (int i = attackStart; i < attackEnd; i += 8)
                {
                    Attack temp = new Attack(lines[i]);
                    temp.atkBonus = Int32.Parse(lines[i + 1]);
                    temp.atkBonuses.Add(temp.atkBonus);
                    temp.dieAmt = Int32.Parse(lines[i + 2]);
                    temp.dieType = Int32.Parse(lines[i + 3]);
                    temp.dmgBonus = Int32.Parse(lines[i + 4]);
                    temp.CritMin = Int32.Parse(lines[i + 5]);
                    temp.CritMult = Int32.Parse(lines[i + 6]);
                    try
                    {
                        string[] countLine = lines[i + 7].Split(':');
                        int bonusCount = 0;
                        if (countLine.Length > 0)
                        {
                            bonusCount = Int32.Parse(countLine[1]);
                            List<int> atkBonuses = new List<int>();
                            for (int j = i + 8; j < bonusCount + i + 8; j++)
                            {
                                atkBonuses.Add(Int32.Parse(lines[j]));
                            }
                            temp.atkBonuses = atkBonuses;
                            i += bonusCount;
                        }
                    }
                    finally
                    {
                        newAttacks.Add(temp);
                    }
                }
                newFighter.attacks = newAttacks;
                return newFighter;
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message, "Stat Block Load Failed");
                return null;
            }

            
        }

        private string RemoveForbiddenCharacters(string input)
        {
            string output = input;
            char[] array = output.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '|')
                {
                    array[i] = ' ';
                }
            }
            return output;
        }
    }

    
}
