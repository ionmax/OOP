using System;
using System.Collections.Generic;

namespace CourseWork.BusinessLogic
{
    public class Pawnshop
    {
        #region EVENTS
        // Event when client sold a thing
        protected internal event PawnshopStateHandler Sold;
        // Event when client bought a thing
        protected internal event PawnshopStateHandler Bought;
        #endregion
        #region FIELDS
        private Decimal income = 100000; // Income of the pawnshop
        private Decimal outcome = 0; // Outcome of the pawnshop
        private List<Client> Clients; // Client list of the pawnshop
        #endregion
        public List<Thing> ListOfThings { get; private set; } // Thing list of the pawnshop
        
        private void CallEvent(PawnshopEventArgs e, PawnshopStateHandler handler)
        {
            if (e != null)
                handler?.Invoke(this, e);
        }// Method for calling event
        // Calling an event. For every event we have unique virtual method
        protected virtual void OnSold(PawnshopEventArgs e) 
        {
            CallEvent(e, Sold);
        }
        protected virtual void OnBought(PawnshopEventArgs e)
        {
            CallEvent(e, Bought);
        }

        public Pawnshop()
        {
            Clients = new List<Client> // Creating new client for faster test our program
            {
                new Client("Andrey Andreev"),
                new Client("Vasiliy Pupkin"),
                new Client("Luba Sotkina")
            };

            ListOfThings = new List<Thing>();

            #region Creating things for faster test our program 
            BuyThingFromClient(Clients[0], "Iphone XS", 10000, false);
            BuyThingFromClient(Clients[1], "Gold Ring", 5000, false);
            BuyThingFromClient(Clients[2], "Laptop Asus", 8500, true);
            #endregion
        }

        // Method for buing thing from client
        public bool BuyThingFromClient(Client client, string nameOfThing, Decimal price, bool canBeBoughtByAnyone = false) 
        {
            if (client != null)
            {
                client.SellAThing(nameOfThing, price);
                ListOfThings.Add(new Thing(nameOfThing, client, price) { CanBeBoughtByAnyone = canBeBoughtByAnyone});

                History.AddThing(new Thing(nameOfThing, client, price), SoldOrBought.sold);
                outcome += price;

                // Notify that client sold a thing
                OnSold(new PawnshopEventArgs($"{client.FullName} sold {nameOfThing}",
                    new Thing(nameOfThing, client, price), client));

                return true;
            }
            else
                return false;
        }

        public bool SellThingToClient(Client client, Thing thing) // Method for selling thing to client
        {
            if (client != null) 
            {
                if (client.BuyBackThing(thing)) // Check if the client can buy the thing
                {
                    if (client == thing.Owner)
                    {
                        History.AddThing(new Thing(thing.Name, client, thing.TotalPrice(true)), SoldOrBought.bought); // Adding record in pawnshop history 
                        income += thing.TotalPrice(true);
                    }
                    else
                    {
                        History.AddThing(thing, SoldOrBought.bought); // Adding record in pawnshop history 
                        income += thing.TotalPrice(false);
                    }

                    ListOfThings.Remove(thing);
                    // Notify that client bought a thing
                    OnBought(new PawnshopEventArgs($"{client.FullName} bought {thing.Name}", thing, client));

                    return true;
                }
            }
            return false;
        }

        public bool TryCreateNewClient(string name) // Method for creating a new client
        {
            if (!Clients.Contains(new Client(name))) 
            {
                Clients.Add(new Client(name)); 
                return true;
            }

            return false;
        }

        public CreditHistory GetHistoryOfClient(string name)
        {
            foreach (Client client in Clients)
                if (client.FullName == name)
                    return client.GetHistory();
            return null;
        } // Method for getting history of the client 

        public List<Client> GetListOfClients() // Method for getting inform about clients 
        {
            return Clients;
        }
    }
}
