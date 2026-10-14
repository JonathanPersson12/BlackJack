using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    internal class Card
    {
        public int Value { get; set; }
        public string CardRank { get; set; }
<<<<<<< HEAD
        public string Color { get; set; }
        public char Icon { get; set; }
        public Card(int value, string cardRank, string color, char icon)
=======
        public char Color { get; set; }
        public string Icon { get; set; }
        public Card(int value, string cardRank, char color, string icon)
>>>>>>> main
        {
            Value = value;
            CardRank = cardRank;
            Color = color;
            Icon = icon;
        }

    }
}
