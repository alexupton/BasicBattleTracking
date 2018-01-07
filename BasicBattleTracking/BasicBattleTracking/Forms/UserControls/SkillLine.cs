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
    public partial class SkillLine : UserControl
    {
        private int total;
        private int abilityBonus;
        private int ranksBonus;
        private int miscBonus;
        private bool classSkill;
        public int skillID { get; set; }
        public SkillDesigner ParentWindow { get; set; }
        private bool classCheckAdded = false;

        private List<int> abilityMods{get; set;}
        public SkillLine(SkillDesigner sender)
        {
            ParentWindow = sender;
            InitializeComponent();
            abilitySourceBox.SelectedIndex = 0;
        }

        public SkillLine()
        {
            InitializeComponent();
        }

        private void SkillLine_Load(object sender, EventArgs e)
        {
            
        }

        public Skill GenerateSkill()
        {
            
            string name = "Unnamed skill";
            if(skillNameBox.Text != "")
            {
                name = skillNameBox.Text;
            }
            int abilityBonus = 0;
            string abilitySource = "";
            int ranks = 0;
            int miscMod = 0;

            try
            {
                abilityBonus = Int32.Parse(abilityBonusBox.Text);
            }
            catch
            {
                abilityBonus = 0;
            }
            
            abilitySource = abilitySourceBox.Text;
            
            try
            {
                ranks = Int32.Parse(rankBox.Text);
            }
            catch
            {
                ranks = 0;
            }
            try
            {
                miscMod = Int32.Parse(miscBox.Text);
            }
            catch
            {
                miscMod = 0;
            }

            Skill newSkill = new Skill(name);
            newSkill.abilityMod = abilityBonus;
            newSkill.abilitySource = abilitySource;
            newSkill.ranks = ranks;
            newSkill.miscMod = miscMod;
            newSkill.isClassSkill = classSkillCheckBox.Checked;
            return newSkill;
        }

        private void abilityBonusBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                abilityBonus = Int32.Parse(abilityBonusBox.Text);
            }
            catch
            {

            }
            calculateTotal();
        }

        private void calculateTotal()
        {
            total = abilityBonus + ranksBonus + miscBonus;
            totalBox.Text = total.ToString();
        }

        private void rankBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ranksBonus = Int32.Parse(rankBox.Text);
                if(ranksBonus > 0 && !classCheckAdded && classSkillCheckBox.Checked)
                {
                    miscBonus += 3;
                    miscBox.Text = miscBonus.ToString();
                    classCheckAdded = true;
                }
                else if(ranksBonus <= 0 && classCheckAdded && classSkillCheckBox.Checked)
                {
                    miscBonus -= 3;
                    miscBox.Text = miscBonus.ToString();
                    classCheckAdded = false;
                }
            }
            catch
            {

            }
            calculateTotal();
        }

        private void miscBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                miscBonus = Int32.Parse(miscBox.Text);
            }
            catch
            {

            }
            calculateTotal();
        }

        public void InitiateSkill(Skill newSkill, List<int> abltyMods)
        {
            abilityMods = abltyMods;
            skillNameBox.Text = newSkill.name;
            
            switch(newSkill.abilitySource)
            {
                case "Str": abilitySourceBox.SelectedIndex = 0; break;
                case "Dex": abilitySourceBox.SelectedIndex = 1; break;
                case "Con": abilitySourceBox.SelectedIndex = 2; break;
                case "Int": abilitySourceBox.SelectedIndex = 3; break;
                case "Wis": abilitySourceBox.SelectedIndex = 4; break;
                default: abilitySourceBox.SelectedIndex = 5; break;
            }
            //abilityBonusBox.Text = newSkill.abilityMod.ToString();
            if (abilityBonusBox.Text == "")
                abilityBonusBox.Text = "0";
            rankBox.Text = newSkill.ranks.ToString();
            classSkillCheckBox.Checked = newSkill.isClassSkill;
            miscBox.Text = newSkill.miscMod.ToString();
            

            
        }

        private void classSkillCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(classSkillCheckBox.Checked && ranksBonus > 0)
            {
                miscBonus += 3;
                miscBox.Text = miscBonus.ToString();
                classCheckAdded = true;
            }
            else if(!classSkillCheckBox.Checked && classCheckAdded)
            {
                miscBonus -= 3;
                miscBox.Text = miscBonus.ToString();
                classCheckAdded = false;
            }
            classSkill = classSkillCheckBox.Checked;
            calculateTotal();
        }

        private void xBox_Click(object sender, EventArgs e)
        {
            ParentWindow.DeleteLine(skillID);
        }

        public void SetAbilityMods(List<int> mods)
        {
            abilityMods = mods;
        }

        private void abilitySourceBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (abilityMods != null)
            {
                if (abilitySourceBox.SelectedIndex < abilityMods.Count)
                {
                    abilityBonus = abilityMods.ElementAt(abilitySourceBox.SelectedIndex);
                    abilityBonusBox.Text = abilityBonus.ToString();
                }
            }
        }
    }
}
