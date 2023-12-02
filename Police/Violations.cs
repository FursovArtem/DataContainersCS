using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Police
{
    internal class Violations
    {
        public static readonly Dictionary<int, string> list = new Dictionary<int, string>()
        {
            [0] = "N/A",
            [1] = "Парковка в неположенном месте",
            [2] = "Ремень безопасности",
            [3] = "Пересечение сплошной",
            [4] = "Превышение скорости",
            [5] = "Проезд на красный",
            [6] = "Езда в нетрезвом состоянии",
            [7] = "Оскорбление офицера",
            [8] = "Сопротивление при аресте",
            [9] = "Не пропустил пешехода",
            [10] = "Езда по встречной полосе",
            [11] = "Нарушение правил переезда ж/д",
            [12] = "Оставление места ДТП"
        };
    }
}
