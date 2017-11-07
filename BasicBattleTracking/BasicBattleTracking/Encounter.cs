using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicBattleTracking
{
    [Serializable]
    public class Encounter
    {
        public int Turn { get; set; }
        public List<Fighter> combatants { get; set; }
        public List<Events.EncounterEvent> encounterEvents { get; set; }
        public MainWindow main { get; set; }
        public Fighter ActiveFighter { get; set; }

        public Encounter()
        {
            Turn = 0;
            combatants = new List<Fighter>();
            encounterEvents = new List<Events.EncounterEvent>();
            main = new MainWindow();
            ActiveFighter = new Fighter();
        }

        public List<Fighter> RollInit(List<Fighter> input)
        {
            List<Fighter> PCs = new List<Fighter>();
            List<Fighter> Enemies = new List<Fighter>();

            foreach (Fighter f in input)
            {
                if (f.isPC)
                    PCs.Add(f);
                else
                    Enemies.Add(f);
            }

            combatants.Clear();

            PC_Initiative initWindow = new PC_Initiative();
            initWindow.setPCList(PCs);

            Random randy = new Random();

            foreach (Fighter enemy in Enemies)
            {
                enemy.Initiative = (randy.Next(20) + 1 + enemy.InitBonus);
                foreach (Attack atk in enemy.attacks)
                {
                    atk.atkCount = 0;
                }
                combatants.Add(enemy);
            }

            if (initWindow.ShowDialog() == DialogResult.Cancel)
            {
                return input;
            }
            else
            {
                List<Fighter> orderedFighterList = combatants.OrderByDescending(c => c.Initiative).ThenByDescending(c => c.Dex).ToList();
                return orderedFighterList;
            }
        }

    }
}
