using System;

namespace CourseWork.BusinessLogic
{
    public class Client : IClient
    {
        private CreditHistory history; // History of purchases
        public string FullName { set; get; } // Fullname of client

        public Client(string fullName) // Constructor with 1 parametr(fullname)
        {
            FullName = fullName;
            this.history = new CreditHistory();
        }

        public void SellAThing(string name, Decimal price) // Methon when client want to sell a thing
        {
            history.AddThing(new Thing(name, this, price), SoldOrBought.sold);
        }

        public bool BuyBackThing(Thing thing) // Methon when client want to buy a thing
        {
            // Client can buy a thing if he is an owner 
            if (thing.Owner.Equals(this))
            {
                history.AddThing(new Thing(thing.Name, thing.Owner, thing.TotalPrice(true)), SoldOrBought.bought);
                return true;
            }

            // Client can buy a thing if time is passed or past client accept
            if (!thing.HasAOwner || thing.CanBeBoughtByAnyone)
            {
                history.AddThing(thing, SoldOrBought.bought);
                return true;
            }

            return false;
        }

        public CreditHistory GetHistory() // Returns history of client
        {
            return history;
        }

        public override string ToString() // Overriding method for out fullname 
        {
            return FullName;
        }

        public override int GetHashCode() // Overriding method for getting hashcode for Equals method
        {
            return FullName.GetHashCode();
        }

        public override bool Equals(object obj) // Overriding method for comparing clients
        {
            Client client = obj as Client;
            if (client != null)
                return (client.FullName == FullName);
            return false;
        }
    }
}
