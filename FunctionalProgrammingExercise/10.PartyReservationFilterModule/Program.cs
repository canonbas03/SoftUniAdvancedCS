namespace _10.PartyReservationFilterModule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split().ToList();

            Dictionary<string, Func<string, bool>> filters = new();

            string input;
            while ((input = Console.ReadLine()) != "Print")
            {
                string[] tokens = input.Split(";",StringSplitOptions.RemoveEmptyEntries);

                string action = tokens[0];
                string condition = tokens[1];
                string argument = tokens[2];

                string key = $"{condition}_{argument}";
                Func<string, bool> currentCondition = MakeCondition(condition, argument);
                if (action == "Add filter")
                {
                    if (!filters.ContainsKey(key))
                    {
                        filters[key] = currentCondition;
                    }
                }
                else if (action == "Remove filter")
                {
                    if (filters.ContainsKey(key))
                    {
                        filters.Remove(key);
                    }
                }
            }
            Func<string, bool> final = All(filters);
            List<string> result = new List<string>();
            foreach (string s in guests)
            {
                if(!final(s))
                    result.Add(s);
            }

            Console.WriteLine(string.Join(" ", result));
        }
        static Func<string, bool> All(Dictionary<string, Func<string, bool>> dict)
        {
            return x =>
            {
                foreach (var (commandName, function) in dict)
                    if (function(x)) return true;

                return false;
            };

        }

        private static Func<string, bool> MakeCondition(string con, string arg)
        {
            if (con == "Starts with")
                return x => x.StartsWith(arg);
            if (con == "Ends with")
                return x => x.EndsWith(arg);
            if (con == "Length")
                return x => x.Length == int.Parse(arg);
            if (con == "Contains")
                return x => x.Contains(arg);
            return _ => false;
        }
    }
}
