using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Police
{
    internal class Base
    {
        Dictionary<LicencePlate, List<Crime>> police_base;
        public Base(Dictionary<LicencePlate, List<Crime>> police_base)
        {
            this.police_base = new Dictionary<LicencePlate, List<Crime>>(police_base);
        }
        public void Print()
        {
            foreach (KeyValuePair<LicencePlate, List<Crime>> i in police_base)
            {
                Console.WriteLine($"{i.Key}:");
                foreach (Crime j in i.Value) Console.WriteLine(j);
                Console.WriteLine();
            }
        }
        public void Save(string filename)
        {
            StreamWriter sw = new StreamWriter(filename);
            foreach (KeyValuePair<LicencePlate, List<Crime>> i in police_base)
            {
                sw.WriteLine(i.Key + ":");
                foreach (Crime j in i.Value) sw.WriteLine(j);
                sw.WriteLine();
            }
            sw.Close();
            Process.Start("notepad", filename);
        }
        public static Base Load(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            Dictionary<LicencePlate, List<Crime>> load = new Dictionary<LicencePlate, List<Crime>>();
            string[] violators = Regex.Split(sr.ReadToEnd(), "(?:\\r\\n){2,}(?=.)");
            for (int i = 0; i < violators.Length; i++)
            {
                string[] split = Regex.Split(violators[i], "(?::\\r\\n)|(?::\\s)|(?=ул\\.)|(?:\\r\\n)(?=.)");
                for (int j = 0; j < split.Length; j++) split[j] = split[j].Trim();
                List<Crime> crimes = new List<Crime>();
                for (int j = 0; j < GetNumberOfViolations(split); j++)
                {
                    string[] dateTime = Regex.Split(split[j * 3 + 1], "(?:\\.)|(?:\\s)|(?::)");
                    crimes.Add(new Crime(split[j * 3 + 2],
                        new DateTime
                        (Convert.ToInt32(dateTime[2]), Convert.ToInt32(dateTime[1]),
                        Convert.ToInt32(dateTime[0]), Convert.ToInt32(dateTime[3]),
                        Convert.ToInt32(dateTime[4]), Convert.ToInt32(dateTime[5])), 
                        split[j * 3 + 3]));
                }
                load.Add(new LicencePlate(split[0]), crimes);
            }
            sr.Close();
            return new Base(load);
        }
        public static int GetNumberOfViolations(string[] array) => (array.Count() - 1) / 3;
    }
}
