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
    public partial class TableErrorBox : Form
    {
        private List<int[]> Gaps;
        private DPercentDesigner sendingForm;
        public TableErrorBox(List<int[]> gaps, DPercentDesigner sender)
        {
            Gaps = gaps;
            sendingForm = sender;
            InitializeComponent();
        }

        private void TableErrorBox_Load(object sender, EventArgs e)
        {
            recalcTip.SetToolTip(recalcButton, "Recalculate minimum and maximum values, with the existing maximum"
                + "\nof the table being a base and the results given equal weight.");


            if (Gaps.Count > 0)
            {
                foreach (int[] i in Gaps)
                {
                    gapsBox.AppendText(i[0].ToString() + " - " + i[1].ToString());
                    gapsBox.AppendText(Environment.NewLine);
                }
            }
                
        }

        private void cancButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void recalcButton_Click(object sender, EventArgs e)
        {
            sendingForm.RecalculateAndSave();
            this.Close();
        }
    }
}
