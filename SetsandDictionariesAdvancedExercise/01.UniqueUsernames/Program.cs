namespace _01.UniqueUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var usernames = new HashSet<string>();
            int counter = int.Parse(Console.ReadLine());
            for (int i = 0; i < counter; i++)
            {
                usernames.Add(Console.ReadLine());
            }
            foreach (string name in usernames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
