using System;

namespace CourseWork.BusinessLogic
{
    public class Thing
    {
        private DateTime end; // End term when thing is cannot be sold to not an owner
        public Client Owner { private set; get; } // An owner of a thing
        public Decimal Price { get; } // Price of a thing
        public string Name { get; set; } // The name of a thing

        public bool CanBeBoughtByAnyone { set; get; }

        public bool HasAOwner // Checking if time is already passed
        {
            get
            {
                if (DateTime.Now < end)
                    return true;
                return false;
            }
        }

        public Thing (string name, Client owner, Decimal price) // Ctor with parametrs
        {
            Name = name;
            Owner = owner;
            Price = price;
            end = DateTime.Now.AddMonths(2);
            CanBeBoughtByAnyone = true;
        }

        public decimal TotalPrice(bool BuyingByOwner = false) // Calculate total price if the client want to buy any thing and he is the past owner
        {
            if (BuyingByOwner)
                return Decimal.Multiply(Price, (decimal)1.2);
            return Price;
        }
        public override bool Equals(object obj) // Overriding object method Equals for comparing things
        {
            Thing thing = obj as Thing;
            if (thing != null)
                return (this.Name == thing.Name && this.Price == thing.Price && this.Owner == thing.Owner);
            return false;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Price.GetHashCode() + this.Owner.GetHashCode();
        }
    }
}
