using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    internal class Person
    {
        public int Points { get; set; }
        private List<Card> Hand { get; } = new List<Card>();
        public bool HasStopped { get; private set; } = false;

        public void Hit(Card card)
        {
            if (HasStopped == false)
            {
                Hand.Add(card);
            }
        }

        public void Stop()
        {
            HasStopped = true;
        }

        public int CountValue()
        {
            int total = 0;
            int antalEss = 0;

            foreach (Card card in Hand)
            {
                total += card.Value;

                if (card.CardRank == "A")
                {
                    antalEss++;
                }
            }
            while (total > 21 && antalEss > 0)
            {
                total -= 10;

                antalEss--;
            }

            return total;
        }

        public IReadOnlyList<Card> GetHand()
        {
            return Hand.AsReadOnly();
        }
    }
}
