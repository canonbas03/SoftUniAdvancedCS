namespace _02.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = input[0], m = input[1];

            List<int> commonElements = new List<int>();
            HashSet<int> firstHS = ReadHS(n);
            var secondHS = ReadHS(m);

            foreach (var i in firstHS)
            {
                if (secondHS.Contains(i))
                {
                    commonElements.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", commonElements));
        }

        public static HashSet<int> ReadHS(int size)
        {
            HashSet<int> result = new HashSet<int>();
            for (int i = 0; i < size; i++)
            {
                result.Add(int.Parse(Console.ReadLine()));
            }
            return result;
        }
    }
}
