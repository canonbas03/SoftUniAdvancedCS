namespace _01.ActionPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            Iterate(names, n => Console.WriteLine(n));
        }

        static void Iterate(string[] array, Action<string> action)
        {
            foreach (string word in array)
            {
                action(word);
            }
        }
    }
}
