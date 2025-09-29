namespace _04.FindEvensОrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int start = numbers[0];
            int end = numbers[1];

            string type = Console.ReadLine();

            Predicate<int> predicate;
            if (type == "odd") predicate = x => x % 2 != 0;
            else if (type == "even") predicate = x => x % 2 == 0;
            else predicate = _ => false;

            List<int> result = InRange(start, end, predicate);
            Console.WriteLine(string.Join(" ", result));
        }

        static List<int> InRange(int start, int end, Predicate<int> predicate)
        {
            List<int> result = new List<int>();
            for (int i = start; i <= end; i++)
            {
                if (predicate(i))
                    result.Add(i);
            }
            return result;
            continue;
        }
    }
}
