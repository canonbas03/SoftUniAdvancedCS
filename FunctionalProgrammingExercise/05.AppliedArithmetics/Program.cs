namespace _05.AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Dictionary<string, Action<int[]>> executors = new()
            {
                ["add"] = arr => Trandform(arr, x => x + 1),
                ["subtract"] = arr => Trandform(arr, x => x - 1),
                ["multiply"] = arr => Trandform(arr, x => x * 2),
                ["print"] = arr => Console.WriteLine(string.Join(" ", arr))
            };

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                if (!executors.ContainsKey(input)) continue;

                Action<int[]> action = executors[input];
                action(numbers);
            }
        }

        static void Trandform(int[] array, Func<int, int> func)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = func(array[i]);
            }
        }
    }
}
/*
1 2 3 4 5
add
add
print
end
 */