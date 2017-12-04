using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicBattleTracking
{
    public partial class SkillDesigner : Form
    {
        private List<SkillLine> skillLines;
        private const int SPACING_INTERVAL = 35;
        private const int INITIAL_X = 3;
        private const int INITIAL_Y = 3;

        private int selectedControl = 0;
        private List<int> abilityMods;

        public StatBlockDesigner ParentWindow { get; set; }
        public SkillDesigner()
        {
            InitializeComponent();
            skillLines = new List<SkillLine>();
            abilityMods = new List<int>();
        }

        private void SkillDesigner_Load(object sender, EventArgs e)
        {
            skillLines.First<SkillLine>().Select();
        }

        public void PopulateSkillLines(List<Skill> skillInputList)
        {
            int count = 0;
            if (skillInputList.Count <= 0)
            {
                skillInputList = ParentWindow.parent.session.settings.defaultSkillLoadout;
            }
            foreach(Skill s in skillInputList)
            {
                SkillLine newLine = new SkillLine(this);
                newLine.SetAbilityMods(abilityMods);
                newLine.Location = new Point(INITIAL_X, INITIAL_Y + SPACING_INTERVAL * count );
                addButton.Location = new Point (24, INITIAL_Y + SPACING_INTERVAL * (count + 1));
                newLine.skillID = count;
                newLine.InitiateSkill(s, abilityMods);
                mainPanel.Controls.Add(newLine);
                skillLines.Add(newLine);
                count++;
            }

            

        }

        public void InitFinished()
        {
            //mainPanel.VerticalScroll.Value = 0;
            //VerticalScroll.Value = 0;
        }

        public void DeleteLine(int skillLineID)
        {
            selectedControl = skillLineID;
            if(skillLineID < skillLines.Count)
            {
                SkillLine candidate = skillLines.ElementAt(skillLineID);

                if(skillLineID != 0 || (skillLineID == 0 && skillLines.Count > 1))
                {
                    mainPanel.Controls.Remove(candidate);
                    skillLines.Remove(candidate);

                    for(int i = skillLineID; i < skillLines.Count; i++)
                    {
                        skillLines.ElementAt(i).skillID--;
                    }
                }
            }
            RepositionLines();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            SkillLine newLine = new SkillLine(this);
            newLine.skillID = skillLines.Count;
            mainPanel.Controls.Add(newLine);
            skillLines.Add(newLine);
            RepositionLines();
        }

        private void RepositionLines()
        {
            mainPanel.Controls.Clear();
            int count = 0;
            foreach (SkillLine s in skillLines)
            {
                s.Location = new Point(INITIAL_X, INITIAL_Y + SPACING_INTERVAL * count);
                addButton.Location = new Point(24, INITIAL_Y + SPACING_INTERVAL * (count + 1));
                mainPanel.Controls.Add(s);
                count++;
            }
            mainPanel.Controls.Add(addButton);

            if(selectedControl < skillLines.Count)
            {
                skillLines.ElementAt(selectedControl).Select();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            List<Skill> finalList = new List<Skill>();
            foreach(SkillLine line in skillLines)
            {
                Skill newSkill = line.GenerateSkill();
                if(newSkill != null)
                {
                    finalList.Add(newSkill);
                }
            }
            ParentWindow.SetSkillList(finalList);
            this.Close();
        }

        private void cancButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetAbilityMods(List<int> mods)
        {
            abilityMods = mods;
        }
    }
}
