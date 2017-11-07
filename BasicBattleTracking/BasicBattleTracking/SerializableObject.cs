using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBattleTracking
{
    [Serializable()]
    public class SerializableObject : Object
    {

        public static List<SerializableObject> PackageObjectList(List<object> input)
        {
            List<SerializableObject> output = new List<SerializableObject>();
            foreach (object item in input)
            {
                output.Add((SerializableObject)item);
            }
            return output;

        }

    }
}
