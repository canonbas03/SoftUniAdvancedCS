namespace _03.CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int min = Aggregate(numbers, int.MaxValue, (a,b) => Math.Min(a,b));
            Console.WriteLine(min);
        }

        static int Aggregate(int[] array, int initial, Func<int, int, int> func)
        {
            int result = initial;
            foreach (int num in array)
            {
                result = func(result,num);
            }
            return result;
        }
    }

    
}
