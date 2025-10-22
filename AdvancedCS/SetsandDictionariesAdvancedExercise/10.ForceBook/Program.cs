namespace _10.ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sides = new Dictionary<string, List<string>>();
            var users = new Dictionary<string, string>();
            string input;
            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                if (input.Contains(" | "))
                {
                    string[] token = input.Split(" | ", 2, StringSplitOptions.None);

                    string forceSide = token[0];
                    string user = token[1];
                    if(!users.ContainsKey(user))
                    {
                        if (!sides.ContainsKey(forceSide))
                        {
                            sides[forceSide] = new List<string>();
                        }
                        if (!sides[forceSide].Contains(user))
                            sides[forceSide].Add(user);
                     
                            users[user] = forceSide;
                        
                    }
                }
                else if (input.Contains(" -> "))
                {
                    string[] token = input.Split(" -> ", 2, StringSplitOptions.None);

                    string newForceSide = token[1];
                    string user = token[0];

                    string oldSide = string.Empty;

                    if(users.ContainsKey(user))
                    {
                        oldSide = users[user];
                        sides[oldSide].Remove(user);

                        if (!sides.ContainsKey(newForceSide))
                        {
                            sides[newForceSide] = new List<string>();
                        }
                        sides[newForceSide].Add(user);


                    }
                    else
                    {
                        if (!sides.ContainsKey(newForceSide))
                        {
                            sides[newForceSide] = new List<string>();
                        }
                        if (!sides[newForceSide].Contains(user))
                            sides[newForceSide].Add(user);

                    }
                    
                    if (oldSide != newForceSide)
                    {
                        users[user] = newForceSide;
                        Console.WriteLine($"{user} joins the {newForceSide} side!");
                    }
                }
            }

            foreach (var (side, userCollection) in sides
                                                   .Where(s => s.Value.Count > 0)
                                                   .OrderByDescending(s => s.Value.Count)
                                                   .ThenBy(s => s.Key))
            {
                Console.WriteLine($"Side: {side}, Members: {userCollection.Count}");
                foreach (var user in userCollection.OrderBy(u => u))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}
