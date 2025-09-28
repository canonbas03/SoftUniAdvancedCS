namespace _04.AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine().Split(", ")
                .Select(double.Parse)
                .Select(n => n * 1.2)
                .Select(n => $"{n:f2}")
                .ToList()
                .ForEach(n => Console.WriteLine(n));
        }
    }
}

// 1,38, 2,56, 4,4