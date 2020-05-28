using System;
using System.Collections.Generic;
using System.Text;

namespace PawnshopLibrary
{
    public interface IClient
    {
        string FullName { get; set; } // Fullname of client
        void SellAThing(string name, Decimal price); // Sell thing to pawnshop
        bool BuyBackThing(Thing thing); // Buy thing in pawnshop
    }
}
