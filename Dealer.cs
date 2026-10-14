using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    internal class Dealer : Person
    {
        public bool ShouldHit()
        {
            return CountValue() < 17;
        }
    }
}
