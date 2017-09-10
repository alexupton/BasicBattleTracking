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
    public partial class AddFighterWindow : Form
    {
        private MainWindow sendingForm;
        public AddFighterWindow(MainWindow sender)
        {
            InitializeComponent();
            sendingForm = sender;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            string name = "";
            int init = 0;
            int hp = 0;
            bool isPlayer = false;
            bool errorFlag = false;
            string errorMessage = "";
            

            if (nameBox.Text != "")
            {
                name = nameBox.Text;
            }
            else
            {
                errorFlag = true;
                errorMessage += "Name cannot be blank.\n";
            }

            try
            {
                init = Int32.Parse(InitBox.Text);
            }
            catch
            {
                errorFlag = true;
                errorMessage = "Initiative Bonus must be a valid integer. \n";
            }

            try
            {
                hp = Int32.Parse(HPBox.Text);
                if (hp < 0)
                {
                    errorFlag = true;
                    errorMessage += "HP must be positive. \n";
                }
            }
            catch
            {
                errorFlag = true;
                errorMessage += "HP must be a valid integer. \n";
            }

            isPlayer = PCCheckBox.Checked;

            if (errorFlag)
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK);
            }
            else
            {
                Fighter combatant = new Fighter(name, init, isPlayer);
                try
                {
                    combatant.Dex = Int32.Parse(dexBox.Text);
                }
                catch
                { }

                if (!isPlayer)
                {
                    combatant.HP = hp;
                }
                sendingForm.AddFighter(combatant);
                this.Close();
            }



        }
    }
}
