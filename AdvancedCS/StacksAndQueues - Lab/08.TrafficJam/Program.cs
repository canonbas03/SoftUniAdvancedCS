namespace _08.TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            int numberAllowed = int.Parse(Console.ReadLine());
            int carsPassed = 0;
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < numberAllowed; i++)
                    {
                        if (queue.Count > 0)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            carsPassed++;
                        }
                    }
                }
                else queue.Enqueue(input);
            }
            Console.WriteLine($"{carsPassed} cars passed the crossroads.");
        }
    }
}