namespace _08.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var contestPasswords = new Dictionary<string, string>();
            var userContest = new Dictionary<string, Dictionary<string, int>>();
            string input;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] tokens = input.Split(":");
                string contest = tokens[0];
                string password = tokens[1];

                if(!contestPasswords.ContainsKey(contest))
                {
                    contestPasswords[contest] = string.Empty;
                }
                contestPasswords[contest] = password;
            }
            while((input =  Console.ReadLine()) != "end of submissions")
            {
                string[] tokens = input.Split("=>");
                // C# Fundamentals=>fundPass=>Tanya=>350
                string course = tokens[0];
                string password = tokens[1];
                string studentName = tokens[2];
                int points = int.Parse(tokens[3]);

                if(contestPasswords.ContainsKey(course))
                {
                    if (contestPasswords[course] == password)
                    {
                        if(!userContest.ContainsKey(studentName))
                        {
                            userContest[studentName] = new Dictionary<string, int>();
                        }
                        if (!userContest[studentName].ContainsKey(course))
                        {
                            userContest[studentName][course] = 0;
                        }
                        userContest[studentName][course] = userContest[studentName][course] < points ? points : userContest[studentName][course];
                    }
                }
            }
            var bestCandidate = userContest.OrderByDescending(x => x.Value.Values.Sum()).First();
            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value.Values.Sum()} points.");
            Console.WriteLine("Ranking:");
            foreach (var candidate in userContest.OrderBy(x => x.Key))
            {
                Console.WriteLine(candidate.Key);
                foreach (var (course, points) in candidate.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {course} -> {points}");
                }
            }
        }
    }
}
