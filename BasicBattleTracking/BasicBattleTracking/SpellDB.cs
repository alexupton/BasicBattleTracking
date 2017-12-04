using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BasicBattleTracking
{
    public static class SpellDB
    {
        public static string dbPath { get; set; }

        public static Spell selectSpell(string candidate)
        {
            Spell output;
            if (File.Exists(dbPath))
            {
                return null; //debug output
            }
            else
            {
                return null;
            }
        }
        //debug method
        public static string[] GetDBLines()
        {
            string[] file;
            if (File.Exists(dbPath))
            {
                file = File.ReadAllLines(dbPath);
                return file;
            }
            else
            {
                return new string[]{""};
            }
        }
    }
}
