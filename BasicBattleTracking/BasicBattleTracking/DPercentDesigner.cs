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
    public partial class DPercentDesigner : Form
    {
        private List<DPercentLine> lines;
        private const int Y_OFFSET = 28;
        private const int X_POS = 9;

        public DPercentPanel sendingForm { get; set; }

        private int currentMax { get; set; }
        public DPercentDesigner()
        {
            lines = new List<DPercentLine>();
            InitializeComponent();
            RedrawLines();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void DPercentDesigner_Load(object sender, EventArgs e)
        {
            if (lines.Count <= 0)
            {
                AddLine();
            }
            optionsBox.SelectedIndex = 0;
            
        }

        private void dPercentLine2_Load(object sender, EventArgs e)
        {

        }

        private void newLineButton_Click(object sender, EventArgs e)
        {
            AddLine();
        }

        private void AddLine()
        {
            DPercentLine newLine = new DPercentLine();
            newLine.sendingForm = this;
            if (lines.Count <= 0)
            {
                newLine.SetMin();
            }
            else
            {
                int newMin = lines.Last().GetMax() + 1;
                if (newMin > 0)
                {
                    newLine.SetMinToValue(newMin);
                }
            }
            if (lines.Count == 0)
            {
                newLine.SetMaxToValue(100);
            }
            lines.Add(newLine);
            RedrawLines();
            newLineButton.Select();
        }

        private void RedrawLines()
        {
            LinePanel.Controls.Clear();
            RedrawLines(0);
        }

        private void RedrawLines(int startIndex)
        {
            
            if (lines.Count > 0 && startIndex >= 0)
            {

                for (int i = startIndex; i < lines.Count; i++)
                {
                    lines.ElementAt(i).Location = new Point(X_POS, Y_OFFSET * i);
                    lines.ElementAt(i).LineID = i;
                    LinePanel.Controls.Add(lines.ElementAt(i));
                }

            }

            newLineButton.Location = new Point(X_POS, Y_OFFSET * lines.Count);
            LinePanel.Controls.Add(newLineButton);
            
        }

        private void LinePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void recalcButton_Click(object sender, EventArgs e)
        {
            RecalculateValues();
        }

        private void RecalculateValues()
        {
            if (lines.Count > 0)
            {
                int divisor = 100;
                switch (optionsBox.SelectedIndex)
                {
                    case 1: divisor = currentMax; break;
                    default: divisor = 100; break;
                }

                if (divisor < lines.Count)
                {
                    divisor = lines.Count;
                }

                int increment = divisor / lines.Count;
                int LastMax = 0;
                for (int i = 0; i < lines.Count; i++)
                {
                    lines.ElementAt(i).SetMinToValue(LastMax + 1);
                    lines.ElementAt(i).SetMaxToValue(LastMax + increment);
                    LastMax += increment;
                }
                if (lines.Last().GetMax() != divisor)
                    lines.Last().SetMaxToValue(divisor);
            }
        }

        public void UpdateMax()
        {
            if (lines.Count > 0)
            {
                int localMax = 0;
                foreach (DPercentLine line in lines)
                {
                    if (line.GetMax() > localMax)
                    {
                        localMax = line.GetMax();
                    }
                }
                if (localMax > 0)
                {
                    currentMax = localMax;
                    optionsBox.Items[1] = "Use Current Max (" + currentMax + ")";
                }
                else
                {
                    currentMax = 1;
                    optionsBox.Items[1] = "Use Current Max (" + currentMax + ")";
                }
            }
        }

        public void RemoveLine(int lineID)
        {
            if (lineID < lines.Count)
            {
                lines.RemoveAt(lineID);
                RedrawLines();
                newLineButton.Select();
            }

        }

        private void cancButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            BuildTable();
        }

        private void BuildTable()
        {
            DPercentTable output = new DPercentTable();
            string name = "";
            if (nameBox.Text == "")
            {
                name = "New Table";
            }
            else
            {
                name = nameBox.Text;
            }

            if (lines.Count <= 0)
            {
                MessageBox.Show("This table has no lines. Please add lines and make this table happy.", "Oops");
                return;
            }

            output.Name = name;
            List<int[]> gaps = new List<int[]>();
            for (int i = 0; i < lines.Count - 1; i++)
            {
                int min = lines.ElementAt(i).GetMin();
                if (min < 0)
                {
                    MessageBox.Show("One or more lines have invalid values. Please enter values for all fields.", "Oops!");
                    return;
                }
                string results;
                if (lines.ElementAt(i).GetEffect() == "")
                {
                    results = "No effect";
                }
                else
                {
                    results = lines.ElementAt(i).GetEffect();
                }
                if (lines.ElementAt(i).GetMax() < lines.ElementAt(i + 1).GetMin() - 1)
                {
                    int low = lines.ElementAt(i).GetMax() + 1;
                    int high = lines.ElementAt(i + 1).GetMin() - 1;
                    gaps.Add(new int[] { low, high });
                }
                output.AddResult(results, min);
            }
            output.AddResult(lines.Last().GetEffect(), lines.Last().GetMin());
            output.MaxVal = lines.Last().GetMax();
            if (gaps.Count > 0)
            {
                RaiseGapMessage(gaps);
            }
            else
            {
                sendingForm.addDPercentTable(output);
                this.Close();
            }

            
        }

        public void RecalculateAndSave()
        {
            optionsBox.SelectedIndex = 1;
            RecalculateValues();
            BuildTable();
        }

        public void AddBlanksAndSave(List<int[]> gaps)
        {
            foreach (int[] i in gaps)
            {
                DPercentLine newLine = new DPercentLine();
                newLine.SetMinToValue(i[0]);
                newLine.SetMaxToValue(i[1]);
                newLine.addEffect("No effect");
                InsertLineAndSort(newLine);
            }
            RedrawLines();
            BuildTable();
        }

        private void RaiseGapMessage(List<int[]> gaps)
        {
            TableErrorBox error = new TableErrorBox(gaps, this);
            error.ShowDialog();
        }

        public void InsertLineAndSort(DPercentLine newLine)
        {
            lines.Add(newLine);
            lines.OrderBy(c => c.GetMin());
        }
    }
}
