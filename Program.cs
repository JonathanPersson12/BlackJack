using System;

namespace BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;



            // Code below is only for testing purpose

            Deck myDeck = new Deck();
            Card myCurrentCard = myDeck.DrawCard();


            Card playerCard = new Card(myCurrentCard.Value, myCurrentCard.CardRank, myCurrentCard.Color, myCurrentCard.Icon);
            
            playerCard.VisualizeCard(myCurrentCard);
            Console.WriteLine(myCurrentCard);

            Console.WriteLine();

            myCurrentCard = myDeck.DrawCard();

            
            playerCard.VisualizeCard(myCurrentCard);
            Console.WriteLine(myCurrentCard);





            Dealer dealer = new Dealer();
            Player player = new Player();

            GameBoard game = new GameBoard();
            while (game.IsPlaying)
            {
                game.PlayGame(dealer, player);
            }

            




        }
    }
}
