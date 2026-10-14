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

        public char[] Icons { get; set; }

        public Deck () {
            Icons = ['\u2665', '\u2666', '\u2663', '\u2660'];


        }
    }
}
