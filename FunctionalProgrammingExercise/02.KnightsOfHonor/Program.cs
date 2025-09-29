namespace _02.KnightsOfHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Iterate(names, n => Console.WriteLine($"Sir {n}"));
        }

        private static void Iterate(string[] names, Action<string> action)
        {
            foreach (string name in names)
            {
                action(name);
            }
        }
    }
}
