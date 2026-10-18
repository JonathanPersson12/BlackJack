using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace BlackJack
{
    internal class GameBoard
    {
        private Deck deck;
        private Player player;
        private Dealer dealer;

        public void Start()
        {
            // Initialize the game objects
            deck = new Deck();
            player = new Player();
            dealer = new Dealer();

            // Deal the initial 2 cards to both Player and Dealer
            player.Hit(deck.DrawCard());
            player.Hit(deck.DrawCard());
            dealer.Hit(deck.DrawCard());
            dealer.Hit(deck.DrawCard());

            PlayerTurn();
        }

        private void PlayerTurn()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("=== BLACK JACK ===");
                Console.ResetColor();
                Console.WriteLine();

                // Display dealer´s cards and total points
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Dealer's hand:");
                Console.ResetColor();
                Console.WriteLine();
                //foreach (Card card in dealer.GetHand())
                //{
                //    CardPrinter.PrintCard(card);
                //    Console.WriteLine();
                //}
                //Console.WriteLine($"Dealer total: {dealer.CountValue()}");
                Card firstCard = dealer.GetHand()[0];
                CardPrinter.PrintCard(firstCard);
                Console.WriteLine();
                CardPrinter.PrintHiddenCard();

                Console.WriteLine();
                Console.WriteLine("==================");
                Console.WriteLine();

                // Display players´s cards and total points
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Your hand:");
                Console.ResetColor();
                Console.WriteLine();
                foreach (Card card in player.GetHand())
                {
                    CardPrinter.PrintCard(card);
                    Console.WriteLine();
                }
                Console.WriteLine($"Yoar total: {player.CountValue()}");


                // If the player goes over 21, they lose immediately (Bust)
                if (player.CountValue() > 21)
                {
                    Console.WriteLine();
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("\nYou went bust (over 21)! Dealer wins.");
                    Console.ResetColor();
                    Console.WriteLine();
                    PlayAgain();
                    return;
                }

                Console.Write("\nDo you want to (H)it or (S)tand? ");
                string choice = Console.ReadLine().ToUpper();
                // Different outcome based on player's choice to hit or stand
                if (choice == "H")
                {
                    player.Hit(deck.DrawCard());
                    Console.Clear();
                }
                else if (choice == "S")
                {
                    DealerTurn();
                    break;
                }
            }
        }

        private void DealerTurn()
        {
            Console.Clear();
            Console.WriteLine("=== DEALER'S TURN ===");
            // Display dealers hand
            Console.WriteLine();
            foreach (Card card in dealer.GetHand())
            {
                CardPrinter.PrintCard(card);
                Console.WriteLine();
            }
            Thread.Sleep(1000);

            // Dealer must hit until their hand value reaches at least 17
            // Display one card at the time while dealer draw card
            while (dealer.ShouldHit())
            {
                Console.WriteLine("Dealer draws a card...");
                dealer.Hit(deck.DrawCard());
                Thread.Sleep(1000); // 1-second pause to build suspense
                // Find and display dealer's latest card
                int lastIndex = dealer.GetHand().Count - 1;
                Card newCard = dealer.GetHand()[lastIndex];
                CardPrinter.PrintCard(newCard);
                Console.WriteLine($"Dealer total: {dealer.CountValue()}");
                Thread.Sleep(1000);


            }

            // Dealer choice to stand if hand value is above 17
            if (!dealer.ShouldHit() && dealer.CountValue() <= 21)
            {
                Console.WriteLine("Dealer stand...");
                Thread.Sleep(1000);
            }

            
            
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=== FINAL RESULT ===");
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("Dealer's hand:");
            foreach (Card card in dealer.GetHand())
            {
                CardPrinter.PrintCard(card);
            }
            Console.WriteLine($"Dealer total: {dealer.CountValue()}");

            Console.WriteLine("\nYour hand:");
            foreach (Card card in player.GetHand())
            {
                CardPrinter.PrintCard(card);
            }
            Console.WriteLine($"Your total: {player.CountValue()}");
            Console.WriteLine();

            Thread.Sleep(1000);
            DetermineWinner();
        }

        private void DetermineWinner()
        {
            int playerPoints = player.CountValue();
            int dealerPoints = dealer.CountValue();

            if (dealerPoints > 21)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nDealer went bust! You win!");
                Console.ResetColor();
            }
            else if (playerPoints > dealerPoints)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nYou have the better hand. You win!");
                Console.ResetColor();
            }
            else if (dealerPoints > playerPoints)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nDealer has the better hand. Dealer wins.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                // Tie rule: House/Dealer wins ties as specified by the teacher
                Console.WriteLine("\nIt's a tie! Dealer wins according to house rules.");
                Console.ResetColor();
            }

            Console.WriteLine();
            PlayAgain();
        }

        // Method for reinitiating game based on players choice
        public void PlayAgain()
        {
            bool playAgain = false;
            string choice = "";
            // Keep asking until the player enters Y or N
            while (choice != "Y" && choice != "N")
            {
                Console.WriteLine("Play Again? (Y/N)");
                choice = Console.ReadLine().ToUpper();
                if (choice == "Y")
                {
                    playAgain = true;
                    Console.Clear();
                    Thread.Sleep(500);
                    // Create a new game with a new MixedCardDeck
                    GameBoard board = new GameBoard();
                    board.Start();
                }
                else if (choice == "N")
                {
                    playAgain = false;
                }
                else
                {
                    Console.WriteLine("Invalid answear, try again");
                }
            }
        }
    }
}
