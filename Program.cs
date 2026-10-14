using System;

namespace BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;


            Console.WriteLine("hej");

            Deck myDeck = new Deck();

            /*
            foreach(Card card in myDeck.CardDeck)
            {
                Console.WriteLine(card.CardRank + " " + card.Icon);
            }
            */

            foreach (Card card in myDeck.MixedCardDeck)
            {
                Console.WriteLine(card.CardRank + " " + card.Icon);
            }

            Console.WriteLine(myDeck.MixedCardDeck.Count);



        }
    }
}
