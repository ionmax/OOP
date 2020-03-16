using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            Console.WriteLine("Enter strings:");
            string[] strings = Console.ReadLine().Split();

            Words MyWords = new Words(strings);

            Console.WriteLine($"The number of consonant letters: {MyWords.Consonant}");

            Console.Write("Write the word you want to see:");
            i = int.Parse(Console.ReadLine());

            Console.WriteLine($"The {i} string is: {MyWords[i - 1]}");

            Console.ReadKey();
        }
    }
}
