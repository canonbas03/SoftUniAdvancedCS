namespace _06.ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());

            int[] result = InReverse(numbers, x => x % n != 0);
            Console.WriteLine(string.Join(" ", result));

        }

        static int[] InReverse(int[] array, Func<int, bool> func)
        {
            List<int> list = new List<int>();
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (func(array[i]))
                    list.Add(array[i]);
            }
            return list.ToArray();
        }
    }
}
