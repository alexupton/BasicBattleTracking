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
    public partial class StatusWindow : Form
    {
        private MainWindow sendingForm;
        private List<Fighter> PCs;
        private List<Status> statuses;
        public string attackerName { get; set; }
        

        public StatusWindow(MainWindow sender, List<Fighter> combatants)
        {
            InitializeComponent();
            sendingForm = sender;
            PCs = new List<Fighter>();
            targetBox.Items.Add("All");
            targetBox.Items.Add("All friendly");
            targetBox.Items.Add("All enemies");
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

        public void AddRecentlyUsed(List<Status> recentlyUsedStatuses)
        {
            statuses = recentlyUsedStatuses;
            foreach(Status s in recentlyUsedStatuses)
            {
                statusBox.Items.Add(s.Name);
            }
        }

        private void StatusWindow_Load(object sender, EventArgs e)
        {
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool special = false;
            Fighter victim = null;
            if (targetBox.SelectedIndex < 3)
            {
                special = true;
            }
            else
            {
                victim = PCs.ElementAt(targetBox.SelectedIndex - 3);
            }
            
            bool errorFlag = false;
            string errorMessage = "";
            string name = "";
            int duration = 0;
            string description = "";
            if (statusBox.Text == "")
            {
                errorFlag = true;
                errorMessage += "Status must have a name. \n";
            }
            else
            {
                name = statusBox.Text;
            }

            try
            {
                duration = Int32.Parse(turnsBox.Text);

                if (duration <= 0)
                {
                    errorFlag = true;
                    errorMessage += "Duration must be at least 1 turn. \n";
                }
            }
            catch
            {
                errorFlag = true;
                errorMessage += "Duration must be a number";
            }

            description = effectsBox.Text;

            if (errorFlag)
            {
                MessageBox.Show(errorMessage, "Uh-oh");
            }
            else
            {
                if (special)
                {
                    switch (targetBox.SelectedIndex)
                    {
                        case 0:
                            {
                                foreach (Fighter f in PCs)
                                {
                                    Status nStatus = new Status(name, duration);
                                    nStatus.Description = description;
                                    nStatus.SetTarget(f);
                                    f.StatusEffects.Add(nStatus);
                                    sendingForm.WriteToLog(f.Name + " was afflicted with " + nStatus.Name + "! Duration: " + nStatus.Turns + " turns. Effect: " + nStatus.Description);
                                }
                                this.Close();
                                break;
                            }
                        case 1:
                            {
                                foreach (Fighter f in PCs)
                                {
                                    if (f.isPC)
                                    {
                                        Status nStatus = new Status(name, duration);
                                        nStatus.Description = description;
                                        nStatus.SetTarget(f);
                                        f.StatusEffects.Add(nStatus);
                                        sendingForm.WriteToLog(f.Name + " was afflicted with " + nStatus.Name + "! Duration: " + nStatus.Turns + " turns. Effect: " + nStatus.Description);
                                    }
                                }
                                this.Close();
                                break;
                            }
                        default:
                            {
                                {
                                    foreach (Fighter f in PCs)
                                    {
                                        if (!f.isPC)
                                        {
                                            Status nStatus = new Status(name, duration);
                                            nStatus.Description = description;
                                            nStatus.SetTarget(f);
                                            f.StatusEffects.Add(nStatus);
                                            sendingForm.WriteToLog(f.Name + " was afflicted with " + nStatus.Name + "! Duration: " + nStatus.Turns + " turns. Effect: " + nStatus.Description);
                                        }
                                    }
                                    this.Close();
                                    break;
                                }
                            }
                    }
                }
                else
                {
                    Status newStatus = new Status(name, duration);
                    newStatus.Description = description;


                    newStatus.SetTarget(victim);
                    victim.StatusEffects.Add(newStatus);
                    sendingForm.AddStatus(newStatus);

                    sendingForm.WriteToLog(victim.Name + " was afflicted with " + newStatus.Name + "! Duration: " + newStatus.Turns + " turns. Effect: " + newStatus.Description);
                    this.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void statusBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(statusBox.SelectedIndex < statuses.Count)
            {
                Status suggested = statuses.ElementAt(statusBox.SelectedIndex);

                turnsBox.Text = suggested.Turns.ToString();
                effectsBox.Text = suggested.Description;
            }
        }
    }
}
