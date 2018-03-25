using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using BasicBattleTracking.Forms.UserControls;

namespace BasicBattleTracking
{
    public partial class CharacterSheet : Form
    {
        public CharacterSheet()
        {
            InitializeComponent();
            HP.TextChanged += new EventHandler(UpdateValueFromTextBox);
            diceTab1.sheet = this;

        }

        private Fighter Character { get; set; }
        private MainWindow DMForm { get; set; }

        private void CharacterSheet_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(MaxHP, "Restore current HP to total HP");
            if (DMForm != null)
                attackControl2.parentForm = DMForm;
            attackControl2.sheetForm = this;
        }

        public void SendFighter(Fighter input)
        {
            Character = input;
            this.Text = input.Name + "'s Character Sheet";
            this.FormClosing += new FormClosingEventHandler(OnClosing);
            DisplayCharacterInfo();
        }

        public void SendTracker(MainWindow sender)
        {
            DMForm = sender;
        }

        private void DisplayCharacterInfo()
        {
            NameBox.Text = Character.Name;
            PropertyInfo[] charProps = Character.GetType().GetProperties();
            attackControl2.InitializeAttacks(Character);
            skillsTab1.SetActiveFighter(Character);
            skillsTab1.UpdateSkillsList();
            skillsTab1.sendingSheet = this;
            foreach(Control c in GetAll(this, typeof(TextBox)))
            {
                    TextBox next = c as TextBox;
                    for(int i = 0; i < charProps.Length; i++)
                    {
                        if (charProps[i].Name == next.Name && Character.GetType().GetProperty(next.Name) != null)
                        {
                            next.Text = Character.GetType().GetProperty(next.Name).GetValue(Character, null).ToString();
                        }
                    }
            }
            Character.Fort.abilityMod = Program.getAbilityMod(Character.Con);
            Character.Reflex.abilityMod = Program.getAbilityMod(Character.Dex);
            Character.Will.abilityMod = Program.getAbilityMod(Character.Wis);
            fortAbil.Text = Character.Fort.abilityMod.ToString();
            fortRanks.Text = Character.Fort.baseVal.ToString();
            refAbil.Text = Character.Reflex.abilityMod.ToString();
            RefRanks.Text = Character.Reflex.baseVal.ToString();
            willAbil.Text = Character.Will.abilityMod.ToString();
            willRanks.Text = Character.Will.baseVal.ToString();

            


            Fort.Text = Character.Fort.total.ToString();
            Reflex.Text = Character.Reflex.total.ToString();
            Will.Text = Character.Will.total.ToString();

            
            
        }

        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAll(ctrl, type)).Concat(controls).Where(c => c.GetType() == type);
        }
    

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            Character.Name = NameBox.Text;
            this.Text = Character.Name + "'s Character Sheet";
            if (DMForm != null)
            {
                DMForm.UpdateFighter(Character);
            }
        }

        private void UpdateValueFromTextBox(object sender, EventArgs e)
        {
            TextBox Sender = sender as TextBox;
            PropertyInfo property = Character.GetType().GetProperty(Sender.Name);

            try
            {
                property.SetValue(Character, Convert.ChangeType(Sender.Text, property.PropertyType ), null);
                if (DMForm != null)
                {
                    DMForm.UpdateFighter(Character);
                }

                
            }
            catch
            {
                //Debug
            }
            finally
            {
                switch (Sender.Name)
                {
                    case "Str": DisplayMod(Sender, strModBox); break;
                    case "Dex": DisplayMod(Sender, dexModBox); break;
                    case "Con": DisplayMod(Sender, conModBox); break;
                    case "Int": DisplayMod(Sender, intModBox); break;
                    case "Wis": DisplayMod(Sender, wisModBox); break;
                    case "Cha": DisplayMod(Sender, chaModBox); break;
                    case "tempStr": DisplayMod(Sender, tempstrModBox); break;
                    case "tempDex": DisplayMod(Sender, tempdexModBox); break;
                    case "tempCon": DisplayMod(Sender, tempconModBox); break;
                    case "tempInt": DisplayMod(Sender, tempintModBox); break;
                    case "tempWis": DisplayMod(Sender, tempwisModBox); break;
                    case "tempCha": DisplayMod(Sender, tempchaModBox); break;
                    default: break;
                }
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void DisplayMod(TextBox inputBox, TextBox outputBox)
        {
            int score = 0;
            if(inputBox.Text == "")
            {
                outputBox.Text = "";
                score = -1;
            }
            try
            {
                score = Int32.Parse(inputBox.Text);
            }
            catch
            {
                outputBox.Text = "";
                return;
            }

            int mod = Program.getAbilityMod(score);
            if (score >= 0)
            {
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
            else
            {
                inputBox.Text = "";
                outputBox.Text = "";
            }
        }

        private void OnClosing(object sender, EventArgs e)
        {
            if(DMForm != null)
            {
                DMForm.Visible = true;
            }
        }

        public new void WriteToLog(string text)
        {
            logBox.AppendText(text);
            logBox.AppendText("\n");
            logBox.SelectionStart = logBox.Text.Length;
            logBox.ScrollToCaret();
        }

        private void diceTab1_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        public void LogAttack(int damage)
        {
            WriteToLog(Character.Name + " was attacked for " + damage + " damage!");
            DisplayCharacterInfo();
        }

        private void fortRanks_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Character.Fort.baseVal = Int32.Parse(fortRanks.Text);
                DisplayCharacterInfo();
            }
            catch{}
        }

        private void willRanks_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Character.Will.baseVal = Int32.Parse(willRanks.Text);
                DisplayCharacterInfo();
            }
            catch { }
        }

        private void RefRanks_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Character.Reflex.baseVal = Int32.Parse(RefRanks.Text);
                DisplayCharacterInfo();
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RollCheck("Fortitude", Character.Fort, FortResultBox);
        }

        private void RollCheck(string name, FighterDetail.Save save, TextBox output)
        {
            int result = save.RollSave();
            output.Text = result.ToString();
            WriteToLog(Character.Name + " made a " + name + " save of " + result.ToString() + "!");
            
        }

        private void rollRefButton_Click(object sender, EventArgs e)
        {
            RollCheck("Reflex", Character.Reflex, RefResultBox);
        }

        private void rollWillButton_Click(object sender, EventArgs e)
        {
            RollCheck("Will", Character.Will, WillResultBox);
        }
    }
}
