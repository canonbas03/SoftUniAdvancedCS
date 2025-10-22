namespace Playground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var hashSet = new HashSet<string>();

            hashSet.Remove("abc");
            Console.WriteLine(hashSet.Count);
        }
    }
}
