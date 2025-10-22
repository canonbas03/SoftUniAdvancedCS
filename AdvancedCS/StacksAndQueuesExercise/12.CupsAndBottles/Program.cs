namespace _12.CupsAndBottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = GetCups();
            Stack<int> bottles = GetBottles();

            int wasted = 0;
            int removed = 0;
            while(bottles.Count > 0 && cups.Count > 0)
            {
                int currentBottle = bottles.Pop();
                int currentCup = cups.Peek() - removed;
                currentCup -= currentBottle; 
                if(currentCup <= 0)
                {
                    wasted += currentCup * -1;
                    cups.Dequeue();
                    removed = 0;
                }
                else
                {
                    removed += currentBottle;
                }
            }
            if(bottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ",bottles)}");
                Console.WriteLine($"Wasted litters of water: {wasted}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ",cups)}");
                Console.WriteLine($"Wasted litters of water: {wasted}");
            }
        }

        private static Stack<int> GetBottles()
        {
            IEnumerable<int> bottles = Console.ReadLine().Split().Select(int.Parse);
            return new Stack<int>(bottles);
        }

        private static Queue<int> GetCups()
        {
            IEnumerable<int> cups = Console.ReadLine().Split().Select(int.Parse);
            return new Queue<int>(cups);
        }
    }
}
