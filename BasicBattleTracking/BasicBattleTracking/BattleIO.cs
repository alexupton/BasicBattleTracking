﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace BasicBattleTracking
{
    public class BattleIO
    {

        private string defaultPath = Program.defaultPath;
        private Settings saveSettings;
        public void AutoSave(List<Fighter> combatants, bool[] checkBoxes, Settings settings, MainWindow sender)
        {

            string sessionPath = defaultPath + @"\Save\auto.ssn";
            if (sender.session.settings.UserAutoSaveDirectory != "")
            {
                sessionPath = sender.session.settings.UserAutoSaveDirectory + @"\auto.ssn";
            }
            SessionDetail saveSession = new SessionDetail();
            saveSession.CopySessionFieldsFromWindow(sender, Program.activeSessionName);
            SaveObject<SessionDetail>(saveSession, sessionPath);
            sender.session.SaveSettings(sessionPath);
            sender.session.ReinitializeSender(sender);
        }

        public List<Fighter> AutoLoad(MainWindow sender)
        {
            List<Fighter> fighters = new List<Fighter>();
            
            string sessionPath = defaultPath + @"\Save\auto.ssn";
            if (sender.session.settings.UserAutoSaveDirectory != "")
            {
                sessionPath = sender.session.settings.UserAutoSaveDirectory + @"\auto.ssn";
            }
            SessionDetail autoSesh = new SessionDetail();
            if (File.Exists(sessionPath))
            {
                autoSesh = LoadObject<SessionDetail>(sessionPath);
                if (autoSesh != null)
                {
                    Program.activeSessionName = autoSesh.SessionName;
                    sender.session.LoadSettings(sessionPath);
                    sender.ExtractFields(autoSesh);
                }
                LoadDefaultSkills(sender);
                if (autoSesh != null)
                {
                    return autoSesh.combatants;
                }
                else
                    return new List<Fighter>();
            }
            //LEGACY LOADER
            else
            {
                string path = defaultPath + @"\Save\auto.txt";
                if (sender.session.settings.UserAutoSaveDirectory != "")
                {
                    path = sender.session.settings.UserAutoSaveDirectory + @"\auto.txt";
                }
                if (File.Exists(path))
                {
                    string[] lines = File.ReadAllLines(path);
                    int fighterCount = lines.Length - 1;
                    int fighterStart = 1;
                    try
                    {
                        fighterCount = Int32.Parse(lines[0]);
                    }
                    catch
                    {
                        fighterStart = 0;
                    }

                    for (int i = fighterStart; i < fighterCount + 1; i++)
                    {
                        string[] fStats = lines[i].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        try
                        {
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

                    if (fighterCount + 1 < lines.Length)
                    {
                        int checkIndex = fighterCount + 1;
                        try
                        {
                            bool[] checkBoxes = new bool[] { Boolean.Parse(lines[checkIndex]), Boolean.Parse(lines[checkIndex + 1]), Boolean.Parse(lines[checkIndex + 2]), Boolean.Parse(lines[checkIndex + 3]) };
                            sender.SetCheckBoxes(checkBoxes);
                        }
                        catch
                        {
                            Console.WriteLine("Bonus checkbox load failed");
                        }

                    }
                }

                path = defaultPath + @"\Save\NPCS";
                if (sender.session.settings.UserAutoSaveDirectory != "")
                {
                    path = sender.session.settings.UserAutoSaveDirectory + @"\NPCS";
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
                LoadDefaultSkills(sender);
                

                path = defaultPath + @"\Save\Status.bin";
                if (sender.session.settings.UserAutoSaveDirectory != "")
                {
                    path = sender.session.settings.UserAutoSaveDirectory + @"\Status.bin";
                }

                List<Status> recent = LoadRecentlyUsedStatuses(path, sender);
                sender.recentlyUsedStatuses = recent;
                return fighters;
            }

            
        }

        public void ExportLog(string log, Settings settings)
        {
            string logPath = defaultPath + @"\Save\Log\";
            if (settings.UserLogDirectory != "")
            {
                logPath = settings.UserLogDirectory;
            }

            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }
            string path = logPath + "\\" + DateTime.Now.ToString("yyyy_MM_dd")+ ".txt";

            int fileDupCount = 1;
            string dupTestPath = path;
            while(File.Exists(dupTestPath))
            {
                fileDupCount++;
                dupTestPath = Path.GetDirectoryName(path) + @"\" + Path.GetFileNameWithoutExtension(path) + "_" + fileDupCount + ".txt";
            }
            path = dupTestPath;

            File.WriteAllText(path, log);

        }

        private void CreateDefaultSkillsFile(string path)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Acrobatics,1");
            sb.AppendLine("Appraise,3");
            sb.AppendLine("Bluff,5");
            sb.AppendLine("Climb,0");
            sb.AppendLine("Craft,3");
            sb.AppendLine("Craft,3");
            sb.AppendLine("Craft,3");
            sb.AppendLine("Diplomacy,5");
            sb.AppendLine("Disable Device,1");
            sb.AppendLine("Disguise,5");
            sb.AppendLine("Escape Artist,1");
            sb.AppendLine("Fly,1");
            sb.AppendLine("Handle Animal,5");
            sb.AppendLine("Heal,4");
            sb.AppendLine("Intimidate,5");
            sb.AppendLine("Knowledge (Arcana),3");
            sb.AppendLine("Knowledge (Dungeoneering),3");
            sb.AppendLine("Knowledge (Engineering),3");
            sb.AppendLine("Knowledge (Geography),3");
            sb.AppendLine("Knowledge (History),3");
            sb.AppendLine("Knowledge (Local),3");
            sb.AppendLine("Knowledge (Nature),3");
            sb.AppendLine("Knowledge (Nobility),3");
            sb.AppendLine("Knowledge (Planes),3");
            sb.AppendLine("Knowledge (Religion),3");
            sb.AppendLine("Linguistics,3");
            sb.AppendLine("Perception,4");
            sb.AppendLine("Perform,5");
            sb.AppendLine("Perform,5");
            sb.AppendLine("Profession,4");
            sb.AppendLine("Profession,4");
            sb.AppendLine("Ride,1");
            sb.AppendLine("Sense Motive,4");
            sb.AppendLine("Sleight of Hand,1");
            sb.AppendLine("Spellcraft,3");
            sb.AppendLine("Stealth,1");
            sb.AppendLine("Survival,4");
            sb.AppendLine("Swim,0");
            sb.AppendLine("Use Magic Device,5");
            File.WriteAllText(path, sb.ToString());
        }

        public void LoadDefaultSkills(MainWindow sender)
        {
            string path = defaultPath + @"\Save\DefaultSkillLoadout.txt";
            if (sender.session.settings.UserAutoSaveDirectory != "")
            {
                path = sender.session.settings.UserAutoSaveDirectory + @"\DefaultSkillLoadout.txt";
            }

            if (!File.Exists(path))
            {
                CreateDefaultSkillsFile(path);
            }

            string[] skillLines = File.ReadAllLines(path);
            List<Skill> defaultSkills = new List<Skill>();
            for (int i = 0; i < skillLines.Length; i++)
            {
                Skill loadSkill = LoadSkills(skillLines[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
                if (loadSkill != null)
                {
                    defaultSkills.Add(loadSkill);
                }
            }
            if (defaultSkills.Count > 0)
            {
                sender.session.settings.defaultSkillLoadout = defaultSkills;
            }
            else
            {
                MessageBox.Show("Unable to load default skillset.", "Error!");
            }
        }
        public void SaveStatBlock(string path, Fighter f)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            if (path != null)
            {
                bool append = false;
                using (Stream stream = File.Open(path, append ? FileMode.Append : FileMode.Create))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    binaryFormatter.Serialize(stream, f);
                }
            }
            else
            {
                MessageBox.Show("Save path was null", "Error!");
            }
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine(RemoveForbiddenCharacters(f.Name));//0
            //sb.AppendLine(f.InitBonus.ToString()); //1

            //sb.AppendLine(f.HP.ToString()); //2
            //sb.AppendLine(f.HPMult.ToString()); //3
            //sb.AppendLine(f.HPDieType.ToString());//4
            //sb.AppendLine(f.HPAdd.ToString());//5

            //sb.AppendLine(f.AC.ToString());//6
            //sb.AppendLine(f.FlatFootedAC.ToString());//7
            //sb.AppendLine(f.TouchAC.ToString());//8

            

            //sb.AppendLine(f.CMB.ToString());//9
            //sb.AppendLine(f.CMD.ToString());//10

            //sb.AppendLine(f.fort.ToString());//11
            //sb.AppendLine(f.reflex.ToString());//12
            //sb.AppendLine(f.will.ToString());//13

            //sb.AppendLine("|AttackStart|");
            //foreach (Attack atk in f.attacks)
            //{
            //    sb.AppendLine(atk.name); //i
            //    sb.AppendLine(atk.atkBonus.ToString());//i + 1
            //    sb.AppendLine(atk.dieAmt.ToString());//i + 2
            //    sb.AppendLine(atk.dieType.ToString());//i +3
            //    sb.AppendLine(atk.dmgBonus.ToString());//i + 4
            //    sb.AppendLine(atk.CritMin.ToString()); //i + 5
            //    sb.AppendLine(atk.CritMult.ToString()); //i + 6
            //    sb.AppendLine("Attack Bonus Count :" + atk.atkBonuses.Count);
            //    foreach (int i in atk.atkBonuses)
            //    {
            //        sb.AppendLine(i.ToString());
            //    }
            //}
            //sb.AppendLine("|AbilityStart|");
            //sb.AppendLine(f.Str.ToString());
            //sb.AppendLine(f.Dex.ToString());
            //sb.AppendLine(f.Con.ToString());
            //sb.AppendLine(f.Int.ToString());
            //sb.AppendLine(f.Wis.ToString());
            //sb.AppendLine(f.Cha.ToString());

            //sb.AppendLine("|SkillStart|");
            //sb.AppendLine("SkillCount:" + f.skills.Count);
            //foreach(Skill s in f.skills)
            //{
            //    sb.AppendLine(s.name + "," + s.abilityMod.ToString() + "," + s.abilitySource + "," + s.ranks.ToString() + "," + s.miscMod.ToString() + "," + s.isClassSkill.ToString());
            //}

            //File.WriteAllText(path, sb.ToString());

        }

        public Fighter LoadStatBlock(string path)
        {
            try
            {
                using (Stream stream = File.Open(path, FileMode.Open))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    Fighter newFighter = (Fighter)binaryFormatter.Deserialize(stream);
                    return newFighter;
                }
            }
            catch
            {
                //legacy loader 
                try
                {
                    string[] lines = File.ReadAllLines(path);
                    Fighter newFighter = new Fighter(lines[0], Int32.Parse(lines[1]), false);
                    newFighter.savePath = path;
                    int attackStart = 14;
                    int attackEnd = lines.Length;
                    int abilityStart = attackEnd + 1;
                    int abilityEnd = lines.Length;
                    int skillStart = abilityEnd + 1;
                    int skillEnd = lines.Length;

                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i] == "|AttackStart|")
                        {
                            attackStart = i + 1;
                        }
                        if (lines[i] == "|AbilityStart|")
                        {
                            attackEnd = i;
                            abilityStart = i + 1;
                        }
                        if (lines[i] == "|SkillStart|")
                        {
                            abilityEnd = i;
                            skillStart = i + 1;
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
                    if (abilityStart < lines.Length)
                    {
                        newFighter.Str = Int32.Parse(lines[abilityStart]);
                        newFighter.Dex = Int32.Parse(lines[abilityStart + 1]);
                        newFighter.Con = Int32.Parse(lines[abilityStart + 2]);
                        newFighter.Int = Int32.Parse(lines[abilityStart + 3]);
                        newFighter.Wis = Int32.Parse(lines[abilityStart + 4]);
                        newFighter.Cha = Int32.Parse(lines[abilityStart + 5]);
                    }

                    if (skillStart < lines.Length)
                    {
                        int skillLength = 0;
                        try
                        {
                            skillLength = Int32.Parse(lines[skillStart].Split(':')[1]);
                        }
                        catch
                        {
                            Console.WriteLine("Unable to determine amount of skills");
                        }

                        if (skillLength > 0)
                        {
                            List<Skill> newSkills = new List<Skill>();
                            for (int i = skillStart + 1; i < skillEnd; i++)
                            {
                                string[] skillStrings = lines[i].Split(',');
                                try
                                {
                                    string name = skillStrings[0];
                                    int abilityMod = Int32.Parse(skillStrings[1]);
                                    string abilitySource = skillStrings[2];
                                    int ranks = Int32.Parse(skillStrings[3]);
                                    int miscMod = Int32.Parse(skillStrings[4]);
                                    bool isClassSkill = Boolean.Parse(skillStrings[5]);

                                    Skill newSkill = new Skill(name);
                                    newSkill.abilityMod = abilityMod;
                                    newSkill.abilitySource = abilitySource;
                                    newSkill.ranks = ranks;
                                    newSkill.miscMod = miscMod;
                                    newSkill.isClassSkill = isClassSkill;

                                    newSkills.Add(newSkill);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Skill load failed at line " + i);
                                }
                            }
                            newFighter.skills = newSkills;
                        }
                    }
                    return newFighter;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Stat Block Load Failed");
                    return null;
                }
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

        private Skill LoadSkills(string[] skillLine)
        {
            List<Skill> defaultSkills = new List<Skill>();
            try
            {
                string name = skillLine[0];
                int ability = Int32.Parse(skillLine[1]);

                Skill newSkill = new Skill(name);
                switch(ability)
                {
                    case 0: newSkill.abilitySource = "Str"; break;
                    case 1: newSkill.abilitySource = "Dex"; break;
                    case 2: newSkill.abilitySource = "Con"; break;
                    case 3: newSkill.abilitySource = "Int"; break;
                    case 4: newSkill.abilitySource = "Wis"; break;
                    default: newSkill.abilitySource = "Cha"; break;
                }
                return newSkill;
            }
            catch
            {
                Console.WriteLine("Unable to load default skillset.");
                return null;
            }
        }

        public void SaveRecentlyUsedStatuses(List<Status> statuses, Settings settings)
        {
            string statusPath = defaultPath + @"\Save\Status.bin";
            if (settings.UserAutoSaveDirectory != "")
            {
                statusPath = settings.UserAutoSaveDirectory + @"\Status.bin";
            }
            if (File.Exists(statusPath))
            {
                File.Delete(statusPath);
            }

                bool append = false;
                using (Stream stream = File.Open(statusPath, append ? FileMode.Append : FileMode.Create))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    binaryFormatter.Serialize(stream, statuses);
                }

        }

        private List<Status> LoadRecentlyUsedStatuses(string path, MainWindow output)
        {
            try
            {
                using (Stream stream = File.Open(path, FileMode.Open))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    List<Status> statuses = (List<Status>)binaryFormatter.Deserialize(stream);
                    return statuses;
                }
            }
            catch
            {
                output.WriteToLog("There was an error loading the autosave. Not a big deal. Should be fixed next time you launch the program.");
                return new List<Status>();
            }
        }

        public bool SaveObject<T>(object obj, string FilePath)
        {
            if(File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }
            try
            {
            var xs = new XmlSerializer(typeof(T));
            
                using (TextWriter sw = new StreamWriter(FilePath))
                {
                    xs.Serialize(sw, obj);
                }
                return true;
            }
            catch (Exception ex)
            {
                FilePath = Path.GetDirectoryName(FilePath);
                FilePath += @"\errorLog.txt";
                string Message = ex.Message + "\n" + ex.InnerException.Message;
                //Message += "\n" + ex.InnerException.InnerException.Message;// +"\n" + ex.InnerException.InnerException.InnerException.Message;
                SaveObject<string>(Message, FilePath);
                return false;
            }
           
        }

        public T LoadObject<T>(string FileName)
        {
            Object rslt;

            if (File.Exists(FileName))
            {
                var xs = new XmlSerializer(typeof(T));

                using (var sr = new StreamReader(FileName))
                {
                    try
                    {
                        rslt = (T)xs.Deserialize(sr);
                    }
                    catch
                    {
                        rslt = null;
                    }
                }
                return (T)rslt;
            }
            else
            {
                return default(T);
            }
        }

        public Settings LoadAutoSettings()
        {
            Settings output = new Settings();
            string filename = Program.defaultPath + @"\Settings.xml";
            output = LoadObject<Settings>(filename);
            if (output == null)
                output = new Settings();
            Program.activeSettings = output;
            return output;
        }

        public void SaveAutoSettings(Settings input)
        {
            string filename = Program.defaultPath + @"\Settings.xml";
            SaveObject<Settings>(input, filename);
        }

        public bool ValidateFilePaths(List<string> paths)
        {
            bool ok = true;
            foreach(string candidate in paths)
            {
                if(!Directory.Exists(candidate))
                {
                    ok = false;
                }
            }
            return ok;
        }
        

        public void AutoSaveDPercentList(List<DPercentTable> Tables, Settings settings)
        {
            string autoPath = defaultPath + @"\Save\DPercent.xml";
            if (settings.UserAutoSaveDirectory != "")
            {
                autoPath = settings.UserAutoSaveDirectory;
                autoPath += @"\DPercent.xml";
            }

            SaveObject<List<DPercentTable>>(Tables, autoPath);
        }

        public List<DPercentTable> AutoLoadDPercent(Settings settings)
        {
            string autoPath = defaultPath + @"\Save\DPercent.xml";
            List<DPercentTable> output;
            if (settings.UserAutoSaveDirectory != "")
            {
                autoPath = settings.UserAutoSaveDirectory;
                autoPath += @"\DPercent.xml";
            }
            try
            {
                output = LoadObject<List<DPercentTable>>(autoPath);
            }
            catch
            {
                output = new List<DPercentTable>();
            }
            return output;
        }

        public void PassSettings(Settings passedSettings)
        {
            saveSettings = passedSettings;
        }

        
    }

    
}
