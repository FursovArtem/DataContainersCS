using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal class TreePerformance<T>
    {
        public delegate T F();
        public static void Measure(string message, F method)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.WriteLine($"{message}{method()}");
            sw.Stop();
            Console.WriteLine($"Вычислено за: {sw.Elapsed}");
        }








        public delegate T Test(T x);
        public static T Func(Test method, T param)
        {
            return method(param);
        }
    }
}