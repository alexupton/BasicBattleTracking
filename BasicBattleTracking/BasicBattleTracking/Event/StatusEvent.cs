using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicBattleTracking.Forms;
using BasicBattleTracking.FighterDetail;
using BasicBattleTracking;

namespace BasicBattleTracking.Event
{
    public class StatusEvent : Event
    {
        public Status status { get; set; }
        public override object Execute()
        {
            return null;
        }
    }
}
