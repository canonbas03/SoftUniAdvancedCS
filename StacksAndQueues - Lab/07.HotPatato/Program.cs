namespace _07.HotPatato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());

            Queue<string> queueKids = new Queue<string>(kids);
            while (queueKids.Count > 1)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    string safeKid = queueKids.Dequeue();
                    queueKids.Enqueue(safeKid);
                }
                Console.WriteLine($"Removed {queueKids.Dequeue()}");

            }
            Console.WriteLine($"Last is {queueKids.Dequeue()}");
        }
    }
}
