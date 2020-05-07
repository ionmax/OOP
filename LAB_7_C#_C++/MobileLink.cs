using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp3
{
    class MobileLink
    {
        //public delegate void AccountHandler(string message);
        //public event AccountHandler Notify;

        public event EventHandler<string> Notify2;

        private bool isActiveted;
        public double TalkingSeconds { get; private set; }
        public decimal Account { get; private set; }

        public MobileLink()
        {
            isActiveted = false;
            TalkingSeconds = 0;
            Account = 0;
        }

        public void Acticate()
        {
            isActiveted = true;
        }

        public void Talk(int seconds)
        {
            if (seconds > 0)
            {
                if (isActiveted)
                    while (seconds != 0)
                    {
                        if (Account > 0)
                        {
                            TalkingSeconds += 1;
                            Account -= 1;
                            Console.WriteLine($"Your current account is : {Account}");
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            //Notify?.Invoke("No money on your account!");
                            Notify2?.Invoke(this, "No money on your account!");
                            break;
                        }
                    }
                else
                {
                    Console.WriteLine("Activate your account!");
                }
            }
            else
                throw new ArgumentException();
        }

        public void Add(int money)
        {
            if (money > 0)
            {
                Account += money;
                //Notify?.Invoke($"You add {money} on you account!");
                Notify2?.Invoke(this, $"You add {money} on you account!");
            }
            else
                throw new ArgumentException();
        }
    }
}
