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
            int dupCount = 0;
            foreach(DPercentTable table in tables)
            {
                if (table.Name == add.Name)
                    dupCount++;
            }
            if (dupCount > 0)
                add.Name += " " + (dupCount + 1).ToString();
            tables.Add(add);
            UpdateTableList();
            tableList.SelectedItem = add.Name;
            button1.Enabled = true;
            button2.Enabled = true;
            npcAttackButton.Enabled = true;

            BattleIO auto = new BattleIO();
            auto.AutoSaveDPercentList(tables, Program.activeSettings);
        }

        private void DPercentPanel_Load(object sender, EventArgs e)
        {
            if (tables.Count <= 0)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                npcAttackButton.Enabled = false;
            }
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

        private void resultsView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(resultsView.SelectedIndices.Count > 0)
            {
                if(resultsView.SelectedIndices[0] < selectedTable.results.Count)
                {
                    resultBox.Text = selectedTable.results.ElementAt(resultsView.SelectedIndices[0]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(selectedTable != null)
            {
                DialogResult result = MessageBox.Show("Remove " + selectedTable.Name + "?","Delete Table", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    int nextIndex = tables.IndexOf(selectedTable) - 1;
                    if (nextIndex < 0)
                        nextIndex = 0;
                    tables.Remove(selectedTable);
                    selectedTable = new DPercentTable();
                    UpdateTableList();
                    UpdateResultsTable();
                    if(nextIndex < tables.Count)
                    {
                        tableList.SelectedItem = tables.ElementAt(nextIndex).Name;
                    }
                    BattleIO auto = new BattleIO();
                    auto.AutoSaveDPercentList(tables, Program.activeSettings);
                    
                }
            }
            if (tables.Count <= 0)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                npcAttackButton.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DPercentDesigner designer = new DPercentDesigner();
            designer.sendingForm = this;
            if (selectedTable != null)
            {
                designer.EditMode(selectedTable, tables.IndexOf(selectedTable));
                designer.Show();
            }
        }

        public void UpdateDPercentTable(DPercentTable updatedTable, int tableIndex)
        {
            int dupCount = 0;
            foreach (DPercentTable table in tables)
            {
                if (table.Name == updatedTable.Name)
                    dupCount++;
            }
            if (dupCount > 0)
                updatedTable.Name += " " + (dupCount + 1).ToString();
            tables.RemoveAt(tableIndex);
            tables.Insert(tableIndex, updatedTable);
            UpdateTableList();
            tableList.SelectedItem = updatedTable.Name;
        }

        public void AutoSave()
        {
            BattleIO auto = new BattleIO();
            if (tables != null)
            {
                auto.AutoSaveDPercentList(tables, Program.activeSettings);
            }
        }
    }
}
