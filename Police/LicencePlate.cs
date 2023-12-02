using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Police
{
    internal class LicencePlate
    {
        string plate;
        public string Plate
        {
            get => plate;
            set => plate = value.Length <= 10 ? value : "Wrong format";
        }
        public LicencePlate(string plate) => Plate = plate;
        public override string ToString() => plate;
    }
}
