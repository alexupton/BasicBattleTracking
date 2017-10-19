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
    public partial class DPercentPanel : UserControl
    {

        private List<DPercentTable> tables;
        private int SelectedTableIndex;
        private DPercentTable selectedTable;



        public DPercentPanel()
        {
            InitializeComponent();
            tables = new List<DPercentTable>();
        }

        

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        public void addDPercentTable(DPercentTable add)
        {
            tables.Add(add);
            UpdateTableList();
        }

        private void DPercentPanel_Load(object sender, EventArgs e)
        {

        }

        private void UpdateTableList()
        {
            tableList.Items.Clear();
            foreach (DPercentTable table in tables)
            {
                tableList.Items.Add(table.Name);
            }
        }

        private void UpdateResultsTable()
        {
            resultsView.Items.Clear();
            for (int i = 0; i < selectedTable.results.Count; i++)
            {
                int endVal = selectedTable.MaxVal;
                if (i < selectedTable.results.Count - 1)
                {
                    endVal = selectedTable.startValues.ElementAt(i + 1) - 1;
                }

                string firstItem = selectedTable.startValues.ElementAt(i) + " - " + endVal;

                resultsView.Items.Add(new ListViewItem(new string[]{firstItem, selectedTable.results.ElementAt(i)}));
            
            }
        }


        private void tableList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tableList.SelectedIndex < tables.Count && tableList.SelectedIndex >= 0)
            {
                SelectedTableIndex = tableList.SelectedIndex;
            
                selectedTable = tables.ElementAt(SelectedTableIndex);
                UpdateResultsTable();
            }
        }

        private void npcAttackButton_Click(object sender, EventArgs e)
        {
            if (selectedTable != null)
            {
                WriteToLog("=====ROLL ON THE " + selectedTable.Name.ToUpper() + " TABLE=====");
                int result = selectedTable.RollResult();
                WriteToLog("Result: " + result);
                string value = selectedTable.evaluateResult(result);
                WriteToLog("Effect: " + value);
                rollResultLabel.Text = result.ToString();
                resultBox.Text = value;
            }
            else
            {
                resultBox.Text = "Error: No table selected";
            }
        }

        private void WriteToLog(string text)
        {
            logBox.AppendText(text);
            logBox.AppendText(Environment.NewLine);
        }

        private void addFighterButton_Click(object sender, EventArgs e)
        {
            DPercentDesigner DPDesign = new DPercentDesigner();
            DPDesign.sendingForm = this;
            DPDesign.Show();
        }
    }
}
