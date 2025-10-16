namespace _01.RubberDuckDebuggers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> timeNeeded = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> tasks = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int[] ducks = new int[4];

            while (timeNeeded.Count > 0 && tasks.Count > 0)
            {
                int time = timeNeeded.Dequeue();
                int currentTasks = tasks.Pop();

                int product = time * currentTasks;
                if (product <= 240)
                {
                    ducks[(product - 1) / 60]++;
                }
                else
                {
                    currentTasks -= 2;
                    tasks.Push(currentTasks);
                    timeNeeded.Enqueue(time);
                }
            }

            Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
            Console.WriteLine($"Darth Vader Ducky: {ducks[0]}");
            Console.WriteLine($"Thor Ducky: {ducks[1]}");
            Console.WriteLine($"Big Blue Rubber Ducky: {ducks[2]}");
            Console.WriteLine($"Small Yellow Rubber Ducky: {ducks[3]}");
        }
    }
}

/*
10 15 12 18 22 6
12 16 5 6 9 1
 */