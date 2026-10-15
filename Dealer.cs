using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    // Create class Dealer that inherits from Person class and has the dealer rules.
    internal class Dealer : Person
    {
        /* Returns true if the dealer has less than 17 points.
         * Otherwise returns false, meaning the dealer should stop.
        */
        public bool ShouldHit()
        {
            return CountValue() < 17;
        }
    }
}
