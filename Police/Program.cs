using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Police
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string delimiter = "\n-----------------------------------------------\n";
            #region CHECK
            /*LicencePlate plate = new LicencePlate("m137bb");
                Console.WriteLine(plate);
                Crime crime = new Crime(1, new DateTime(2023, 05, 23), "ул. Ленина");
                Console.WriteLine(crime);*/
            #endregion

            Dictionary<LicencePlate, List<Crime>> police_base = new Dictionary<LicencePlate, List<Crime>>()
            {
                [new LicencePlate("m137bb")] = new List<Crime>
                {
                    new Crime(1, new DateTime(2023, 05, 23, 13, 30, 00), "ул. Ленина"),
                    new Crime(2, new DateTime(2023, 05, 23, 13, 33, 00), "ул. Ленина")
                },

                [new LicencePlate("a001bb")] = new List<Crime>
                {
                    new Crime(3, new DateTime(2023, 06, 12, 19, 02, 00), "ул. Космонавтов"),
                    new Crime(4, new DateTime(2023, 06, 12, 19, 05, 00), "ул. Космонавтов"),
                    new Crime(5, new DateTime(2023, 06, 12, 19, 05, 00), "ул. Космонавтов")
                },

                [new LicencePlate("a123bb")] = new List<Crime>
                {
                    new Crime(6, new DateTime(2023, 06, 12, 19, 02, 00), "ул. Парижской комунны"),
                    new Crime(7, new DateTime(2023, 06, 12, 19, 02, 00), "ул. Парижской комунны"),
                    new Crime(8, new DateTime(2023, 06, 12, 19, 02, 00), "ул. Шолом Алейхома")
                }
            };

            Base @base = new Base(police_base);
            @base.Print();
            @base.Save("base.txt");

            Console.WriteLine(delimiter);

            Base load = Base.Load("base.txt");
            load.Print();
        }
    }
}
