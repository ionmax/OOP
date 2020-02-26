using System;

namespace OOP_lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input the number for subtraction: ");
            int number1 = Convert.ToInt32(Console.ReadLine());
            Subtraction(ref number1);
            Console.WriteLine("Result of subtraction = " + number1.ToString());
            Console.WriteLine();

            Console.Write("Input first number for comparison: ");
            int Num_1 = Convert.ToInt32(Console.ReadLine());
			Console.Write("Input second number for comparison: ");
			int Num_2 = Convert.ToInt32(Console.ReadLine());

            if (Compare(Num_1, Num_2) == true)
                Console.WriteLine("   A>B");
            else
                Console.WriteLine("   A!>B");

            Console.ReadKey();
        }
        static void Subtraction(ref int num)
        {
            int num_i;
            if(num == 0)
                num = -1;
            else if (num != 0)
                for (int mask = 0; mask < sizeof(int) * 8 - 1; mask++)
                {
                    num_i = num & (1 << mask);
                    if (num_i > 0)
                    {
                        for (int i = 0; i < mask + 1; i++)
                            num = num ^ (1 << i);
                        break;
                    }
                }

        }
        static bool Compare(int Num_1, int Num_2)
		{
            bool flag = false;
            int A, B;
            for (int mask = sizeof(int) * 8 - 1; mask >= 0; mask--)
            {
                A = Num_1 & (1 << mask);
                B = Num_2 & (1 << mask);
                if (A > B)
                {
                    flag = true;
                    break;
                }
                else if (A < B)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
    }
}
