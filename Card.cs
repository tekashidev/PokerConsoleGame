namespace Poker
{
    internal class Card
    {
        public int Number;
        public string Suit;
        public string Name;

        public Card(int number, string suit)
        {
            Number = number;
            Suit = suit;
            AssignName();
        }

        private void AssignName()
        {
            switch (Number)
            {
                case 10:
                    Name = "T";
                    break;
                case 11:
                    Name = "J";
                    break;
                case 12:
                    Name = "Q";
                    break;
                case 13:
                    Name = "K";
                    break;
                case 14:
                    Name = "A";
                    break;
                default:
                    Name = Number.ToString();
                    break;
            }
        }

        public override string ToString()
        {
            return $"{Name}{Suit}";
        }
    }
}
