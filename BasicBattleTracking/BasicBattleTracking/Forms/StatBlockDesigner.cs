using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BasicBattleTracking
{
    public partial class StatBlockDesigner : Form
    {
        private bool saved { get; set; }
        private string savePath { get; set; }
        public MainWindow parent { get; set; }
        private AttackDesigner ad;
        private List<Attack> attacks;
        private string mostRecentPath = "";
        private Random randy;
        private bool userPopulated = true;
        private Fighter editFighter;

        public List<Skill> skillList { get; set; }
        private bool editMode { get; set; }
        
        public StatBlockDesigner()
        {
            attacks = new List<Attack>();
            skillList = new List<Skill>();
            
            randy = new Random();
            InitializeComponent();
            dBox.SelectedIndex = 0;
        }

        private void StatBlockDesigner_Load(object sender, EventArgs e)
        {
            dBox.SelectedIndex = 0;
            ad = new AttackDesigner(this);
            nameBox.Select();
            
        }

        private void A1NameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Fighter newFighter = BuildFighter();
            if (newFighter != null)
            {
                Save(newFighter);
            }
        }

        private Fighter BuildFighter()
        {
            Fighter newFighter;
            string errorMessage = "";
            bool errorFlag = false;

            string name = nameBox.Text;
            if(name == "")
            {
                errorMessage += "Fighter must have a name.";
                errorFlag = true;
            }

            int initBonus = 0;
            try
            {
                
                initBonus = Int32.Parse(InitBox.Text);
            }
            catch
            {
                errorMessage += "\nInitiative bonus must be a number.";
                errorFlag = true;
            }
            if (editMode)
            {
                newFighter = editFighter;
                newFighter.Name = name;
                newFighter.InitBonus = initBonus;
            }
            else
            {
                newFighter = new Fighter(name, initBonus, false);
            }
            newFighter.Notes = bioBox.Text;
            int HP = 0;
            if (formulaButton.Checked)
            {
                HP = rollHP();
                int HPMult = 0;
                int HPDieType = 0;
                int HPAdd = 0;
                try
                {
                    HPMult = Int32.Parse(multBox.Text);
                    HPAdd = Int32.Parse(addBox.Text);
                }
                catch
                {
                    errorMessage += "\nBad HP formula.";
                    errorFlag = true;
                }
                

                switch (dBox.SelectedIndex)
                {
                    case 0: HPDieType = 4; break;
                    case 1: HPDieType = 6; break;
                    case 2: HPDieType = 8; break;
                    case 3: HPDieType = 10; break;
                    default: HPDieType = 12; break;

                }

                newFighter.HPDieType = HPDieType;
                newFighter.HPMult = HPMult;
                newFighter.HPAdd = HPAdd;
                newFighter.HP = HP;
                
            }
            else
            {
                try
                {
                    int HPMult = 0;
                    int HPDieType = 0;
                    int HPAdd = 0;
                    try
                    {
                        HPMult = Int32.Parse(multBox.Text);
                        HPAdd = Int32.Parse(addBox.Text);
                        switch (dBox.SelectedIndex)
                        {
                            case 0: HPDieType = 4; break;
                            case 1: HPDieType = 6; break;
                            case 2: HPDieType = 8; break;
                            case 3: HPDieType = 10; break;
                            default: HPDieType = 12; break;

                        }
                        newFighter.HPDieType = HPDieType;
                    }
                    catch { Console.WriteLine("No valid HP formula found."); }
                    HP = Int32.Parse(HPValBox.Text);
                    if (HP < 0)
                    {
                        errorFlag = true;
                        errorMessage += "\nHP cannot be less than 0";
                    }
                    newFighter.HP = HP;
                }
                catch
                {
                    errorFlag = true;
                    errorMessage += "\nInvalid HP value";
                }
            }

            if (!editMode)
                newFighter.MaxHP = HP;

            try
            {
                newFighter.AC = Int32.Parse(ACValBox.Text);
                newFighter.FlatFootedAC = Int32.Parse(FFBox.Text);
                newFighter.TouchAC = Int32.Parse(touchBox.Text);
                newFighter.CMB = Int32.Parse(CMBBox.Text);
                newFighter.CMD = Int32.Parse(CMDBox.Text);
                newFighter.Fort.total = Int32.Parse(fortBox.Text);
                newFighter.Reflex.total = Int32.Parse(refBox.Text);
                newFighter.Will.total = Int32.Parse(willBox.Text);
                newFighter.SpellResist = Int32.Parse(srBox.Text);
                newFighter.DamageReduce = Int32.Parse(drBox.Text);


                int str = 0;
                int dex = 0;
                int con = 0;
                int intel = 0;
                int wis = 0;
                int cha = 0;

                try
                {
                    str = Int32.Parse(strBox.Text);
                    dex = Int32.Parse(dexBox.Text);
                    con = Int32.Parse(conBox.Text);
                    intel = Int32.Parse(intBox.Text);
                    wis = Int32.Parse(wisBox.Text);
                    cha = Int32.Parse(chaBox.Text);
                }
                catch
                {
                    errorFlag = true;
                    errorMessage += "\nOne or more ability scores is not valid";
                }

                newFighter.Str = str;
                newFighter.Dex = dex;
                newFighter.Con = con;
                newFighter.Int = intel;
                newFighter.Wis = wis;
                newFighter.Cha = cha;

            }
            catch
            {
                errorMessage += "\nPlease enter numerical values for all stats";
                errorFlag = true;
            }
            newFighter.attacks = this.attacks;
            newFighter.skills = this.skillList;

            if (errorFlag)
            {
                MessageBox.Show(errorMessage, "Error!");
                return null;
            }
            else
            {
                return newFighter;
            }
        }

        private void SaveInsertButton_Click(object sender, EventArgs e)
        {
            Fighter newFighter = BuildFighter();
            if (newFighter == null)
            {
                return;
            }
            else
            {
                Save(newFighter);

                int insertCount = 1;
                try
                {
                    insertCount = Int32.Parse(iCountBox.Text);
                }
                catch
                {
                    insertCount = 1;
                }

                for (int i = 0; i < insertCount; i++)
                {
                    newFighter = BuildFighter();
                    if (newFighter != null)
                    {
                        newFighter.Name += " " + (i + 1).ToString();
                        Insert(newFighter);
                    }
                }
                this.Close();
            }


        }

        private void Save(Fighter newFighter)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".bin";
            string initialPath = Program.defaultPath + @"\Stat Blocks";

            if (mostRecentPath != "")
            {
                initialPath = mostRecentPath;
            }
            else
            {
                if (parent.session.settings.UserStatBlockDirectory != "")
                {
                    initialPath = parent.session.settings.UserStatBlockDirectory;
                }
            }

            if (!Directory.Exists(initialPath))
            {
                Directory.CreateDirectory(initialPath);
            }
            save.InitialDirectory = initialPath;

            
            if (newFighter != null)
            {
                if (!saved)
                {
                    DialogResult confirm = save.ShowDialog();
                    if (confirm == DialogResult.OK)
                    {
                        savePath = save.FileName;
                        BattleIO saver = new BattleIO();
                        saver.SaveStatBlock(savePath, newFighter);
                        saved = true;
                        mostRecentPath = Path.GetDirectoryName(save.FileName);
                    }
                }
                else
                {
                   
                    BattleIO saver = new BattleIO();
                    saver.SaveStatBlock(savePath, newFighter);
                }
            }
            
        }

        private void Insert(Fighter newFighter)
        {
            if (!editMode)
            {
                parent.AddFighter(newFighter);
                parent.WriteToLog("Added " + newFighter.Name + ".");
            }
            else
            {
                parent.UpdateFighter(newFighter);
                parent.WriteToLog(newFighter.Name + " updated.");
            }
        }

        private void A1Dtype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog load = new OpenFileDialog();
            string initialPath = Program.defaultPath + @"\Stat Blocks";

            if (mostRecentPath != "")
            {
                initialPath = mostRecentPath;
            }
            else
            {
                if (parent.session.settings.UserStatBlockDirectory != "")
                {
                    initialPath = parent.session.settings.UserStatBlockDirectory;
                }
            }

            if (!Directory.Exists(initialPath))
            {
                Directory.CreateDirectory(initialPath);
            }
            load.InitialDirectory = initialPath;
            DialogResult confirm = load.ShowDialog();
            if (confirm == DialogResult.OK)
            {
                BattleIO loader = new BattleIO();
                Fighter newFighter = loader.LoadStatBlock(load.FileName);

                savePath = load.FileName;

                mostRecentPath = Path.GetDirectoryName(load.FileName);
                LoadFighter(load.FileName);
                
            }

        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            int insertCount = 0;
            try
            {
                insertCount = Int32.Parse(iCountBox.Text);
            }
            catch
            {
                insertCount = 1;
            }
            bool close = true;
            for (int i = 0; i < insertCount; i++)
            {
                Fighter newFighter = BuildFighter();

                if (newFighter != null)
                {
                    Insert(newFighter);
                    if (insertCount > 1)
                    {
                        newFighter.Name += " " + (i + 1).ToString();
                    }
                }
                else
                {
                    close = false;
                }

            }
            if(close)
            this.Close();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CancButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ad = new AttackDesigner(this);
            if(attacks.Count > 0)
            {
                ad.LoadAttacks(attacks);
            }
            ad.Show();
        }

        public void SetAttacks(List<Attack> attackList)
        {
            attacks = attackList;
            attackCountLabel.Text = attacks.Count + " attacks";
        }

        private void valueButton_CheckedChanged(object sender, EventArgs e)
        {
            if (valueButton.Checked)
            {
                multBox.Enabled = false;
                dBox.Enabled = false;
                addBox.Enabled = false;

                HPValBox.ReadOnly = false;
            }
        }

        private void formulaButton_CheckedChanged(object sender, EventArgs e)
        {
            if (formulaButton.Checked)
            {
                multBox.Enabled = true;
                dBox.Enabled = true;
                addBox.Enabled = true;

                HPValBox.ReadOnly = true;
            }
        }
        private int rollHP()
        {
            int HP = 0;
            int HPMult = 0;
            int HPDieType = 0;
            int HPAdd = 0;
            try
            {
                HPMult = Int32.Parse(multBox.Text);
            }
            catch
            {
                HPMult = 0;
            }
            try
            {
                HPAdd = Int32.Parse(addBox.Text);
            }
            catch
            {
                HPAdd = 0;
            }

                switch (dBox.SelectedIndex)
                {
                    case 0: HPDieType = 4; break;
                    case 1: HPDieType = 6; break;
                    case 2: HPDieType = 8; break;
                    case 3: HPDieType = 10; break;
                    default: HPDieType = 12; break;

                }

                int hitDieHP = 0;

                    for (int i = 0; i < HPMult; i++)
                    {
                        int temp = 0;
                        lock (randy)
                        {
                            temp = randy.Next(HPDieType);
                        }
                        hitDieHP += temp;
                    }
                
                HP = hitDieHP + HPAdd;
                System.Threading.Thread.Sleep(1);
            
            return HP;
        }
        private void multBox_TextChanged(object sender, EventArgs e)
        {
            if (userPopulated)
            {
                HPValBox.Text = rollHP().ToString();
            }
        }

        private void dBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (userPopulated)
            {
                HPValBox.Text = rollHP().ToString();
            }
        }

        private void addBox_TextChanged(object sender, EventArgs e)
        {
            if (userPopulated)
            {
                HPValBox.Text = rollHP().ToString();
            }
        }

        private void strBox_TextChanged(object sender, EventArgs e)
        {
            displayMod(strBox, strModBox);
        }


        private void displayMod(TextBox inputBox, TextBox outputBox)
        {
            int score = 0;
            try
            {
                score = Int32.Parse(inputBox.Text);
            }
            catch 
            {
                return;
            }

            int mod = Program.getAbilityMod(score);

            if (mod >= 0)
            {
                outputBox.Text = "+" + mod.ToString();
                outputBox.ForeColor = SystemColors.WindowText;
            }
            else
            {
                outputBox.Text = "-" + mod.ToString();
                outputBox.ForeColor = Color.Red;
            }
            

        }

        private void dexModBox_TextChanged(object sender, EventArgs e)
        {
            //displayMod(dexBox, dexModBox);
        }

        private void conModBox_TextChanged(object sender, EventArgs e)
        {
            //displayMod(conBox, conModBox);
        }

        private void intModBox_TextChanged(object sender, EventArgs e)
        {
            //displayMod(intBox, intModBox);
        }

        private void wisModBox_TextChanged(object sender, EventArgs e)
        {
            //displayMod(wisBox, wisModBox);
        }

        private void chaModBox_TextChanged(object sender, EventArgs e)
        {
            //displayMod(chaBox, chaModBox);
        }

        private void wisBox_TextChanged(object sender, EventArgs e)
        {
            displayMod(wisBox, wisModBox);
        }

        private void dexBox_TextChanged(object sender, EventArgs e)
        {
            displayMod(dexBox, dexModBox);
        }

        private void conBox_TextChanged(object sender, EventArgs e)
        {
            displayMod(conBox, conModBox);
        }

        private void intBox_TextChanged(object sender, EventArgs e)
        {
            displayMod(intBox, intModBox);
        }

        private void chaBox_TextChanged(object sender, EventArgs e)
        {
            displayMod(chaBox, chaModBox);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SkillDesigner skillMaker = new SkillDesigner();
            skillMaker.ParentWindow = this;
            List<int> abilityMods = new List<int>();
            try
            {
                abilityMods.Add(Program.getAbilityMod(Int32.Parse(strBox.Text)));
                abilityMods.Add(Program.getAbilityMod(Int32.Parse(dexBox.Text)));
                abilityMods.Add(Program.getAbilityMod(Int32.Parse(conBox.Text)));
                abilityMods.Add(Program.getAbilityMod(Int32.Parse(intBox.Text)));
                abilityMods.Add(Program.getAbilityMod(Int32.Parse(wisBox.Text)));
                abilityMods.Add(Program.getAbilityMod(Int32.Parse(chaBox.Text)));
            }
            catch
            {
                Console.WriteLine("Missing ability scores to add to skills");
            }


            skillMaker.SetAbilityMods(abilityMods);
            if(skillList.Count > 0)
            {
                skillMaker.PopulateSkillLines(skillList);
            }
            else
            {
                skillMaker.PopulateSkillLines(parent.session.settings.defaultSkillLoadout);
            }
            skillMaker.Show();
        }

        public void SetSkillList(List<Skill> inputList)
        {
            skillList = inputList;
            skillCountLabel.Text = skillList.Count.ToString() +" Skills";
        }

        private void LoadFighter(string path)
        {
            BattleIO loader = new BattleIO();
            Fighter newFighter = loader.LoadStatBlock(path);

            savePath = path;

            mostRecentPath = Path.GetDirectoryName(path);
                userPopulated = false;
                nameBox.Text = newFighter.Name;
                HPValBox.Text = newFighter.HP.ToString();
                multBox.Text = newFighter.HPMult.ToString();
                addBox.Text = newFighter.HPAdd.ToString();
                dBox.Text = newFighter.HPDieType.ToString();
                ACValBox.Text = newFighter.AC.ToString();
                FFBox.Text = newFighter.FlatFootedAC.ToString();
                touchBox.Text = newFighter.TouchAC.ToString();
                InitBox.Text = newFighter.InitBonus.ToString();
                CMBBox.Text = newFighter.CMB.ToString();
                CMDBox.Text = newFighter.CMD.ToString();
                fortBox.Text = newFighter.fort.ToString();
                refBox.Text = newFighter.reflex.ToString();
                willBox.Text = newFighter.will.ToString();
                attacks = newFighter.attacks;
                attackCountLabel.Text = newFighter.attacks.Count + " attacks.";
                skillCountLabel.Text = newFighter.skills.Count + " skills.";
                skillList = newFighter.skills;
                strBox.Text = newFighter.Str.ToString();
                dexBox.Text = newFighter.Dex.ToString();
                conBox.Text = newFighter.Con.ToString();
                intBox.Text = newFighter.Int.ToString();
                wisBox.Text = newFighter.Wis.ToString();
                chaBox.Text = newFighter.Cha.ToString();
                srBox.Text = newFighter.SpellResist.ToString();
                drBox.Text = newFighter.DamageReduce.ToString();
                bioBox.Text = newFighter.Notes;
                userPopulated = true;
                saved = true;
        }
        public void InitiateFighter(Fighter newFighter)
        {
            
            userPopulated = false;
            nameBox.Text = newFighter.Name;
            HPValBox.Text = newFighter.HP.ToString();
            multBox.Text = newFighter.HPMult.ToString();
            addBox.Text = newFighter.HPAdd.ToString();
            dBox.Text = newFighter.HPDieType.ToString();
            ACValBox.Text = newFighter.AC.ToString();
            FFBox.Text = newFighter.FlatFootedAC.ToString();
            touchBox.Text = newFighter.TouchAC.ToString();
            InitBox.Text = newFighter.InitBonus.ToString();
            CMBBox.Text = newFighter.CMB.ToString();
            CMDBox.Text = newFighter.CMD.ToString();
            fortBox.Text = newFighter.fort.ToString();
            refBox.Text = newFighter.reflex.ToString();
            willBox.Text = newFighter.will.ToString();
            attacks = newFighter.attacks;
            attackCountLabel.Text = newFighter.attacks.Count + " attacks.";
            skillCountLabel.Text = newFighter.skills.Count + " skills.";
            skillList = newFighter.skills;
            strBox.Text = newFighter.Str.ToString();
            dexBox.Text = newFighter.Dex.ToString();
            conBox.Text = newFighter.Con.ToString();
            intBox.Text = newFighter.Int.ToString();
            wisBox.Text = newFighter.Wis.ToString();
            chaBox.Text = newFighter.Cha.ToString();
            drBox.Text = newFighter.DamageReduce.ToString();
            srBox.Text = newFighter.SpellResist.ToString();
            bioBox.Text = newFighter.Notes;
            userPopulated = true;
            editFighter = newFighter;
            if(File.Exists(newFighter.savePath))
            {
                saved = true;
                mostRecentPath = Path.GetDirectoryName(newFighter.savePath);
                savePath = newFighter.savePath;
            }

            SaveInsertButton.Text = "Save and Update";
            InsertButton.Text = "Update";
            editMode = true;
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
