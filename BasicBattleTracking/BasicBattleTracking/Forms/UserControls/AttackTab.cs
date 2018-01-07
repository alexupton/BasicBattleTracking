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
    public partial class AttackTab : UserControl
    {
        private List<TextBox> bonusBoxes;
        private List<Label> bonusLabel;
        public int attackNumber { get; set; }
        private const int panelLineStartX = 12;
        private const int panelLineStartY = 14;
        private const int panelLineOffsetY = 26;
        private const int bonusBoxOffsetX = 86;
        private TabPage parentTab;
        private List<int> attackValues;
        public AttackDesigner sendingForm { get; set; }
        private Attack atk;
        public AttackTab(TabPage parent)
        {
            InitializeComponent();
            parentTab = parent;
            bonusBoxes = new List<TextBox>();
            bonusLabel = new List<Label>();
            attackValues = new List<int>();
            attackNumber = 0;
            panel1.Controls.Clear();

            Label newAttackLabel = new Label();
            newAttackLabel.AutoSize = true;
            newAttackLabel.Location = new System.Drawing.Point(12, 14);
            newAttackLabel.Name = "newAttackLabel";
            newAttackLabel.Size = new System.Drawing.Size(80, 13);
            newAttackLabel.TabIndex = 12;
            newAttackLabel.Text = "Attack Bonus 1";

            TextBox newText = new TextBox();
            newText.Location = new System.Drawing.Point(98, 11);
            newText.Name = "AttackBonusBox1";
            newText.Size = new System.Drawing.Size(34, 20);
            newText.TabIndex = 11;
            newText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            panel1.Controls.Add(newAttackLabel);
            panel1.Controls.Add(newText);
            bonusBoxes.Add(newText);
            bonusLabel.Add(newAttackLabel);

           



        }

        private void AttackCountBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int newIndex = Int32.Parse(AttackCountBox.Text);
                if(newIndex > 0)
                {
                    RedrawBonusLines(newIndex);
                }
            }
                catch
            {
                    Console.WriteLine("Invalid string in AttackCountBox");
                }
        }

        private void RedrawBonusLines(int lineCount)
        {
            if (lineCount > 100)
                lineCount = 100;
            List<int> values = new List<int>();
            for (int i = 0; i < bonusBoxes.Count; i++ )
            {
                try
                {
                    int newValue = Int32.Parse(bonusBoxes.ElementAt(i).Text);
                    if (i >= attackValues.Count)
                    {
                        attackValues.Add(newValue);
                    }
                    else
                    {
                        attackValues.RemoveAt(i);
                        attackValues.Insert(i, newValue);
                    }
                }
                catch
                {

                }
            }
            panel1.Controls.Clear();
            bonusLabel.Clear();
            bonusBoxes.Clear();
            for(int i = 0; i < lineCount; i++)
            {
                Label newAttackLabel = new Label();
                newAttackLabel.AutoSize = true;
                newAttackLabel.Location = new System.Drawing.Point(panelLineStartX, panelLineStartY + (panelLineOffsetY * i));
                newAttackLabel.Name = "newAttackLabel" + i;
                newAttackLabel.Size = new System.Drawing.Size(80, 13);
                newAttackLabel.TabIndex = 12;
                newAttackLabel.Text = "Attack Bonus " + (i+1).ToString();
                panel1.Controls.Add(newAttackLabel);
                bonusLabel.Add(newAttackLabel);

                TextBox newText = new TextBox();
                newText.Location = new System.Drawing.Point(106, (panelLineOffsetY * i) + 11);
                newText.Name = "AttackBonusBox" + i;
                newText.Size = new System.Drawing.Size(34, 20);
                newText.TabIndex = 11;
                newText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                if(i < attackValues.Count)
                {
                    newText.Text = attackValues.ElementAt(i).ToString();
                }
                else if(atk != null && i < atk.atkBonuses.Count)
                {
                    newText.Text = atk.atkBonuses.ElementAt(i).ToString();
                }
                panel1.Controls.Add(newText);
                bonusBoxes.Add(newText);
            }
        }

        public Attack BuildAttack()
        {
            string name = "";
            bool errorFlag = false;
            string errorMessage = "";
            if(nameBox.Text != "")
            {
                name = nameBox.Text;
            }
            else
            {
                errorFlag = true;
                errorMessage += "\nAttack " + attackNumber + " must have a name.";
            }

            Attack newAttack = new Attack(name);

            int critMin = 0;
            int critMult = 0;
            int dMult = 0;
            int dType = 0;
            int dBonus = 0;
            try
            {
                critMin = Int32.Parse(CritMinBox.Text);
                critMult = Int32.Parse(CritMultBox.Text);
            }
            catch
            {
                errorFlag = true;
                errorMessage += "\nBad critical formula for attack " + attackNumber;
            }

            try
            {
                dMult = Int32.Parse(DamageDMultBox.Text);
                dType = Int32.Parse(DamageDTypeBox.Text);
                dBonus = Int32.Parse(DamageAddBox.Text);

                if(dMult <= 0 || dType <= 0)
                {
                    errorFlag = true;
                    errorMessage += "\nInvalid values for damage fields of attack " + attackNumber;
                }
            }
            catch
            {
                errorFlag = true;
                errorMessage += "\nBad damage formula for attack " + attackNumber;
            }

            List<int> attackBonuses = new List<int>();

            foreach(TextBox box in bonusBoxes)
            {
                int bonus = 0;
                try
                {
                    bonus = Int32.Parse(box.Text);
                    attackBonuses.Add(bonus);
                }
                catch { }
            }

            if(attackBonuses.Count <= 0)
            {
                errorFlag = true;
                errorMessage += "\nAttack " + attackNumber + " must have at least 1 attack bonus.";
            }

            if(errorFlag)
            {
                MessageBox.Show(errorMessage, "Error!");
                return null;
            }
            else
            {
                newAttack.atkBonus = attackBonuses.ElementAt(0);
                newAttack.atkBonuses = attackBonuses;
                newAttack.CritMin = critMin;
                newAttack.CritMult = critMult;
                newAttack.dieAmt = dMult;
                newAttack.dieType = dType;
                newAttack.dmgBonus = dBonus;
                

                return newAttack;
            }

            
        }

        private void AttackTab_Load(object sender, EventArgs e)
        {
            //panel1.Controls.Clear();
            //RedrawBonusLines(1);
            
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            parentTab.Text = nameBox.Text;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            sendingForm.RemoveTab(attackNumber - 1);
        }

        public void AddAttack(Attack attack)
        {
            nameBox.Text = attack.name;
            CritMinBox.Text = attack.CritMin.ToString();
            CritMultBox.Text = attack.CritMult.ToString();
            DamageAddBox.Text = attack.dmgBonus.ToString();
            DamageDMultBox.Text = attack.dieAmt.ToString();
            DamageDTypeBox.Text = attack.dieType.ToString();
            atk = attack;
            AttackCountBox.Text = atk.atkBonuses.Count.ToString();
            RedrawBonusLines(atk.atkBonuses.Count);
        }
    }
}
