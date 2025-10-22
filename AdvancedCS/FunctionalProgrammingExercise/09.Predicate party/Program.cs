using System.Data;

namespace _09.Predicate_party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> peoples = Console.ReadLine().Split().ToList();

            string input;
            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] tokens = input.Split();
                string command = tokens[0];
                string criteria = tokens[1];
                string argument = tokens[2];

                Func<string, bool> condition = GetPredicate(criteria, argument);
                if(command == "Remove")
                {
                    RemoveWhere(peoples, condition);
                }
                else if(command =="Double")
                {
                    DoubleWhere(peoples,condition);
                }
            }
            if(peoples.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", peoples)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static void DoubleWhere(List<string> peoples, Func<string, bool> condition)
        {
            for(int i = peoples.Count - 1;i >= 0; i--)
            {
                if (condition(peoples[i]))
                {
                    peoples.Insert(i, peoples[i]);
                }
            }
        }

        private static void RemoveWhere(List<string> peoples, Func<string, bool> condition)
        {
            for(int i = peoples.Count - 1; i >= 0; i--)
            {
                if (condition(peoples[i]))
                {
                    peoples.RemoveAt(i);
                }
            }
        }

        static Func<string, bool> GetPredicate (string type , string arg)
        {
            if(type == "StartsWith")
            return x => x.StartsWith(arg);

            else if(type == "EndsWith")
            {
                return x => x.EndsWith(arg);
            }

            else if(type == "Length")
            {
                return x => x.Length == int.Parse(arg);
            }
            return _ => false;
        }
    }
}
