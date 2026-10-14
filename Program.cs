using System;

namespace BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("hej");

            Card myCard = new Card(25, "dam", "red", '\u2665');

          
            Console.Write($"{myCard.Value} {myCard.CardRank} {myCard.Color} ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($" {myCard.Icon} {myCard.CardRank} ");
            Console.ResetColor();
        }
    }
}
