namespace _04.EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var countByNumber = new Dictionary<int, int>();
            int counter = int.Parse(Console.ReadLine());
            for (int i = 0; i < counter; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if(!countByNumber.ContainsKey(number))
                {
                    countByNumber[number] = 0;
                }
                countByNumber[number]++;
            }
            int result = countByNumber.Single(kvp => kvp.Value % 2 == 0).Key;
            Console.WriteLine(result);
        }
    }
}
