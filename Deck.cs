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
        // Stores cards in ordered form
        public List<Card> CardDeck {  get; set; }
        // Stores the cards in randomized order
        public List<Card> MixedCardDeck { get; set; }
        // Contains the card symbols ♥ - ♦ - ♠ - ♣
        public char[] Icons { get; set; }
       

        /// <summary>
        /// Creates a complete deck of 52 cards and stores an ordered deck of cards in CardDeck and a shuffled version of the cards in MixedCardDeck
        /// </summary>
        public Deck () {
            // Hearts, diamonds, clubs and spades.
            Icons = ['\u2665', '\u2666', '\u2663', '\u2660'];
            CardDeck = new List<Card>();
            MixedCardDeck = new List<Card>();

            // Create the deck first, then shuffle it
            OrderedDeck();
            MixedDeck();
        }

        // Method for creating a complete deck containing 52 cards
        public void OrderedDeck()
        {
            foreach (char icon in Icons)
            {
                // Create 13 cards for each symbol with cardRank set to string based on value
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
                    // Sets clubs and spades to color black and hearts and diamonds to color red.
                    string color = "";
                    if (icon == '\u2663' || icon == '\u2660')
                    {
                        color = "black";
                    } else
                    {
                        color = "red";
                    }
                   // Create instance of card...
                    Card newCard = new Card(value, cardRank, color, icon);
                    // ...and add it to the ordered deck
                    CardDeck.Add(newCard);
                }
            }
        }

        // Method to create a shuffled card order based on CardDeck and stores it in MixedCardDeck
        public void MixedDeck()
        {
            Random random = new Random();

            // Creates a list to store the randomized indexes
            List<int> numbers = new List<int>();

            // Generates 52 unique random numbers between 0 and 51 to use as card indexes
            while (numbers.Count < 52)
            {
                int number = random.Next(0, 52);

                if (!numbers.Contains(number))
                {
                    numbers.Add(number);
                }
            }
            // Add the cards to MixedCardDeck using the randomized indexes
            for (int i = 0; i < CardDeck.Count; i++) {
                MixedCardDeck.Add(CardDeck[numbers[i]]);
            }

            
        }

        /// <summary>
        /// Draw card method delivers card on index 0 from MixedDeck list and removes it from deck
        /// </summary>
        /// <returns>
        /// A Card object containing CardRank, Icon, Value and Color
        /// </returns>
        public Card DrawCard()
        {
            Card currentCard = MixedCardDeck[0];
            MixedCardDeck.RemoveAt(0);
            return currentCard;
        }



    }
}
