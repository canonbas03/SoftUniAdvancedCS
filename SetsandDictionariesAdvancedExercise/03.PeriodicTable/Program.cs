namespace _03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var chemicals = new SortedSet<string>();
            int counter = int.Parse(Console.ReadLine());
            for (int i = 0; i < counter; i++)
            {
                string[] elements = Console.ReadLine().Split();
                foreach (string element in elements)
                {
                    chemicals.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", chemicals));
        }
    }
}

/* 
3
Ge Ch O Ne
Nb Mo Tc
O Ne
 */