namespace _07.PredicateOfNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Iterate(Format(names,x => x.Length <= n),Console.WriteLine);
        }
        static string[] Format(string[] arr, Func<string,bool> func)
        {
            List<string> resultList = new List<string>();
            foreach (string name in arr)
            {
                if(func(name))
                    resultList.Add(name);
            }
            return resultList.ToArray();
        }

        static void Iterate(string[] arr, Action<string>action)
        {
            foreach (string name in arr)
            {
                action(name);
            }
        }
    }
}
