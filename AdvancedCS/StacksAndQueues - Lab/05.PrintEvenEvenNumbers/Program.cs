namespace _05.PrintEvenEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> numbersQueue = new Queue<int>(numbers);

            List<int> numbersList = new List<int>();
            while(numbersQueue.Count > 0)
            {
                int number = numbersQueue.Dequeue();
                if(number % 2 == 0)
                {
                    numbersList.Add(number);
                }
            }
            Console.WriteLine(String.Join(", ",numbersList));
        }
    }
}
