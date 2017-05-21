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

        private string defaultPath = Program.defaultPath;
        public void AutoSave(List<Fighter> combatants)
        {
            StringBuilder rawText = new StringBuilder();
            int npcIndex = 0;
            string npcPath = defaultPath + @"\Save\NPCs\";
            string autoPath = defaultPath + @"\Save\auto.txt";
            if(Program.UserAutoSaveDirectory != "")
            {
                autoPath = Program.UserAutoSaveDirectory;
                npcPath = autoPath + @"\NPCs\";
                autoPath += @"\auto.txt";
            }

            if(!Directory.Exists(npcPath))
            {
                Directory.CreateDirectory(npcPath);
            }
            foreach(string file in Directory.GetFiles(npcPath))
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
                    string newNpcPath = npcPath + f.Name + npcIndex.ToString()  + ".txt";
                    
                    SaveStatBlock(newNpcPath, f);
                    npcIndex++;

                }
            }

            
            if(File.Exists(autoPath))
            {
                File.Delete(autoPath);
            }
            try
            {
                File.WriteAllText(autoPath, rawText.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + " Please change the autosave directory in the options menu and try again.", "Auto Save Failed");
            }
            

        }

        public List<Fighter> AutoLoad()
        {
            List<Fighter> fighters = new List<Fighter>();
            string path = defaultPath + @"\Save\auto.txt";
            if(Program.UserAutoSaveDirectory != "")
            {
                path = Program.UserAutoSaveDirectory + @"\auto.txt";
            }
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

            path = defaultPath + @"\Save\NPCS";
            if (Program.UserAutoSaveDirectory != "")
            {
                path = Program.UserAutoSaveDirectory + @"\NPCS";
            }
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
            string logPath = defaultPath + @"\Save\Log\";
            if(Program.UserLogDirectory != "")
            {
                logPath = Program.UserLogDirectory;
            }

            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }
            string path = logPath + "\\" + DateTime.Now.ToLongDateString() + ".txt";

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

        public bool SaveSettings(OptionScreen sender)
        {
            bool success = true;

            StringBuilder sb = new StringBuilder();

            string path = Program.defaultPath + @"\Settings.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            if (!Directory.Exists(sender.StatBlockPath) || !Directory.Exists(sender.AutoSavePath) || !Directory.Exists(sender.LogPath) || !Directory.Exists(sender.NotesPath))
            {
                MessageBox.Show("Invalid file path for one or more default directories", "Error");
                success = false;
            }
            else
            {
                sb.AppendLine("StatBlockPath|<" + sender.StatBlockPath + ">");
                sb.AppendLine("AutoSavePath|<" + sender.AutoSavePath + ">");
                sb.AppendLine("LogPath|<" + sender.LogPath + ">");
                sb.AppendLine("NotesPath|<" + sender.NotesPath + ">");

                File.WriteAllText(path, sb.ToString());
            }
            return success;
        }

        public void LoadSettings()
        {
            string path = Program.defaultPath + @"\Settings.txt";
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);

                for(int i = 0; i < lines.Length; i++)
                {
                    string[] line = lines[i].Split('|');

                    switch(line[0])
                    {
                        case "StatBlockPath":
                            {
                                Program.UserStatBlockDirectory = GetSettingPath(line[1]); break;
                            }
                        case "AutoSavePath":
                            {
                                Program.UserAutoSaveDirectory = GetSettingPath(line[1]); break;
                            }
                        case "LogPath":
                            {
                                Program.UserLogDirectory = GetSettingPath(line[1]); break;
                            }
                        case "NotesPath":
                            {
                                Program.UserNotesDirectory = GetSettingPath(line[1]); break;
                            }
                        default: break;
                    }

                }
            }
        }

        private string GetSettingPath(string candidateLine)
        {
            StringBuilder sb = new StringBuilder();
            int startIndex = -1;
            int testIndex = 0;
            char[] lineChars = candidateLine.ToCharArray();
            while (startIndex < 0 && testIndex < lineChars.Length)
            {
                if (lineChars[testIndex] == '<')
                {
                    startIndex = testIndex + 1;
                }
                else
                {
                    testIndex++;
                }
            }
            if (startIndex >= 0)
            {
                for (int i = startIndex; i < lineChars.Length; i++ )
                {
                    if (lineChars[i] == '>')
                        i = lineChars.Length;
                    else
                    {
                        sb.Append(lineChars[i]);
                    }
                }
                return sb.ToString();
            }
            else
            {
                return "";
            }
        }

        public string SaveNoteAs(string text)
        {
            string outputPath = "";
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text File (*.txt)|*.txt";

            DialogResult result = save.ShowDialog();
            if(result == DialogResult.OK)
            {
                if(File.Exists(save.FileName))
                {
                    File.Delete(save.FileName);
                }
                File.WriteAllText(save.FileName, text);
                outputPath = save.FileName;
            }

            return outputPath;
        }

        public void SaveNote(string text, string path)
        {
            if(File.Exists(path))
            {
                File.Delete(path);
            }

            File.WriteAllText(path, text);
        }

        public string LoadNote(string path)
        {
            string output = "";
            try
            {
                output = File.ReadAllText(path);
            }
            catch(Exception e)
            {
                MessageBox.Show("Unable to load note.\n\nDetails: " + e.Message, "Error!");
            }

            return output;
        }
    }

    
}
