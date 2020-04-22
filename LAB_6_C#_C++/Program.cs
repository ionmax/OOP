using System;
using System.IO;

namespace OOP_LAB_6
{
    class Program
    {
        public static void Log(string message)
        {
            File.WriteAllText("log.txt", message);
        }

        static void Main(string[] args)
        {
            try
            {
                Expression exp1 = new Expression(0, 2, 25, 0);
                //Expression exp1 = new Expression(0, 2, 24, 0);
                //exp1 = exp1 + 5;
                //exp1 = exp1 + new Expression(1,2,3,4);
                //exp1 += 5;
                //exp1 = exp1 - 5;
                //exp1 -= new Expression(1, 1, 1, 1);

                Console.WriteLine(exp1.Calculate());
            }
            catch(DivideByZeroException ex)
            {
                Log($"Type of exception: {ex.GetType()}, message: {ex.Message}, time {DateTime.Now}");
            }
            catch(InvalidOperationException ex)
            {
                Log($"Type of exception: {ex.GetType()}, message: {ex.Message}, time {DateTime.Now}");
            }
            catch(Exception ex)
            {
                Log($"Type of exception: {ex.GetType()}, message: {ex.Message}, time {DateTime.Now}");
            }
            finally
            {
                Console.WriteLine("The end");
            }

            Console.ReadKey();
        }
    }
}
