namespace _05.CitiesbyContinentandCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int entries = int.Parse(Console.ReadLine());
            var continents = new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < entries; i++)
            {
                string[] values = Console.ReadLine().Split();

                string continent = values[0];
                string country = values[1];
                string city = values[2];

                if (!continents.ContainsKey(continent))
                {
                    continents[continent] = new Dictionary<string, List<string>>();
                }
                if (!continents[continent].ContainsKey(country))
                {
                    continents[continent][country] = new List<string>();
                }
                continents[continent][country].Add(city);
            }
            foreach (var (continent, countries) in continents)
            {
                Console.WriteLine($"{continent}:");
                foreach (var (country, cities) in countries)
                {
                    Console.WriteLine($"  {country} -> {string.Join(", ",cities)}");
                }
            }
        }
    }
}
