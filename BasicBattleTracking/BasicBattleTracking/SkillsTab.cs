using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicBattleTracking
{
    public partial class SkillsTab : UserControl
    {
        private Fighter activeFighter;
        private Skill selectedSkill;
        public MainWindow ParentWindow { get; set; }

        private bool skillIndexChanging = false;
        public SkillsTab()
        {
            InitializeComponent();
            activeFighter = null;
        }

        private void SkillsTab_Load(object sender, EventArgs e)
        {

        }

        public void SetActiveFighter(Fighter active)
        {
            activeFighter = active;
        }

        public void UpdateSkillsList()
        {
            skillList.Items.Clear();
            if(activeFighter != null)
            {
                if (activeFighter.skills.Count > 0)
                {
                    foreach (Skill s in activeFighter.skills)
                    {
                        skillList.Items.Add(new ListViewItem(new string[]{s.name, (s.abilityMod + s.ranks + s.miscMod).ToString() + "           (" + s.abilityMod + " + " +
                        s.ranks + " + " + s.miscMod + ")", s.isClassSkill.ToString()}));
                    }
                }
            }

            if(skillList.Items.Count <= 0)
            {
                skillCheckButton.Enabled = false;
            }
        }

        private void skillList_SelectedIndexChanged(object sender, EventArgs e)
        {
            skillIndexChanging = true;
            if (skillList.SelectedIndices.Count > 0)
            {
                if (skillList.SelectedIndices[0] < activeFighter.skills.Count)
                {
                    selectedSkill = activeFighter.skills.ElementAt(skillList.SelectedIndices[0]);
                    abilityBonusBox.Text = selectedSkill.abilityMod.ToString();
                    abilitySourceBox.Text = selectedSkill.abilitySource;
                    skillNameBox.Text = selectedSkill.name;
                    rankBonusBox.Text = selectedSkill.ranks.ToString();
                    miscBonusBox.Text = selectedSkill.miscMod.ToString();
                    classCheckBox.Checked = selectedSkill.isClassSkill;
                    skillCheckButton.Enabled = true;
                }
            }
            skillIndexChanging = false;
        }

        private void skillNameBox_TextChanged(object sender, EventArgs e)
        {
            if(selectedSkill != null)
            {
                try
                {
                    selectedSkill.name = skillNameBox.Text;
                    if (!skillIndexChanging)
                    UpdateSkillsList();
                }
                catch { Console.WriteLine("Unable to write back skill name change"); }
            }
        }

        private void abilitySourceBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedSkill != null)
            {
                try
                {
                    selectedSkill.abilitySource = abilitySourceBox.Text;
                    switch(abilitySourceBox.SelectedIndex)
                    {
                        case 0: abilityBonusBox.Text = Program.getAbilityMod(activeFighter.Str).ToString(); break;
                        case 1: abilityBonusBox.Text = Program.getAbilityMod(activeFighter.Dex).ToString(); break;
                        case 2: abilityBonusBox.Text = Program.getAbilityMod(activeFighter.Con).ToString(); break;
                        case 3: abilityBonusBox.Text = Program.getAbilityMod(activeFighter.Int).ToString(); break;
                        case 4: abilityBonusBox.Text = Program.getAbilityMod(activeFighter.Wis).ToString(); break;
                        default: abilityBonusBox.Text = Program.getAbilityMod(activeFighter.Cha).ToString(); break;
                    }
                    if(!skillIndexChanging)
                    UpdateSkillsList();
                }
                catch { Console.WriteLine("Unable to write back skill ability source change"); }
            }
        }

        private void abilityBonusBox_TextChanged(object sender, EventArgs e)
        {
            if (selectedSkill != null)
            {
                try
                {
                    selectedSkill.abilityMod = Int32.Parse(abilityBonusBox.Text);
                    if (!skillIndexChanging)
                    UpdateSkillsList();
                }
                catch { Console.WriteLine("Unable to write back ability bonus change"); }
            }
        }

        private void rankBonusBox_TextChanged(object sender, EventArgs e)
        {
            if (selectedSkill != null)
            {
                try
                {
                    selectedSkill.ranks = Int32.Parse(rankBonusBox.Text);
                    if(selectedSkill.isClassSkill && selectedSkill.ranks > 0 && !selectedSkill.classModifierApplied)
                    {
                        selectedSkill.miscMod += 3;
                        miscBonusBox.Text = selectedSkill.miscMod.ToString();
                        selectedSkill.classModifierApplied = true;
                    }

                    
                    if(selectedSkill.isClassSkill && selectedSkill.ranks <= 0 && selectedSkill.classModifierApplied)
                    {
                        selectedSkill.miscMod -= 3;
                        miscBonusBox.Text = selectedSkill.miscMod.ToString();
                        selectedSkill.classModifierApplied = false;
                    }
                    
                    if (!skillIndexChanging)
                    UpdateSkillsList();
                }
                catch { Console.WriteLine("Unable to write back ranks bonus change"); }
            }
        }

        private void miscBonusBox_TextChanged(object sender, EventArgs e)
        {
            if (selectedSkill != null)
            {
                try
                {
                    selectedSkill.miscMod = Int32.Parse(miscBonusBox.Text);
                    if (!skillIndexChanging)
                    UpdateSkillsList();
                }
                catch { Console.WriteLine("Unable to write back misc bonus change"); }
            }
        }

        private void classCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (selectedSkill != null)
            {
                try
                {
                    if(selectedSkill.isClassSkill && !classCheckBox.Checked && selectedSkill.classModifierApplied)
                    {
                        selectedSkill.miscMod -= 3;
                        selectedSkill.classModifierApplied = false;
                    }
                    if(!selectedSkill.isClassSkill && classCheckBox.Checked && selectedSkill.ranks > 0 && !selectedSkill.classModifierApplied)
                    {
                        selectedSkill.miscMod += 3;
                        selectedSkill.classModifierApplied = true;
                    }
                    selectedSkill.isClassSkill = classCheckBox.Checked;
                    miscBonusBox.Text = selectedSkill.miscMod.ToString();
                    if (!skillIndexChanging)
                    UpdateSkillsList();
                }
                catch { Console.WriteLine("Unable to write back class bonus change"); }
            }
        }

        private void skillCheckButton_Click(object sender, EventArgs e)
        {
            RollSkillCheck();
        }
        private void RollSkillCheck()
        {
            string shortName = selectedSkill.name.ToUpper();
            if (shortName.Length > 16)
            {
                shortName = shortName.Remove(15) + ")";
            }
            WriteToRollConsole("=====" + shortName + " CHECK=====");
            int result = selectedSkill.RollSkillCheck();
            d20Label.Text = selectedSkill.LastD20.ToString();
            WriteToRollConsole("Roll: " + selectedSkill.LastD20.ToString());
            WriteToRollConsole("Modifier: " + selectedSkill.totalModifier);
            atkModBox.Text = selectedSkill.totalModifier.ToString();
            WriteToRollConsole("");
            WriteToRollConsole("Total: " + result.ToString());
            WriteToRollConsole("");
            rollResultLabel.Text = result.ToString();
            ParentWindow.WriteToLog(activeFighter.Name + " made a " + selectedSkill.name + " check of " + result.ToString() + "!");
        }

        public void PrepareSkillCheck(int skillIndex)
        {
            if (skillIndex < activeFighter.skills.Count && skillIndex >= 0)
            {
                selectedSkill = activeFighter.skills.ElementAt(skillIndex);
                RollSkillCheck();
            }
        }
        public void WriteToRollConsole(string input)
        {
            rollBox.AppendText(input);
            rollBox.AppendText(Environment.NewLine);
        }

        public void UpdateSelectedSkill()
        {
            skillIndexChanging = true;
            if (selectedSkill != null)
            {
                abilityBonusBox.Text = selectedSkill.abilityMod.ToString();
                abilitySourceBox.Text = selectedSkill.abilitySource;
                skillNameBox.Text = selectedSkill.name;
                rankBonusBox.Text = selectedSkill.ranks.ToString();
                miscBonusBox.Text = selectedSkill.miscMod.ToString();
                classCheckBox.Checked = selectedSkill.isClassSkill;
            }
            skillCheckButton.Enabled = true;
        }
        public void ClearSkillList()
        {
            skillList.Items.Clear();
            selectedSkill = null;
            rankBonusBox.Text = "";
            abilityBonusBox.Text = "";
            abilitySourceBox.SelectedIndex = 0;
            miscBonusBox.Text = "";
        }
    }
}
