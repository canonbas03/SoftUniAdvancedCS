namespace _08.ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<int> dividers = new HashSet<int>(Console.ReadLine().Split().Select(int.Parse));

            Func<int, bool>[] conditions = new Func<int, bool>[dividers.Count];
            int i = 0;
            foreach (int divider in dividers)
            {
                int currentDivider = divider;
                conditions[i] = x => x % currentDivider == 0;
                i++;
            }

            int[] result = InRange(1, n, All(conditions));
            Console.WriteLine(string.Join(' ',result));
        }
        static Func<int, bool> All(Func<int, bool>[] conditions)
        {
            return x =>
            {
                foreach (Func<int, bool> func in conditions)
                    if (!func(x)) return false;

                return true;
            };
        }
        static int[] InRange(int start, int end, Func<int, bool> condition)
        {
            List<int> result = new List<int>();
            for (int i = start; i <= end; i++)
            {
                if (condition(i))
                    result.Add(i);
            }
            return result.ToArray();
        }
    }
}
