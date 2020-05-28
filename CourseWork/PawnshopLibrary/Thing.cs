using System;
using System.Collections.Generic;
using System.Text;

namespace PawnshopLibrary
{
    public class Thing
    {
        private DateTime end; // End term when thing is cannot be sold to not an owner
        public Client Owner { private set; get; } // An owner of a thing
        public Decimal Price { get; } // Price of a thing
        public string Name { get; set; } // The name of a thing

        public bool HasAOwner // Checking if time is already passed
        {
            get
            {
                if (DateTime.Now < end)
                    return true;
                return false;
            }
        }

        public Thing (string name, Client owner, Decimal price)
        {
            Name = name;
            Owner = owner;
            Price = price;
            end = DateTime.Now.AddMonths(2);
        }
    }
}
