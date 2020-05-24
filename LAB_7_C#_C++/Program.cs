using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB7
{
    class Program
    {
        static void Main(string[] args)
        {
            FloatList list = new FloatList();
            
            list.Add(-5);
            list.Add(-4);
            list.Add(-3);
            list.Add(-2);
            list.Add(-1);
            list.Add(0);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);

            foreach(float elem in list)
                Console.Write($"{elem} ");

            Console.WriteLine($"\nBigger than average: {list.BiggerThanAverage()}");

            Console.WriteLine("Deleted all negative numbers:");
            list.DeleteAllNegativeNums();

            foreach (float elem in list)
                Console.Write($"{elem} ");

            Console.ReadKey();
        }
    }
}
