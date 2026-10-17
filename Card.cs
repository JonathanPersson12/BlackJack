using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    internal class Card
    {
        public int Value { get; set; }
        public string CardRank { get; set; }
        public string Color { get; set; }
        public char Icon { get; set; }
        public Card(int value, string cardRank, string color, char icon)
        {
            Value = value;
            CardRank = cardRank;
            Color = color;
            Icon = icon;
        }

        // Returns the cards symbol and rank as a string.
        // Adds spacing so single character ranks will align.
        public override string ToString()
        {
            return $"{Icon}{CardRank, -2}";
        }
    }
}
