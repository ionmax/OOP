using System;

namespace ConsoleApp3
{
    delegate string Delegate(string[] arr);

    class Program
    {
        static void Main(string[] args)
        {
            //Delegate @delegate;
            //@delegate = TakeString;

            //string str = Console.ReadLine();

            //string[] arr = str.Split();

            //Console.WriteLine(@delegate(arr));

            //Console.ReadKey();

            MobileLink mob = new MobileLink();

            mob.Notify2 += ZeroAccount;
            //mob.Talk(10);

            mob.Acticate();

            //mob.Talk(10);

            mob.Add(5);
            mob.Talk(6);
            Console.ReadKey();
        }

        public static void ZeroAccount(object sender, string message)
        {
            Console.WriteLine(message);
            MobileLink mob = sender as MobileLink;

            if(mob != null)
                Console.WriteLine($"Total talking second: {mob.TalkingSeconds}");
        }

        static string TakeString(string[] arr)
        {
            string res = null;
            try
            {
                for (int i = 0; i < arr.Length; i++)
                    res += arr[i][i].ToString();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something went wrong:  " + ex.Message);
                return "";
            }
            return res;
        }
    }
}
