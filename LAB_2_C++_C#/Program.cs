using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OOP_LAB2_CPP
{
    class Program
    {
        static void Main()
        {
            int strToDel, chars = 0;
            int amountOfStrs = 0;

            MyStringText.Text text = new MyStringText.Text();
            string inputing;

            Console.Write("Enter amount of strings: ");
            amountOfStrs = int.Parse(Console.ReadLine());
            Console.WriteLine();

            for (int i = 0; i < amountOfStrs; i++)
            {
                Console.Write($"\nEntered {i + 1} string: ");
                inputing = Console.ReadLine();

                MyStringText.MyString array = new MyStringText.MyString(inputing.Length);

                for (int j = 0; j < array.length; j++)
                {
                    array[j] = inputing[j];
                }
                text.AddStr(array);
                inputing.Remove(0);
            }

            Console.Write("\nEnter strings :");
            text.Print();

            Console.Write("\n---------------------------\n");

            Console.Write("First letters to upper register: ");
            text.MyToUpper();
            text.Print();

            Console.Write("\n---------------------------");

            Console.Write("\nThe key-word is: ");
            text.TakeAKey().Print();

            Console.Write("\n---------------------------");

            Console.Write("\nInput the amount of chars in string: ");
            chars = int.Parse(Console.ReadLine());
            Console.Write($"The amount of strings with this numb of chars is:  {text.TheLength(chars).ToString()}");

            Console.Write("\n---------------------------");

            Console.Write("\nEnter number of string to delete: ");
            strToDel = int.Parse(Console.ReadLine());
            text.DeleteStr(strToDel);

            Console.WriteLine($"After deleteting {strToDel} string: ");
            text.Print();

            Console.WriteLine("\n---------------------------");

            Console.WriteLine("After cleaning: ");
            text.CleatText();
            text.Print();

            Console.ReadKey();
        }
    }
    
}
