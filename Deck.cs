using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlackJack
{
    internal class Deck
    {
        public Card[] CardDeck {  get; set; }

        public List<Card> MixedCardDeck { get; set; } 

        public string[] Icons { get; set; }
    }
}
