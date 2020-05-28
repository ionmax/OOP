using System;
using System.Collections.Generic;
using System.Text;

namespace PawnshopLibrary
{
    public class CreditHistory // History of client purchases 
    {
        // Collection for saving all bought or sold thing of client
        private Dictionary<Thing, SoldOrBought> ThingAndSold; 
        public CreditHistory()
        {
            ThingAndSold = new Dictionary<Thing, SoldOrBought>(); // Creating new collection
        }

        public void AddThing(Thing thing, SoldOrBought soldOrBought) // Add new record
        {
            ThingAndSold.Add(thing, soldOrBought);
        }
    }
}
