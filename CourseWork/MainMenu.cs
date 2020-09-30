using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CourseWork.BusinessLogic;
using System.IO;

namespace CourseWork
{
    public static class MainMenu
    {   
        private static Pawnshop pawnshop; // The pawnshop
        private static bool isRunning; // Checking if pawnshop is still running

        static public void StartProgram() // Start of a program(creating objects, initialization all fields)
        {
            pawnshop = new Pawnshop();
            pawnshop.Bought += ReactOnBought;
            pawnshop.Sold += ReactOnSold;
            isRunning = true;
            Console.WriteLine("Welcome to the pawnshop by Misha Storozhuk!");
            Running();
        }

        static private void Running() // Running program until field isRunning is true
        {
            while (isRunning)
            {
                try
                {
                    WritePoints();
                    Choice();
                }
                catch(Exception ex)
                { File.AppendAllLines(@"/log.txt", new string[] { DateTime.Now.ToString(), ex.Message, ex.Source}); }
            }
        }

        static private void WritePoints()  // Method for writing all points(operations) of pawnshop
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Choose the action:");
            Console.WriteLine("1 - Borrow money");
            Console.WriteLine("2 - Buy back a thing");
            Console.WriteLine("3 - Show list of things");
            Console.WriteLine("4 - Show all clients");
            Console.WriteLine("5 - Show information about client");
            Console.WriteLine("6 - Create new client");
            Console.WriteLine("7 - Show history of pawnshop");
            Console.WriteLine("8 - Close program");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static private void Choice() // Method for choosing the point 
        {
            bool parsed = int.TryParse(Console.ReadLine(), out int a); // Trying convert to Int32

            if(!parsed || a < 1 || a > 8) // Checkin if chosen point exists
            {
                Console.Clear();
                Console.WriteLine("Entered incorrect value!!!");
                return;
            }

            Console.Clear();
            switch(a) // Run method depend on choice of client
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
                    ShowHistotyOfPawnshop();
                    break;
                case 8:
                    isRunning = false;
                    break;
            }
        }

        private static void ShowHistotyOfPawnshop() // Method out all history of pawnshop(sold and bought things)
        {
            List<KeyValuePair<Thing, SoldOrBought>> history = History.GetHistoryOfPawnshop();
            if (history.Count > 0)
                Parallel.ForEach<KeyValuePair<Thing, SoldOrBought>>(history, // using async programming for faster execution
                            keyValue => // using lambda expression
                            {
                                Console.WriteLine($"{keyValue.Key.Owner} {keyValue.Value} {keyValue.Key.Name}" +
                                    $", Price: {keyValue.Key.Price}");
                            });
        }

        static private void BorrowMoney() // Method for borrowin money in pawnshop
        {
            while (true)
            {
                Console.WriteLine("Write your name or \"exit\":");
                string nameOfClient = Console.ReadLine();

                if (nameOfClient == "exit")
                    break;

                Client ourClient = null;
                foreach (Client client in pawnshop.GetListOfClients())
                    if (client.Equals(new Client(nameOfClient)))
                        ourClient = client;
                

                Console.WriteLine("Write name of the thing:");
                string nameOfThing = Console.ReadLine();

                decimal price = 0;
                while (true)
                {
                    Console.WriteLine("Write price of the thing:");
                    bool parsed = decimal.TryParse(Console.ReadLine(), out price);
                    if (parsed)
                        break;
                    Console.WriteLine("Incorrect input!!!");
                }

                bool isBought;
                while (true)
                {
                    Console.WriteLine("Can anyone buy the thing? \"Yes\" or \"No\" ");
                    string canAnyoneBuy = Console.ReadLine();

                    if (canAnyoneBuy == "Yes")
                    {
                        isBought = pawnshop.BuyThingFromClient(ourClient, nameOfThing, price, true);
                        break;
                    }
                    if (canAnyoneBuy == "No")
                    {
                        isBought = pawnshop.BuyThingFromClient(ourClient, nameOfThing, price, false);
                        break;
                    }
                }
                if(!isBought)
                    Console.WriteLine($"No such a client as {nameOfClient}");
            }

        }

