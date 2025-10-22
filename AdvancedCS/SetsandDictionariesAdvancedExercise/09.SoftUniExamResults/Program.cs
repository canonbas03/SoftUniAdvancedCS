namespace _09.SoftUniExamResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var students = new Dictionary<string, int>();
            var courses = new Dictionary<string, int>();
            string input;
            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] tokens = input.Split("-");
                if (tokens.Length == 3)
                {
                    string student = tokens[0];
                    string course = tokens[1];
                    int points = int.Parse(tokens[2]);

                    if (!students.ContainsKey(student))
                    {
                        students[student] = 0;
                    }
                    if (students[student] < points)
                        students[student] = points;
                    if (!courses.ContainsKey(course))
                    {
                        courses[course] = 0;
                    }
                    courses[course]++;
                }
                else
                {
                    string bannedStudent = tokens[0];
                    if (students.ContainsKey(bannedStudent))
                        students.Remove(bannedStudent);
                }
            }
            Console.WriteLine("Results: ");
            foreach (var (name, score) in students.OrderByDescending(x=> x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{name} | {score}");
            }
            Console.WriteLine("Submissions:");
            foreach (var (course, submissions) in courses.OrderByDescending(s => s.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{course} - {submissions}");
            }
        }

    }
}
/*
Peter-Java-91
George-C#-84
Sam-JavaScript-90
Sam-C#-50
Sam-banned
exam finished
 */
