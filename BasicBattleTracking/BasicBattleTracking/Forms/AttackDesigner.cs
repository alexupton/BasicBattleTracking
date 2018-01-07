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
    public partial class AttackDesigner : Form
    {
        private List<AttackTab> tabs;
        private StatBlockDesigner parentWindow;
        public AttackDesigner(StatBlockDesigner sendingForm)
        {
            parentWindow = sendingForm;
            InitializeComponent();
            tabs = new List<AttackTab>();
            tabControl1.SelectedIndexChanged += new EventHandler(SelectedIndexChanged);
            tabControl1.TabPages.Clear();
            tabs = new List<AttackTab>();

            addNewAttack();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            List<Attack> attacks = new List<Attack>();
            foreach(AttackTab attack in tabs)
            {
                Attack newAttack = attack.BuildAttack();
                if(newAttack != null)
                {
                    attacks.Add(newAttack);
                }
            }

            parentWindow.SetAttacks(attacks);
            if (attacks.Count > 0)
            {
                this.Close();
            }

            
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AttackDesigner_Load(object sender, EventArgs e)
        {


            
        }

        private void addNewAttack()
        {
            if(tabControl1.TabCount > 1)
            {
                tabControl1.TabPages.RemoveAt(tabControl1.TabCount - 1);
            }
            TabPage newTab = new TabPage();
            int count = tabs.Count + 1;
            AttackTab newAttackTab = new AttackTab(newTab);
            newAttackTab.attackNumber = count;
            newAttackTab.sendingForm = this;
            

            newTab.Controls.Add(newAttackTab);
            newTab.Location = new System.Drawing.Point(4, 22);
            newTab.Name = "tabPage" + count;
            newTab.Padding = new System.Windows.Forms.Padding(3);
            newTab.Size = new System.Drawing.Size(314, 391);
            newTab.TabIndex = 0;
            newTab.Text = "Attack " + count;
            newTab.UseVisualStyleBackColor = true;

            tabs.Add(newAttackTab);
            this.tabControl1.TabPages.Add(newTab);

            newTab = new TabPage();
            newTab.Location = new System.Drawing.Point(4, 22);
            newTab.Name = "tabPage" + count;
            newTab.Padding = new System.Windows.Forms.Padding(3);
            newTab.Size = new System.Drawing.Size(314, 391);
            newTab.TabIndex = 0;
            newTab.Text = "New Attack";
            newTab.UseVisualStyleBackColor = true;
            this.tabControl1.TabPages.Add(newTab);

            

        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = tabControl1.SelectedIndex;
            if (tabControl1.SelectedIndex >= tabs.Count)
            {
                addNewAttack();
            }
            tabControl1.SelectedIndex = index;
        }

        public void RemoveTab(int index)
        {
            if (tabs.Count > 1)
            {
                tabControl1.TabPages.RemoveAt(index);
                tabs.RemoveAt(index);
                for (int i = 0; i < tabs.Count; i++)
                {
                    tabs.ElementAt(i).attackNumber = i + 1;
                }
                if (index != tabControl1.TabCount - 1)
                {
                    tabControl1.SelectedIndex = index;
                }
                else
                {
                    tabControl1.SelectedIndex = index - 1;
                }
            }
            else
            {
                MessageBox.Show("Must have at least 1 attack");
            }
        }

        public void LoadAttacks(List<Attack> attackList)
        {
            tabs.Clear();
            tabControl1.TabPages.Clear();
            foreach(Attack a in attackList)
            {
                
                addNewAttack();
                tabs.ElementAt(attackList.IndexOf(a)).AddAttack(a);
                
            }
        }

        private void CancButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
