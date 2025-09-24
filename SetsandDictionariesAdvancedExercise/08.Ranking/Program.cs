namespace _08.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var contestPasswords = new Dictionary<string, string>();
            string input;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] tokens = input.Split();
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
            }
        }
    }
}