        static private void BuyBack() // Method for buying thing back by client
        {
            while (true)
            {
                Console.WriteLine("Write your name or \"exit\":");
                string nameOfClient = Console.ReadLine();

                if (nameOfClient == "exit")
                    break;

                Client ourClient = null;
                foreach (Client client in pawnshop.GetListOfClients())
                    if (client.Equals(new Client(nameOfClient)))
                        ourClient = client;

                Console.WriteLine("Write name of the thing:");
                string nameOfThing = Console.ReadLine();

                decimal price = 0;
                while (true)
                {
                    Console.WriteLine("Write price of the thing:");
                    bool parsed = decimal.TryParse(Console.ReadLine(), out price);
                    if (parsed)
                        break;
                    Console.WriteLine("Incorrect input!!!");
                }

                Thing ourThing = null;
                foreach (Thing thing in pawnshop.ListOfThings)
                    if (thing.Equals(new Thing(nameOfThing, ourClient, price)))
                        ourThing = thing;
                bool isSold = pawnshop.SellThingToClient(ourClient, ourThing);

                if (!isSold)
                    Console.WriteLine($"No such a client as {nameOfClient} or thing as {nameOfThing}");

            }
        }

        static private void ShowThings() // Method out all things in pawnshop(name/price)
        {
            
            Parallel.ForEach<Thing>(pawnshop.ListOfThings, // using async programming for faster execution
                thing => 
                { Console.WriteLine($"Name of thing:{thing.Name}, Price: {thing.Price}, " +
                    $"Owner: {thing.Owner}, Can be sold to anyone: {thing.CanBeBoughtByAnyone}"); });
            
        }

        static private void ShowClients() // Method out all clients' names
        {
            Console.WriteLine("Name of clients:");
            Parallel.ForEach<Client>(pawnshop.GetListOfClients(), 
                client => { Console.WriteLine(client.FullName); });
            Console.WriteLine("\n");
        } 

        static private void ShowClientInf() // Method out all history of client(sold and bought things)
        {
            Console.Clear();
            Console.WriteLine("Enter the name of the client: ");

            List<Client> list = pawnshop.GetListOfClients();
            while (true)
            {
                string name = Console.ReadLine();

                if (name == "exit")
                    break;

                CreditHistory history = pawnshop.GetHistoryOfClient(name);

                List<KeyValuePair<Thing, SoldOrBought>> dict = history?.GetRecords();

                if(dict != null)
                {
                    if (dict.Count > 0)
                    {
                        Console.WriteLine($"{name} history: ");
                        Parallel.ForEach<KeyValuePair<Thing, SoldOrBought>>(dict, // using parallel programming for faster execution
                            keyValue => // using lambda expression
                            {
                                Console.WriteLine($"Name of thing:{keyValue.Key.Name}" +
                                    $", Price: {keyValue.Key.Price}, {keyValue.Value}");
                            });
                    }
                    else
                        Console.WriteLine("History is empty");
                }
                else
                {
                    Console.WriteLine("Not such a client!");
                }
                
                Console.WriteLine("Enter new client name or \"exit\"");
            }
        } 

        static private void CreateNewClient() // Method for creating new client
        {
            Console.Clear();
            Console.WriteLine("Enter fullname of new client:");

            while (true)
            {
                string name = Console.ReadLine();

                if (name == "exit")
                    break;

                bool created = pawnshop.TryCreateNewClient(name);

                if (created)
                    Console.WriteLine("Client created succesfully!");
                else
                    Console.WriteLine("");
                Console.WriteLine("Enter new client or \"exit\"");
            }
        }

        static public void ReactOnSold(object sender, PawnshopEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        static public void ReactOnBought(object sender, PawnshopEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
