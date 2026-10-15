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
                Console.WriteLine("CardRank: " + card.CardRank + " Icon: " + card.Icon + " Value: " + card.Value + " Color: " + card.Color);
            }

            Console.WriteLine(myDeck.MixedCardDeck.Count);

            Card myCurrentCard = myDeck.DrawCard();

            Console.WriteLine("My Current Card: " + myCurrentCard.CardRank + " " + myCurrentCard.Icon);
            Console.WriteLine("Cards left in deck: " + myDeck.MixedCardDeck.Count);
            Thread.Sleep(1000);

            myCurrentCard = myDeck.DrawCard();

            Console.WriteLine("My Current Card: " + myCurrentCard.CardRank + " " + myCurrentCard.Icon);
            Console.WriteLine("Cards left in deck: " + myDeck.MixedCardDeck.Count);
            Thread.Sleep(1000);

            myCurrentCard = myDeck.DrawCard();

            Console.WriteLine("My Current Card: " + myCurrentCard.CardRank + " " + myCurrentCard.Icon);
            Console.WriteLine("Cards left in deck: " + myDeck.MixedCardDeck.Count);




        }
    }
}
