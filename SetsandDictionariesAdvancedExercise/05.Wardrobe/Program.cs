namespace _06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");
                string color = input[0];
                string[] clothes = input[1].Split(",");
                if(!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }
                foreach(string clothe in clothes)
                {
                    if (!wardrobe[color].ContainsKey(clothe))
                    {
                        wardrobe[color][clothe] = 0;
                    }
                    wardrobe[color][clothe]++;
                }
            }
            string[] search = Console.ReadLine().Split();
            foreach (var(color, clothes) in wardrobe)
            {
                Console.WriteLine($"{color} clothes:");
                foreach(var (clothe, count) in clothes)
                {
                    Console.Write($"* {clothe} - {count}");
                    if(color == search[0] && clothe == search[1])
                    {
                        Console.Write(" (found!)");
                    }
                    Console.WriteLine();
                }
            }


        }
    }
}
