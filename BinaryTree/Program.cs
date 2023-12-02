#define BASE_CHECK
//#define ERASE_CHECK
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if BASE_CHECK
            Random random = new Random(0);
            Console.Write("Введите размер дерева: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Tree tree = new Tree();
            for (int i = 0; i < n; i++)
            {
                tree.Insert(random.Next(100));
            }
            tree.Print();
            //tree.Clear();
            try
            {
                TreePerformance<int>.Measure("Минимальное значение в дереве: ", tree.Min);
                TreePerformance<int>.Measure("Максимальное значение в дереве: ", tree.Max);
                TreePerformance<int>.Measure("Сумма элементов в дереве: ", tree.Sum);
                TreePerformance<int>.Measure("Количество элементов в дереве: ", tree.Count);
                TreePerformance<double>.Measure("Среднее арифметическое элементов в дереве: ", tree.Average);
                TreePerformance<int>.Measure("Глубина дереве: ", tree.Depth);
                Console.Write("Введите удаляемое значение: ");
                int value = Convert.ToInt32(Console.ReadLine());
                tree.Erase(value);
                tree.Print();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            Console.WriteLine($"Количество элементов в дереве: {tree.Count()}");

            /*UniqueTree u_tree = new UniqueTree();
            for (int i = 0; i < n; i++)
            {
                u_tree.Insert(random.Next(100));
            }
            u_tree.Print();
            Console.WriteLine($"Минимальное значение в дереве: {u_tree.Min()}");
            Console.WriteLine($"Максимальное значение в дереве: {u_tree.Max()}");
            Console.WriteLine($"Сумма элементов в дереве: {u_tree.Sum()}");
            Console.WriteLine($"Количество элементов в дереве: {u_tree.Count()}");
            Console.WriteLine($"Среднее арифметическое элементов в дереве: {u_tree.Average()}"); */
#endif
#if ERASE_CHECK
            Tree tree = new Tree(50, 25, 75, 16, 32, 64, 80);
            tree.Print();
            Console.WriteLine($"Глубина дереве: {tree.Depth()}");
            Console.Write("Введите удаляемое значение: ");
            int value = Convert.ToInt32(Console.ReadLine());
            tree.Erase(value);
            tree.Print(); 
#endif

        }
    }
}
