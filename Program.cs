using System;

namespace BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hej");

            Card myCard = new Card(25, "dam", "red", "u2665");

            Console.WriteLine(myCard.Value + myCard.CardRank + myCard.Color + myCard.Icon);
        }
    }
}
