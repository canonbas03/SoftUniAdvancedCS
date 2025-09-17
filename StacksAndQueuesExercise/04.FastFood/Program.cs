namespace _04.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            Queue<int> orders = ReadOrders();
            Console.WriteLine(orders.Max());
            while (orders.Count > 0)
            {
                if (orders.Peek() > foodQuantity)
                    break;
                foodQuantity -= orders.Dequeue();
            }
            if (orders.Count == 0) Console.WriteLine("Orders complete");
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
        }

        private static Queue<int> ReadOrders()
        {
            IEnumerable<int> orders = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            return new Queue<int>(orders);
        }
    }
}
/*
499
57 45 62 70 33 90 88 76
*/