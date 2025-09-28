namespace _03.CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(" ")
                .Where(w => w.Length > 0)
                .Where(w => char.IsUpper(w[0]))
                .ToList()
                .ForEach(w => Console.WriteLine(w));
        }
    }
}
