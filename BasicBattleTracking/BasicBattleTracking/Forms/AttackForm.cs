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
    public partial class AttackForm : Form
    {
        private MainWindow sendingForm;
        private CharacterSheet sendingSheet;
        private List<Fighter> PCs;
        private Fighter target;
        private int DR;
        public string attackerName { get; set; }
        public bool isStatus { get; set; }
        public AttackForm(MainWindow sender, List<Fighter> combatants)
        {
            sendingForm = sender;
            InitializeComponent();
            PCs = new List<Fighter>();
            foreach (Fighter f in combatants)
            {
                if (!f.isPC)
                {
                    PCs.Add(f);
                    targetBox.Items.Add(f.Name);
                }
            }

            foreach (Fighter f in combatants)
            {
                if (f.isPC)
                {
                    PCs.Add(f);
                    targetBox.Items.Add(f.Name);
                }
            }
            targetBox.SelectedIndex = 0;
        }

        public AttackForm(CharacterSheet sheet, Fighter PC)
        {
            sendingSheet = sheet;
            InitializeComponent();
            targetBox.Items.Add(PC.Name);
            targetBox.Enabled = false;
            PCs = new List<Fighter>() { PC };

            targetBox.SelectedIndex = 0;
        }

        private void AttackForm_Load(object sender, EventArgs e)
        {
            drCheckBox.Checked = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (targetBox.SelectedIndex >= 0 && targetBox.SelectedIndex <= targetBox.Items.Count)
            {
                Fighter victim = PCs.ElementAt(targetBox.SelectedIndex);
                int damage = 0;

                try
                {
                    damage = Int32.Parse(totalBox.Text);
                }
                catch
                {
                    MessageBox.Show("Invalid damage amount.", "Error", MessageBoxButtons.OK);
                }

                if (!victim.isPC || sendingSheet != null)
                    victim.HP -= damage;
              

                if (sendingForm != null)
                {
                    sendingForm.LogAttack(victim.Name, damage);
                }
                if (sendingSheet != null)
                {
                    sendingSheet.LogAttack(damage);
                }
                if (victim.HP <= 0 && !victim.isPC && sendingForm != null)
                {
                    sendingForm.removeFighter(victim);
                    sendingForm.WriteToLog(victim.Name + " has died!");
                    victim.StatusEffects.Clear();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid target");
                targetBox.SelectedIndex = 0;
            }
        }

        private void targetBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (targetBox.SelectedIndex >= 0 && targetBox.SelectedIndex <= targetBox.Items.Count)
            {
                target = PCs.ElementAt(targetBox.SelectedIndex);
                drBox.Text = target.DamageReduce.ToString();
                DR = target.DamageReduce;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DamageBox_TextChanged(object sender, EventArgs e)
        {
            ApplyDR();
        }

        private void drBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DR = Int32.Parse(drBox.Text);
            }
            catch { return; }

            if (drCheckBox.Checked)
            {
                ApplyDR();
            }
        }

        private void drCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ApplyDR();
        }

        private void ApplyDR()
        {
            int rawDamage = 0;
            try
            {
                rawDamage = Int32.Parse(DamageBox.Text);
            }
            catch { return; }

            if (drCheckBox.Checked)
            {
                rawDamage -= DR;
                if (rawDamage < 0)
                    rawDamage = 0;
            }
            totalBox.Text = rawDamage.ToString();
        }
    }
}
