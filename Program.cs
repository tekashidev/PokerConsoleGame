using System;
using System.Collections.Generic;

namespace Poker
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Deck deck = new Deck();

            Hand player1Hand = new Hand(deck.DealCards(5));
            Hand player2Hand = new Hand(deck.DealCards(5));

            Console.WriteLine($"Player 1 Hand: {player1Hand}");
            Console.WriteLine($"Player 2 Hand: {player2Hand}");

            int exchangedCardsPlayer1 = player1Hand.ExchangeCards(1);
            int exchangedCardsPlayer2 = player2Hand.ExchangeCards(2);

            player1Hand.AddCards(deck.DealCards(exchangedCardsPlayer1));
            player2Hand.AddCards(deck.DealCards(exchangedCardsPlayer2));

            Console.WriteLine($"Player 1 New Hand: {player1Hand}");
            Console.WriteLine($"Player 2 New Hand: {player2Hand}");

            int player1Points = player1Hand.GetPoints();
            int player2Points = player2Hand.GetPoints();

            if (player1Points > player2Points)
            {
                Console.WriteLine("Player 1 wins!");
            }
            else if (player1Points < player2Points)
            {
                Console.WriteLine("Player 2 wins!");
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
        }
    }
}
