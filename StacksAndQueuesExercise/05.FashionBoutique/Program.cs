namespace _05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = ReadClothes();
            int capacity = int.Parse(Console.ReadLine());

            int racks = 0, remaining = 0;
            while(clothes.Count > 0)
            {
                int current = clothes.Pop();
                if(current > remaining)
                {
                    racks++;
                    remaining = capacity;
                }
                remaining -= current;
            }
            Console.WriteLine(racks);
        }
        private static Stack<int> ReadClothes()
        {
            IEnumerable<int> sequence = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            return new Stack<int>(sequence);
        }
    }
}
