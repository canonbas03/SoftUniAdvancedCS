namespace _06.Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = 0;
            Queue<string> queue = new Queue<string>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                if(input == "Paid")
                {
                    while (queue.Count > 0)
                    {
                        peopleCount--;
                        Console.WriteLine(queue.Dequeue());
                    }
                }
                else
                {
                    peopleCount++;
                    queue.Enqueue(input);
                }
            }
            Console.WriteLine($"{peopleCount} people remaining.");
        }
    }
}
