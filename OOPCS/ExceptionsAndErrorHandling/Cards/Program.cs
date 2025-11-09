namespace Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Card> allCards = new List<Card>();
            string[] tokens = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string token in tokens)
            {
                string[] cardTokens = token.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string face = cardTokens[0];
                string suit = cardTokens[1];

                try
                {
                    Card card = new Card(face, suit);
                    allCards.Add(card);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(string.Join(" ", allCards));
        }
    }

    public class Card
    {
        private static string[] validFaces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private static string[] validSuits = { "S", "H", "D", "C" };
        private static Dictionary<string, string> suitIconByChar = new()
        {   {"S", "\u2660"},
            {"H", "\u2665"},
            {"D", "\u2666"},
            {"C", "\u2663"}
        };

        public Card(string face, string suit)
        {
            ValidateFace(face);
            ValidateSuit(suit);

            Face = face;
            Suit = suit;
        }

        public string Face { get; private set; }
        public string Suit { get; private set; }

        public override string ToString()
            => $"[{Face}{suitIconByChar[Suit]}]";

        private void ValidateFace(string face)
        {
            if (!validFaces.Contains(face))
            {
                throw new Exception("Invalid card!");
            }
        }

        private void ValidateSuit(string suit)
        {
            if (!validSuits.Contains(suit))
            {
                throw new Exception("Invalid card!");
            }
        }
    }
}
