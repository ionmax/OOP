using System.Collections.Generic;

namespace CourseWork.BusinessLogic
{
    public static class History // History of pawnshop
    {
        // Collection for saving all bought or sold things in pawnshop
        private static List<KeyValuePair<Thing, SoldOrBought>> records; 
        static History()
        {
            records = new List<KeyValuePair<Thing, SoldOrBought>>(); // Creating new collection
        }

        public static List<KeyValuePair<Thing, SoldOrBought>> GetHistoryOfPawnshop() // Returns history of pawnshop
        {
            return records;
        }

        public static void AddThing(Thing thing, SoldOrBought soldOrBought) // Add new record
        {
            records.Add(new KeyValuePair<Thing,SoldOrBought>(thing, soldOrBought));
        }
    }
}
