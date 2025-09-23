namespace _07.TheVLogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var usersMap = new Dictionary<string, (HashSet<string> FollowedBy, HashSet<string> Following)>();

            string input;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] data = input.Split();
                if (data.Length == 4 && data[1] == "joined")
                {
                    string username = data[0];
                    if (!usersMap.ContainsKey(username))
                    {
                        usersMap[username] = (new HashSet<string>(), new HashSet<string>());
                    }
                }
                else if (data.Length == 3 && data[1] == "followed")
                {
                    string fan = data[0], celebrity = data[2];
                    if (fan != celebrity && usersMap.ContainsKey(fan) && usersMap.ContainsKey(celebrity))
                    {
                        usersMap[fan].Following.Add(celebrity);
                        usersMap[celebrity].FollowedBy.Add(fan);
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {usersMap.Keys.Count} vloggers in its logs.");
            int index = 1;
            foreach (var (user, follows) in usersMap.OrderByDescending(x => x.Value.FollowedBy.Count).ThenBy(x => x.Value.Following.Count))
            {
                Console.WriteLine($"{index}. {user} : {follows.FollowedBy.Count} followers, {follows.Following.Count} following");
                if(index == 1)
                {
                    foreach (var follower in follows.FollowedBy)
                    {
                        Console.WriteLine($"* {follower}");
                    }
                }
                index++;
            }

        }
    }
}

/*
JennaMarbles joined The V-Logger
JennaMarbles followed Zoella
AmazingPhil joined The V-Logger
JennaMarbles followed AmazingPhil
Zoella joined The V-Logger
JennaMarbles followed Zoella
Zoella followed AmazingPhil
Christy followed Zoella
Zoella followed Christy
JacksGap joined The V-Logger
JacksGap followed JennaMarbles
PewDiePie joined The V-Logger
Zoella joined The V-Logger
Statistics
 */