using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace BlackJack
{
    // Base Perso class for Player and Dealer.
    // Has methods that handles cards, stopping and hand value calculation.
    internal class Person
    {
        
        public int Points { get; set; }

        // Stores the cards privately so they can only be added through Hit().
        private List<Card> Hand { get; } = new List<Card>();
        public bool HasStopped { get; private set; } = false;

        // Adds a card to the hand if the person has not stopped
        public void Hit(Card card)
        {
            if (HasStopped == false)
            {
                Hand.Add(card);
            }
        }

        // Marks the person as stopped to prevent drawing more cards
        public void Stop()
        {
            HasStopped = true;
        }

        // Calculates the total hand value, including ace handling 
        public int CountValue()
        {
            int total = 0;
            int numberOfEss = 0;

            // Count aces so we can adjust their values later if needed.
            foreach (Card card in Hand)
            {
                total += card.Value;

                if (card.CardRank == "A")
                {
                    numberOfEss++;
                }
            }
            // Adjust aces from 11 to 1 if the hand exceeds 21
            while (total > 21 && numberOfEss > 0)
            {
                total -= 10;

                numberOfEss--;
            }
            // Returns a read-only view of the person's hand
            return total;
        }

        // Lets other classes view the hand without adding or removing cards.
        public IReadOnlyList<Card> GetHand()
        {
            return Hand.AsReadOnly();
        }
    }
}
