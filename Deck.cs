using System;
using System.Collections.Generic;

namespace Poker
{
    internal class Deck
    {
        private readonly List<string> Suits = new List<string> { "Hearts", "Spades", "Clubs", "Diamonds" };
        private readonly List<Card> Cards;

        public Deck()
        {
            Cards = GenerateDeck();
        }

        private List<Card> GenerateDeck()
        {
            List<Card> deck = new List<Card>();
            foreach (var suit in Suits)
            {
                for (int value = 2; value <= 14; value++)
                {
                    deck.Add(new Card(value, suit));
                }
            }
            return deck;
        }

        public List<Card> DealCards(int count)
        {
            List<Card> dealtCards = new List<Card>();
            Random rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                int index = rnd.Next(0, Cards.Count);
                dealtCards.Add(Cards[index]);
                Cards.RemoveAt(index);
            }
            return dealtCards;
        }

        public override string ToString()
        {
            string result = "|";
            foreach (var card in Cards)
            {
                result += card.ToString() + "|";
            }
            return result;
        }
    }
}
