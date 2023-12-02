using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Police
{
    internal class Crime
    {
        int id;
        public int ID { get => id; private set => id = value < Violations.list.Count ? value : 0; }
        public DateTime DateTime { get; private set; }
        public string Place { get; private set; }
        public Crime(int id, DateTime dateTime, string place)
        {
            ID = id;
            DateTime = dateTime;
            Place = place;
        }
        public Crime(string violation, DateTime dateTime, string place)
        {
            foreach(KeyValuePair<int, string> kvp in Violations.list)
            {
                if (kvp.Value == violation)
                {
                    ID = kvp.Key;
                    break;
                }
                else ID = 0;
            }
            DateTime = dateTime;
            Place = place;
        }
        public override string ToString()
        {
            return $"{DateTime}:\t{Violations.list[ID].PadRight(30)}\t{Place}";
        }
    }
}
