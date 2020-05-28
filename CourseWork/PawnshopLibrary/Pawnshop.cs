using System;
using System.Collections.Generic;

namespace PawnshopLibrary
{
    public class Pawnshop
    {
        #region
        // Event when client try to buy a thing, but he is not in client list
        protected internal event PawnshopStateHandler NotExistedClientBoughtAThing;
        // Event when client sold a thing
        protected internal event PawnshopStateHandler Sold;
        // Event when client bought a thing
        protected internal event PawnshopStateHandler Bought;
        #endregion
        #region
        private Decimal income = 100000; // Income of the pawnshop
        private Decimal outcome = 0; // Outcome of the pawnshop
        private List<Client> Clients; // Client list of the pawnshop
        private List<Thing> listOfThings; // Thing list of the pawnshop
        #endregion

        private void CallEvent(PawnshopEventArgs e, PawnshopStateHandler handler)
        {
            if (e != null)
                handler?.Invoke(this, e);
        }
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

            listOfThings = new List<Thing>();

            #region Creating things for faster test our program 
            BuyThingFromClient(Clients[0], "Iphone XS", 10000);
            BuyThingFromClient(Clients[1], "Gold Ring", 5000);
            BuyThingFromClient(Clients[2], "Laptop Asus", 8500);
            #endregion
        }

        // Method for buing thing from client
        public bool BuyThingFromClient(Client client, string nameOfThing, Decimal price) 
        {
            if(client != null) // Checking if client isn't null
            {
                if(Clients.Contains(client)) // Checkin if pawnshop has this client
                {
                    client.SellAThing(nameOfThing, price); // Buy a thing from client
                    listOfThings.Add(new Thing(nameOfThing, client, price)); // Add new thing in thing list
                    // Adding record in pawnshop history
                    History.AddThing(new Thing(nameOfThing, client, price), SoldOrBought.bought);  
                    outcome += price;

                    // Notify that client sold a thing
                    OnSold(new PawnshopEventArgs($"{client.FullName} sold {nameOfThing}", 
                        new Thing(nameOfThing, client, price), client));

                    return true;
                }
                else // If we didn't find the client in client list, so we notify about it
                {
                    NotExistedClientBoughtAThing?.Invoke(this, 
                        new PawnshopEventArgs($"Create new client firstly! There is not such client as \"{client}\"", 
                            new Thing(nameOfThing, client, price), client));
                }
            }
            return false;
        }

        public bool SellThingToClient(Client client, Thing thing) // Method for selling thing to client
        {
            if (client != null) // Checking if client isn't null
            {
                if (Clients.Contains(client)) // Checkin if pawnshop has this client
                {
                    if (client.BuyBackThing(thing))
                    {
                        History.AddThing(thing, SoldOrBought.sold); // Adding record in pawnshop history
                        listOfThings.Remove(thing); // Deleting thing from thing list 
                        income += thing.Price; 

                        // Notify that client bought a thing
                        OnBought(new PawnshopEventArgs($"{client.FullName} bought {thing.Name}", thing, client));

                        return true;
                    }
                    else // If we didn't find the client in client list, so we notify about it
                    {
                        NotExistedClientBoughtAThing?.Invoke(this,
                            new PawnshopEventArgs($"Create new client firstly! There is not such client as \"{client}\"", 
                                new Thing(thing.Name, client, thing.Price), client));
                    }
                }
            }
            return false;
        }

        public bool TryCreateNewClient(string name) // Method for creating a new client
        {
            if (!Clients.Contains(new Client(name))) // Checkin if pawnshop has this client
            {
                Clients.Add(new Client(name)); // Adding new client in client list
                return true;
            }

            return false;
        }

        public List<Client> GetListOfClients() // Method for getting inform about clients 
        {
            return Clients;
        }
    }
}
