using System;
using System.Collections.Generic;

namespace Poker
{
    internal class Hand
    {
        public List<Card> Cards;
        public string HandType;
        private int Points;

        public Hand(List<Card> cards)
        {
            Cards = cards;
            SortCards();
            HandType = string.Empty;
            Points = 0;
        }

        public void AddCards(List<Card> cards)
        {
            Cards.AddRange(cards);
            SortCards();
        }

        private void SortCards()
        {
            Cards.Sort((card1, card2) => card1.Number.CompareTo(card2.Number));
        }

        public int ExchangeCards(int player)
        {
            int count;
            while (true)
            {
                Console.WriteLine($"Player {player}");
                Console.WriteLine(ToString());
                Console.WriteLine("How many cards do you want to exchange?");
                if (!int.TryParse(Console.ReadLine(), out count) || count < 0 || count > 5)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. You can only choose numbers between 0 and 5.");
                    Environment.Exit(0);
                }
                else
                {
                    break;
                }
            }
            Console.Clear();

            if (count == 5)
                return count;

            for (int i = 0; i < count; i++)
            {
                int number;
                while (true)
                {
                    Console.WriteLine($"Player {player}");
                    Console.WriteLine(ToString());
                    Console.WriteLine($"Select card {i + 1}: ");
                    if (!int.TryParse(Console.ReadLine(), out number) || number <= 0 || number > Cards.Count)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid input. Please enter a valid card number.");
                        Environment.Exit(0); 
                    }
                    else
                    {
                        break;
                    }
                }
                Cards.RemoveAt(number - 1);
                Console.Clear();
            }
            return count;
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

        public int GetPoints()
        {
            List<Card> sortedCards = Cards.OrderBy(card => card.Number).ToList();
            bool isFlush = IsFlush();
            bool isStraight = IsStraight(sortedCards);

            if (isFlush && isStraight)
            {
                return 8000 + sortedCards.Last().Number;
            }
            else if (HasNOfAKind(4))
            {
                return 7000 + sortedCards[2].Number;
            }
            else if (HasNOfAKind(3) && HasNOfAKind(2))
            {
                return 6000 + sortedCards[2].Number;
            }
            else if (isFlush)
            {
                return 5000 + sortedCards.Last().Number;
            }
            else if (isStraight)
            {
                return 4000 + sortedCards.Last().Number;
            }
            else if (HasNOfAKind(3))
            {
                return 3000 + sortedCards[2].Number;
            }
            else if (CountPairs() == 2)
            {
                return 2000 + sortedCards[4].Number;
            }
            else if (CountPairs() == 1)
            {
                return 1000 + sortedCards[3].Number;
            }
            else
            {
                return sortedCards.Last().Number;
            }
        }

        private bool IsFlush()
        {
            return Cards.All(card => card.Suit == Cards.First().Suit);
        }

        private bool IsStraight(List<Card> sortedCards)
        {
            for (int i = 0; i < sortedCards.Count - 1; i++)
            {
                if (sortedCards[i + 1].Number - sortedCards[i].Number != 1)
                {
                    return false;
                }
            }
            return true;
        }

        private bool HasNOfAKind(int n)
        {
            return Cards.GroupBy(card => card.Number).Any(group => group.Count() == n);
        }

        private int CountPairs()
        {
            return Cards.GroupBy(card => card.Number).Count(group => group.Count() == 2);
        }

        
    }
}
