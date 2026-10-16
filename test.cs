using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    internal class test
    {

    
       
            private Deck deck;
            private Player player;
            private Dealer dealer;

            public void Starta()
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
                    Console.WriteLine("=== BLACK JACK ===");

                    // Show only the Dealer's first card (index 0) and hide the second one
                    Console.WriteLine($"Dealer's hand: [{dealer.GetHand()[0]}] [Hidden Card]");

                    Console.Write("\nYour hand: ");
                    player.GetHand();

                    // If the player goes over 21, they lose immediately (Bust)
                    if (player.CountValue() > 21)
                    {
                        Console.WriteLine("\nYou went bust (over 21)! Dealer wins.");
                        return;
                    }

                    Console.Write("\nDo you want to (H)it or (S)tand? ");
                    string choice = Console.ReadLine().ToUpper();

                    if (choice == "H")
                    {
                        player.Hit(deck.DrawCard());
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

                // Dealer must hit until their hand value reaches at least 17
                while (dealer.ShouldHit())
                {
                    Console.WriteLine("Dealer draws a card...");
                    dealer.Hit(deck.DrawCard());
                    Thread.Sleep(1000); // 1-second pause to build suspense
                }

                Console.Clear();
                Console.WriteLine("=== FINAL RESULT ===");
                Console.Write("Dealer's hand: ");
                dealer.GetHand();
                Console.Write("Your hand: ");
                player.GetHand();

                DetermineWinner();
            }

            private void DetermineWinner()
            {
                int playerPoints = player.CountValue();
                int dealerPoints = dealer.CountValue();

                if (dealerPoints > 21)
                {
                    Console.WriteLine("\nDealer went bust! You win! 🎉");
                }
                else if (playerPoints > dealerPoints)
                {
                    Console.WriteLine("\nYou have the better hand. You win! 🏆");
                }
                else if (dealerPoints > playerPoints)
                {
                    Console.WriteLine("\nDealer has the better hand. Dealer wins.");
                }
                else
                {
                    // Tie rule: House/Dealer wins ties as specified by the teacher
                    Console.WriteLine("\nIt's a tie! Dealer wins according to house rules.");
                }
            }
        
    }
}

