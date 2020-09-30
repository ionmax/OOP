using System.Collections.Generic;

namespace CourseWork.BusinessLogic
{
    public class CreditHistory // History of client purchases 
    {
        // Collection for saving all bought or sold thing of client
        private List<KeyValuePair<Thing, SoldOrBought>> records; 
        public CreditHistory()
        {
            records = new List<KeyValuePair<Thing, SoldOrBought>>(); // Creating new collection
        }

        public void AddThing(Thing thing, SoldOrBought soldOrBought) // Add new record
        {
            records.Add(new KeyValuePair<Thing, SoldOrBought>(thing, soldOrBought));
        }

        public List<KeyValuePair<Thing, SoldOrBought>> GetRecords() // Returns history of client
        {
            return records;
        }
    }
}
