namespace BlackJack
{
    // Handles how cards are displayed with colors in the console.
    internal class CardPrinter
    {
        // Prints a card with a white background and the correct text color.
        public static void PrintCard(Card card)
        {
            Console.BackgroundColor = ConsoleColor.White;

            // Sets the text color based on the card's color.
            if (card.Color == "red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }

            // Prints the card using the ToString() method in Card.
            Console.Write($"   {card}   ");

            Console.WriteLine();

            // Resets the console colors after printing the card.
            Console.ResetColor();
        }

        // Prints the back of a hidden card
        public static void PrintHiddenCard()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.Write("   ??    ");

            Console.ResetColor();
            Console.WriteLine();
        }
    }
}