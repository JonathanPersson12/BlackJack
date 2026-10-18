using System;

namespace BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Initiate new gameboard and start game
            GameBoard board = new GameBoard();
            board.Start();
        }
    }
}
