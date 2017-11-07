using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBattleTracking
{
    public class DPercentTable
    {
        public List<int> startValues { get;  set; }
        public List<string> results { get;  set; }
        public string Name { get; set; }
        public int MaxVal { get; set; }

        public DPercentTable()
        {
            startValues = new List<int>();
            results = new List<string>();
        }

        public string evaluateResult(int input)
        {
            string result = "";
            for (int i = input; i > 0; i--)
            {
                if (startValues.Contains(i))
                {
                    result = results.ElementAt(startValues.IndexOf(i));
                    i = 0;
                }
            }
            return result;
        }

        public void AddResult(string result, int startValue)
        {
            startValues.Add(startValue);
            results.Add(result);
        }

        public void ClearTable()
        {
            startValues.Clear();
            results.Clear();
        }

        public int RollResult()
        {
            Random randy = new Random();
            int result = randy.Next(MaxVal) + 1;

            return result;
        }

    }
}
