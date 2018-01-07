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
    public partial class DiceTab : UserControl
    {
        public CharacterSheet sheet { get; set; }
        public DiceTab()
        {
            InitializeComponent();
        }

        private void DiceTab_Load(object sender, EventArgs e)
        {

        }

        private void RollDice(int dType, TextBox countBox, TextBox modBox, TextBox outputBox)
        {
            try
            {
                int count = Int32.Parse(countBox.Text);
                int mod = Int32.Parse(modBox.Text);
                DiceRoller roller = new DiceRoller(count, dType, mod);
                int result = roller.RollDice();
                outputBox.Text = result.ToString();
                if(sheet != null)
                {
                    sheet.WriteToLog("=====GENERIC ROLL=====");
                    sheet.WriteToLog("Rolling " + count + "d" + dType + ".");
                    string resultLog = "Result: " + result + " {";
                    foreach(int roll in roller.DiceRolls)
                    {

                        resultLog += roll.ToString();
                        if (roller.DiceRolls.IndexOf(roll) < roller.DiceRolls.Count - 1)
                            resultLog += ",";
                    }
                    if (resultLog[resultLog.Length - 1] == ',')
                        resultLog = resultLog.Substring(0, resultLog.Length - 1);
                    resultLog += "}";
                    sheet.WriteToLog(resultLog);
                }
            }
            catch { }
        }

        private void rollClick(object sender, EventArgs e)
        {
            Button roller = sender as Button;
            char keyVal = roller.Name[1];
            int type = 0;
            List<int> typeResults = new List<int>();
            if (keyVal == 'x')
            {
                try
                {
                    type = Int32.Parse(dxTypeBox.Text);
                }
                catch
                {

                }
            }
            else
            {
                typeResults = GetTypeNumber(roller.Name);
                type = typeResults.ElementAt(0);
            }
            TextBox countBox = new TextBox();
            TextBox modBox = new TextBox();
            TextBox outBox = new TextBox();

            foreach(Control c in Controls)
            {
                if(c is TextBox)
                {
                    string namePrefix = roller.Name[0].ToString();
                    if (typeResults.Count > 0)
                    {
                        for (int i = 1; i <= typeResults.ElementAt(1); i++)
                            namePrefix += roller.Name[i];
                    }
                    else
                    {
                        namePrefix += "x";
                    }
                    if (c.Name == namePrefix + "CountBox")
                        {
                            countBox = c as TextBox;
                        }
                    if (c.Name == namePrefix + "ModBox")
                    {
                        modBox = c as TextBox;
                    }
                    if (c.Name == namePrefix + "ResultBox")
                    {
                        outBox = c as TextBox;
                    }
                }
            }

            RollDice(type, countBox, modBox, outBox);


        }

        private List<int> GetTypeNumber(string inputString)
        {
            int numCount = 0;
            for(int i = 1; i < inputString.Length; i++)
            {
                char test = inputString[i];
                if (char.IsNumber(test))
                    numCount++;
            }

            string sub = inputString.Substring(1, numCount);
            int type = Int32.Parse(sub);
            return new List<int>(){type, numCount};

        }
    }
}
