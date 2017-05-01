using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBattleTracking
{
    class DPercentTable
    {
        public List<int> startValues { get; private set; }
        public List<string> results { get; private set; }

        public DPercentTable()
        {
            startValues = new List<int>();
            results = new List<string>();
            startValues.Add(1);
            results.Add("Low Result");
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

        public void InsertResult(string result, int startValue)
        {

        }

    }
}
