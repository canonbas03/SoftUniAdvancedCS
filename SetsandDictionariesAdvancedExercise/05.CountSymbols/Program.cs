using System.Diagnostics.Tracing;

namespace _05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var countByChar = new Dictionary<char, int>();
            string text = Console.ReadLine();
            for (int i = 0; i < text.Length; i++)
            {
                if(!countByChar.ContainsKey(text[i]))
                    countByChar[text[i]]=0;
                countByChar[text[i]]++;
            }
            foreach (var kvp in countByChar.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
