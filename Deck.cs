using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Text;
using System.Text.RegularExpressions;

namespace BlackJack
{
    internal class Deck
    {
        public List<Card> CardDeck {  get; set; }

        public List<Card> MixedCardDeck { get; set; } 

        public char[] Icons { get; set; }

        public Deck () {
            Icons = ['\u2665', '\u2666', '\u2663', '\u2660'];
            CardDeck = new List<Card>();
            MixedCardDeck = new List<Card>();

            orderedDeck();
            mixedDeck();
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
                            value = 11;
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
                    string color = "";
                    if (icon == '\u2663' || icon == '\u2660')
                    {
                        color = "black";
                    } else
                    {
                        color = "red";
                    }

                    Card newCard = new Card(value, cardRank, color, icon);
                    CardDeck.Add(newCard);
                }
            }
        }

        public void mixedDeck()
        {
            Random random = new Random();

            List<int> numbers = new List<int>();


            while (numbers.Count < 52)
            {
                int number = random.Next(0, 52);

                if (!numbers.Contains(number))
                {
                    numbers.Add(number);
                }
            }

            for (int i = 0; i < CardDeck.Count; i++) {
                MixedCardDeck.Add(CardDeck[numbers[i]]);
            }

            
        }
    }
}
