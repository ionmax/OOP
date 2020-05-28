using System;
using System.Collections.Generic;
using System.Text;

namespace PawnshopLibrary
{
    public static class History // History of pawnshop
    {
        // Collection for saving all bought or sold things in pawnshop
        private static Dictionary<Thing, SoldOrBought> list; 
        static History()
        {
            list = new Dictionary<Thing, SoldOrBought>(); // Creating new collection
        }

        public static void AddThing(Thing thing, SoldOrBought soldOrBought) // Add new record
        {
            list.Add(thing, soldOrBought);
        }
    }
}
