namespace _02.BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = parameters[0], s = parameters[1], x = parameters[2];
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < n; i++) queue.Enqueue(numbers[i]);
            for (int i = 0; i < s; i++) queue.Dequeue();

            if (queue.Count == 0) Console.WriteLine(0);
            else
            {
                bool found = false;
                int min = int.MaxValue;
                foreach (int el in queue)
                {
                    if (el == x) { found = true; break; }
                    if (el < min) min = el;
                }
                if (found) Console.WriteLine("true");
                else Console.WriteLine(min);
            }
        }
    }
}
