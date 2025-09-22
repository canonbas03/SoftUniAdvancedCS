namespace _01.CountSameValuesinArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] values = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Dictionary<double, int> counts = new Dictionary<double, int>();
            foreach (var value in values)
            {
                if(!counts.ContainsKey(value))
                {
                    counts[value] = 0;
                }
                counts[value]++;
            }

            foreach (var pair in counts)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} times");
            }
        }
    }
}
