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
    public partial class PC_Initiative : Form
    {
        private MainWindow SendingForm;
        private List<TextBox> initBoxes;
        List<Fighter> players;
        private bool isClosed;
        private bool cancel = true;
        public PC_Initiative(MainWindow sendingForm)
        {
            InitializeComponent();
            SendingForm = sendingForm;
            initBoxes = new List<TextBox>();
            this.FormClosed += new FormClosedEventHandler(this.CloseForm);
            isClosed = false;
        }

        private void PC_Initiative_Load(object sender, EventArgs e)
        {

        }
        public void setPCList(List<Fighter> PCs)
        {
            int yOffset = 32;
            int index = 1;
            int labelX = 6;
            int boxX = 74;
            players = PCs;
            foreach (Fighter pc in PCs)
            {
                Label newLabel = new Label();
                newLabel.AutoSize = true;
                newLabel.Location = new Point(labelX, yOffset * index);
                newLabel.Name = "label" + index;
                newLabel.Text = pc.Name;

                TextBox newBox = new TextBox();
                newBox.Location = new Point(boxX, yOffset * index);
                newBox.Name = "TextBox" + index;
                newBox.TabIndex = index;

                initBoxes.Add(newBox);

                groupBox1.Controls.Add(newLabel);
                groupBox1.Controls.Add(newBox);

                index++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool errorFlag = false;
            string errorMessage = "";

            for (int i = 0; i < initBoxes.Count; i++)
            {
                int initiative = 0;
                try
                {
                    initiative = Int32.Parse(initBoxes.ElementAt(i).Text);
                    players.ElementAt(i).Initiative = initiative;
                }
                catch
                {
                    errorFlag = true;
                    errorMessage = "One or more initiatives are invalid.";
                }
            }

            if (errorFlag)
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK);
            }
            else
            {
                cancel = false;
                this.SendingForm.AddMultipleFighters(players);
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SendingForm.cancelInit = true;
            isClosed = true;
            this.SendingForm.AddMultipleFighters(players);
            this.Close();
        }

        private void CloseForm(object sender, EventArgs e)
        {
            if(!this.isClosed && cancel)
            {
                this.SendingForm.AddMultipleFighters(players);
                SendingForm.cancelInit = true;
            }
            else if(cancel)
            {
                SendingForm.cancelInit = true;
            }
            
        }
    }
}
