using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicBattleTracking.Forms.UserControls
{
    public partial class AttackControl : UserControl
    {
        public MainWindow parentForm { get; set; }
        public CharacterSheet sheetForm { get; set; }
        private Fighter PC { get; set; }
        private int selectedAttack;
        private bool SkipCheckboxUpdate;
        public AttackControl()
        {
            InitializeComponent();
        }

        private void AttackControl_Load(object sender, EventArgs e)
        {

        }

        public void InitializeAttacks(Fighter player)
        {
            PC = player;
            UpdateAttacks();
            if (PC.attacks.Count > 0)
            {
                npcAttackButton.Enabled = true;
                editButton.Enabled = true;
            }
        }

        public void UpdateAttacks()
        {
                    attackView.Items.Clear();
                    foreach (Attack a in PC.attacks)
                    {
                        int attackCount = 0;
                        if (a.atkBonuses.Count - a.atkCount > 0)
                            attackCount = a.atkBonuses.ElementAt(a.atkCount);
                        else
                        {
                            attackCount = a.atkBonuses.ElementAt(0);
                        }
                        attackView.Items.Add(new ListViewItem(new string[] { a.name, attackCount.ToString(), a.dieAmt + " d" + a.dieType + " + " + a.dmgBonus, (a.atkBonuses.Count - a.atkCount).ToString() }));
                    }

                    if (attackView.Items.Count > selectedAttack && PC.attacks.Count > 0)
                    {
                        AtkNameLabel.Text = PC.attacks.ElementAt(selectedAttack).name;
                    }
                    if (PC.attacks.Count > 0 && !SkipCheckboxUpdate)
                    {
                        Attack first = PC.attacks.First();
                        AtkStrBonusBox.Checked = first.strBonusAppliedToAtk;
                        AtkDexBonusBox.Checked = first.dexBonusAppliedToAtk;
                        DmgDexBonusBox.Checked = first.dexBonusAppliedToDmg;
                        DmgStrBonusBox.Checked = first.strBonusAppliedToDmg;
                    }
                    else if(!SkipCheckboxUpdate)
                    {
                        AtkStrBonusBox.Checked = false;
                        AtkDexBonusBox.Checked = false;
                        DmgDexBonusBox.Checked = false;
                        DmgStrBonusBox.Checked = false;
                    }
                
        }

        private void attackView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (attackView.SelectedIndices.Count > 0)
            {
                if (attackView.SelectedIndices[0] >= 0)
                {
                    selectedAttack = attackView.SelectedIndices[0];
                    AtkNameLabel.Text = PC.attacks.ElementAt(selectedAttack).name;
                    Attack selectedAtkObject = PC.attacks.ElementAt(selectedAttack);
                    AtkDexBonusBox.Checked = selectedAtkObject.dexBonusAppliedToAtk;
                    AtkStrBonusBox.Checked = selectedAtkObject.strBonusAppliedToAtk;
                    DmgStrBonusBox.Checked = selectedAtkObject.strBonusAppliedToDmg;
                    DmgDexBonusBox.Checked = selectedAtkObject.dexBonusAppliedToDmg;
                }
            }
        }

        private void AtkStrBonusBox_CheckedChanged(object sender, EventArgs e)
        {
            if (PC.attacks.Count > 0)
            {
                Attack changeAtk = PC.attacks.ElementAt(selectedAttack);
                if (AtkStrBonusBox.Checked)
                    changeAtk.UpdateStrBonusToAttack(Program.getAbilityMod(PC.Str));
                else
                    changeAtk.ResetAtkStrBonus();
                SkipCheckboxUpdate = true;
                UpdateAttacks();
                SkipCheckboxUpdate = false;
            }
        }

        private void AtkDexBonusBox_CheckedChanged(object sender, EventArgs e)
        {
            if (PC.attacks.Count > 0)
            {
                Attack changeAtk = PC.attacks.ElementAt(selectedAttack);
                if (AtkDexBonusBox.Checked)
                {
                    changeAtk.UpdateDexBonusToAttack(Program.getAbilityMod(PC.Dex));
                }
                else
                {
                    changeAtk.ResetAtkDexBonus();
                }
                SkipCheckboxUpdate = true;
                UpdateAttacks();
                SkipCheckboxUpdate = false;
            }
        }

        private void DmgStrBonusBox_CheckedChanged(object sender, EventArgs e)
        {
            if (PC.attacks.Count > 0)
            {
                Attack changeAtk = PC.attacks.ElementAt(selectedAttack);
                if (DmgStrBonusBox.Checked)
                {
                    changeAtk.UpdateStrBonusToDamage(Program.getAbilityMod(PC.Str));
                }
                else
                {
                    changeAtk.ResetDmgStrBonus();
                }
                SkipCheckboxUpdate = true;
                UpdateAttacks();
                SkipCheckboxUpdate = false;
            }
        }

        private void DmgDexBonusBox_CheckedChanged(object sender, EventArgs e)
        {
            if (PC.attacks.Count > 0)
            {
                Attack changeAtk = PC.attacks.ElementAt(selectedAttack);
                if (DmgDexBonusBox.Checked)
                {
                    changeAtk.UpdateDexBonusToDamage(Program.getAbilityMod(PC.Dex));
                }
                else
                {
                    changeAtk.ResetDmgDexBonus();
                }

                SkipCheckboxUpdate = true;
                UpdateAttacks();
                SkipCheckboxUpdate = false;
            }
        }
        private void SetDamageInfoEnable(bool value)
        {
            rawDamageLabel.Enabled = value;
            rawDamageBox.Enabled = value;
            dmgBonusLabel.Enabled = value;
            dmgBonusBox.Enabled = value;
            damageResult.Enabled = value;
            DamageLabel.Enabled = value;
        }
        private void WriteToRollConsole(string input)
        {
            rollBox.AppendText(input);
            rollBox.AppendText("\n");
        }

      

        private void npcAttackButton_Click(object sender, EventArgs e)
        {
            if (selectedAttack < PC.attacks.Count && selectedAttack >= 0)
            {
                PrepareAttack(selectedAttack);
            }
        }

        private void PrepareAttack(int atkIndex)
        {
            Attack atk = PC.attacks.ElementAt(atkIndex);
            WriteToRollConsole("=====ATTACK ROLL=====");
            WriteToRollConsole("Rolled 1 d20");
            bool crit = false;
            int result = atk.RollAttack();
            atkModBox.Text = atk.atkBonuses.ElementAt(atk.atkCount - 1).ToString();
            WriteToRollConsole("Result: " + atk.AtkRollResult);
            WriteToRollConsole("Modifier: " + atk.atkBonuses.ElementAt(atk.atkCount - 1));
            WriteToRollConsole("Total: " + result.ToString() + "\n");
            if (atk.AtkRollResult >= atk.CritMin)
            {
                crit = true;

            }

            rollResultLabel.Text = result.ToString();
            d20Label.Text = atk.AtkRollResult.ToString();
            WriteToLog(PC.Name + " made an attack using " + PC.attacks.ElementAt(atkIndex).name + " with a roll of " + result.ToString() + "!");

            RollAttack(PC.attacks.ElementAt(atkIndex), crit);
        }

        private void RollAttack(Attack atk, bool crit)
        {
            SetDamageInfoEnable(true);
            int dieTotal = atk.RollDamage();
            WriteToRollConsole("Rolling " + atk.dieAmt.ToString() + " d" + atk.dieType.ToString() + " for damage");
            int subtotal = 0;
            StringBuilder sb = new StringBuilder("Result: " + atk.RawDamageTotal);
            sb.Append(" {");
            for (int i = 0; i < atk.dieAmt; i++)
            {
                sb.Append(atk.damageRollResults.ElementAt(i).ToString());
                if (i != atk.dieAmt - 1)
                {
                    sb.Append(", ");
                }
                else
                {
                    sb.Append("}");
                }
                subtotal += atk.damageRollResults.ElementAt(i);
            }
            WriteToRollConsole(sb.ToString());
            rawDamageBox.Text = subtotal.ToString();
            dmgBonusBox.Text = atk.dmgBonus.ToString();
            WriteToRollConsole("Damage Bonus: " + atk.dmgBonus.ToString());
            DamageLabel.Text = dieTotal.ToString();

            if (crit)
            {
                WriteToLog("Critical Hit!");
                int confirm = atk.ConfirmCritCheck();
                WriteToRollConsole("");
                WriteToRollConsole("Potential critical hit!");
                WriteToRollConsole("Rolling 1d20 + " + atk.atkBonuses.ElementAt(atk.atkCount) + " to confirm.");
                WriteToRollConsole("Reslut: " + confirm);
                DialogResult critConfirm = DialogResult.Yes;
                if (!parentForm.session.settings.confirmCrits)
                {
                    critConfirm = MessageBox.Show("Confirm check is " + confirm + ". Confirm critical?", "Critical Hit!", MessageBoxButtons.YesNo);
                }
                if (critConfirm == DialogResult.Yes)
                {
                    WriteToRollConsole("Critical hit confirmed! Multiplier: " + atk.CritMult.ToString());
                    WriteToLog("It was confirmed!");
                    dieTotal *= atk.CritMult;

                    int newRawDamage = Int32.Parse(rawDamageBox.Text) * atk.CritMult;
                    int newDamageBonus = Int32.Parse(dmgBonusBox.Text) * atk.CritMult;

                    rawDamageBox.Text = newRawDamage.ToString();
                    dmgBonusBox.Text = newDamageBonus.ToString();

                }
                else
                {
                    WriteToRollConsole("Critical hit not confirmed!");
                    WriteToLog("It was not confirmed!");
                }

            }

            DamageLabel.Text = dieTotal.ToString();
            WriteToRollConsole("Grand Total: " + dieTotal.ToString());
        }

        private void WriteToLog(string input)
        {
            if (sheetForm != null)
                sheetForm.WriteToLog(input);
        }

        private void npcAttackButton_Click_1(object sender, EventArgs e)
        {
            if (selectedAttack < PC.attacks.Count && selectedAttack >= 0)
            {
                PrepareAttack(selectedAttack);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            AttackDesigner ad = new AttackDesigner(this);
            ad.LoadAttacks(PC.attacks);
            ad.Show();
        }

        public void SetAttacks(List<Attack> atks)
        {
            PC.attacks = atks;
            UpdateAttacks();
        }

        private void DmgButton_Click(object sender, EventArgs e)
        {
            if (sheetForm != null)
            {
                AttackForm af = new AttackForm(sheetForm, PC);
                af.Show();
            }
        }





        


    }
}
