using System;
using System.Collections.Generic;
using System.Text;
using PawnshopLibrary;

namespace CourseWork.Program_Files
{
    static class MainMenu
    {   
        private static Pawnshop pawnshop;
        private static bool isRunning;

        static public void StartProgram()
        {
            pawnshop = new Pawnshop();
            isRunning = true;
            Console.WriteLine("Welcome to the pawnshop by Misha Storozhuk!");
            Running();
        }

        static private void Running()
        {
            while (isRunning)
            {
                WritePoints();
                Choice();
            }
        }

        static private void WritePoints()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Choose the action:");
            Console.WriteLine("1 - Borrow money");
            Console.WriteLine("2 - Buy back a thing");
            Console.WriteLine("3 - Show list of things");
            Console.WriteLine("4 - Show all clients");
            Console.WriteLine("5 - Show information about client");
            Console.WriteLine("6 - Create new client");
            Console.WriteLine("7 - Close program");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static private void Choice()
        {
            bool parsed = int.TryParse(Console.ReadLine(), out int a);

            if(!parsed || a < 1 || a > 7)
            {
                Console.Clear();
                Console.WriteLine("Entered incorrect value!!!");
                WritePoints();
                Choice();
            }

            Console.Clear();
            switch(a)
            {
                case 1:
                    BorrowMoney();
                    break;
                case 2:
                    BuyBack();
                    break;
                case 3:
                    ShowThings();
                    break;
                case 4:
                    ShowClients();
                    break;
                case 5:
                    ShowClientInf();
                    break;
                case 6:
                    CreateNewClient();
                    break;
                case 7:
                    isRunning = false;
                    break;
            }
        }

        static private void BorrowMoney()
        {

        }

        static private void BuyBack()
        {

        }

        static private void ShowThings()
        {

        }

        static private void ShowClients()
        {
            Console.WriteLine("Name of clients:");
            foreach(Client client in pawnshop.GetListOfClients())
                Console.WriteLine(client.FullName);
            Console.WriteLine("\n");
        }

        static private void ShowClientInf()
        {

        }

        static private void CreateNewClient()
        {
            Console.Clear();
            Console.WriteLine("Enter fullname of new client:");

            while (true)
            {
                string name = Console.ReadLine();

                if (name == "exit")
                    break;

                bool created = pawnshop.CreateNewClient(name);

                if (created)
                    Console.WriteLine("Client created succesfully!");
                Console.WriteLine("Enter new client or \"exit\"");
            }
        }
    }
}
