using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    internal class Card
    {
        public int Value { get; set; }
        public string CardRank { get; set; }
        public string Color { get; set; }
        public char Icon { get; set; }
        public Card(int value, string cardRank, string color, char icon)
        {
            Value = value;
            CardRank = cardRank;
            Color = color;
            Icon = icon;
        }
        
        public override string ToString()
        {
            return $"{Icon}{CardRank}";
        }
        
        public void VisualizeCard(Card card)
        {
           
            if (card.CardRank == "10")
            {
                card.CardRank = $"{card.CardRank}";
            } else
            {
                card.CardRank = $" {card.CardRank}";
            }

            if (card.Color == "red")
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{card.CardRank}     ");
                Console.ResetColor();
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"       ");
                Console.ResetColor();
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"   {card.Icon}   ");
                Console.ResetColor();
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"       ");
                Console.ResetColor();
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"    {card.CardRank} ");
                Console.ResetColor();
                Console.WriteLine();
            } else
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write($"{card.CardRank}     ");
                Console.ResetColor();
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write($"       ");
                Console.ResetColor();
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write($"   {card.Icon}   ");
                Console.ResetColor();
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write($"       ");
                Console.ResetColor();
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write($"    {card.CardRank} ");
                Console.ResetColor();
                Console.WriteLine();

            }
        }
    }
}
