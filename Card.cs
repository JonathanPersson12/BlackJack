using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    internal class Card
    {
        int Value { get; set; }
        string CardRank { get; set; }
        string Color { get; set; }
        string Icon { get; set; }
        public Card(int value, string cardRank, string color, string icon)
        {
            Value = value;
            CardRank = cardRank;
            Color = color;
            Icon = icon;
        }

    }
}
