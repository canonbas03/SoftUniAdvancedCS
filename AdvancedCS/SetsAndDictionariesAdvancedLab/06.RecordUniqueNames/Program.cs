namespace _06.RecordUniqueNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int namesCount = int.Parse(Console.ReadLine());
            var uniqueNames = new HashSet<string>();
            for (int i = 0; i < namesCount; i++)
            {
                string name = Console.ReadLine();
                uniqueNames.Add(name);
            }
            foreach (string name in uniqueNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
