using System;
using System.Collections.Generic;
using System.Text;

namespace PawnshopLibrary
{
    public class Client : IClient
    {
        private CreditHistory history; // History of purchases
        static int count = 1; // Count for creating unique id for every client
        public int _id; // Id every client for identification them
        public string FullName { set; get; } // Fullname of client

        public Client(string fullName) // Constructor with 1 parametr(fullname)
        {
            FullName = fullName; 
            _id = count; 
            count++; // Increment of count for future creating client 
            this.history = new CreditHistory(); 
        }

        public void SellAThing(string name, Decimal price) // Methon when client want to sell a thing
        {
            history.AddThing(new Thing(name, this, price), SoldOrBought.sold);
        }

        public bool BuyBackThing(Thing thing) // Methon when client want to buy a thing
        {
            // Client can buy a thing if he is an owner or time of the thing if passed
            if(thing.Owner.Equals(this) || !thing.HasAOwner) 
            {
                history.AddThing(thing, SoldOrBought.bought);
                return true;
            }
            return false;
        }

        public override string ToString() // Overriding method for out fullname 
        {
            return FullName;
        }

        public override int GetHashCode() // Overriding method for getting hashcode for Equals method
        {
            return _id.GetHashCode();
        }

        public override bool Equals(object obj) // Overriding method for comparing clients
        {
            Client client = obj as Client;
            if (client != null)
                return (client.FullName == FullName) && (client._id == _id);
            return false;
        }
    }
}
