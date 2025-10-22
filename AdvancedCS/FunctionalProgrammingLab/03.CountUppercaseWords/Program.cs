namespace _03.CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> isUpper = word => !string.IsNullOrEmpty(word) && char.IsUpper(word[0]);
            Console.ReadLine()
                .Split(" ")
                .Where(w => w.Length > 0)
                .Where(isUpper)
                .ToList()
                .ForEach(w => Console.WriteLine(w));

        }
    }
}
