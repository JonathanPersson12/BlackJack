using System;
using System.Collections.Generic;
using System.Text;


namespace BlackJack
{
    internal class GameBoard
    {
        public bool IsPlaying { get; set; }

        public GameBoard ()
        {
            IsPlaying = true;
        }

        public void PlayGame(Dealer dealer, Player player) {
            bool hit = false;

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("--- Welcome to Black Jack ---");
            Console.ResetColor();
            Console.WriteLine();
            Deck deck = new Deck();

            
            player.Hit(deck.DrawCard());
            dealer.Hit(deck.DrawCard());


            player.Hit(deck.DrawCard());
            dealer.Hit(deck.DrawCard());

            showGameBoard(dealer, player);
            

            Thread.Sleep(1000);
            Console.WriteLine($"Player Total Points: " + player.CountValue());
            Console.WriteLine($"Dealer Total Points: " + dealer.CountValue());
            Console.WriteLine();
            Console.WriteLine("Hit or stop (H/S)?");
            string choice = Console.ReadLine();
            while (choice != "S") {
                if (choice == "H" || choice == "h")
                {
                    player.Hit(deck.DrawCard());
                    if (dealer.ShouldHit())
                    {
                        dealer.Hit(deck.DrawCard());
                    }
                    showGameBoard(dealer, player);
                } else if (choice == "S" || choice == "s")
                {
                    player.Stop();
                    choice = "S";
                    if (dealer.ShouldHit())
                    {
                        dealer.Hit(deck.DrawCard());
                    }
                    showGameBoard(dealer, player);
                } else
                {
                    Console.WriteLine("Invalid value, try again");
                    choice = Console.ReadLine();
                }
            }

            Console.ReadKey();
            IsPlaying = false;

        }

        public void showGameBoard (Dealer dealer, Player player) {
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Player Cards:");
            Console.ResetColor();
            Console.WriteLine();
            foreach (Card card in player.GetHand())
            {
                Thread.Sleep(1000);
                card.VisualizeCard(card);
                Console.WriteLine(card);
                Console.WriteLine();
            }

            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Dealer Cards:");
            Console.ResetColor();
            Console.WriteLine();
            foreach (Card card in dealer.GetHand())
            {
                Thread.Sleep(1000);
                card.VisualizeCard(card);
                Console.WriteLine(card);
                Console.WriteLine();
            }
        }

    }
}
