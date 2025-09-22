namespace _04.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shops = new();

            string input;
            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] values = input.Split(", ").ToArray();

                string shop = values[0];
                string product = values[1];
                double price = double.Parse(values[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops[shop] = new Dictionary<string, double>();
                }
                shops[shop].Add(product, price);
            }
            foreach (var (shop, products) in shops)
            {
                Console.WriteLine($"{shop}->");
                foreach (var (product, price) in products)
                {
                    Console.WriteLine($"Product: {product}, Price: {price}");
                }
            }

        }
    }
}
