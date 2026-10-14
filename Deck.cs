using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Text;

namespace BlackJack
{
    internal class Deck
    {
        public List<Card> CardDeck {  get; set; }

        public List<Card> MixedCardDeck { get; set; } 

        public char[] Icons { get; set; }

        public Deck () {
            Icons = ['\u2665', '\u2666', '\u2663', '\u2660'];


        }

        public void orderedDeck()
        {
            foreach (char icon in Icons)
            {
                for (int i = 1; i <= 13; i++) {
                    int value = i;
                    string cardRank = "";
                    switch (value) 
                    {
                        case 1:  
                            cardRank = "A";
                            break;
                        case 11:
                            cardRank = "J";
                            value = 10;
                            break;
                        case 12:
                            cardRank = "Q";
                            value = 10;
                            break;
                        case 13:
                            cardRank = "K";
                            value = 10;
                            break;
                        default:  
                            cardRank = value.ToString(); 
                            break;

                    }
                    char color = 'r';

                
                }
            }
        }
    }
}
