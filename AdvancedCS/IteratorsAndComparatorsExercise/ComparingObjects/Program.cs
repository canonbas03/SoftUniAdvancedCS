using System.Text;

namespace ComparingObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(tokens[0], int.Parse(tokens[1]), tokens[2]);
                people.Add(person);
            }

            int n = int.Parse(Console.ReadLine());
            Person target = people[n - 1];

            int matches = 0;
            foreach (Person person in people)
            {
                int compariosn = target.CompareTo(person);
                if(compariosn == 0) matches++;
            }

            if(matches == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matches} {people.Count - matches} {people.Count}");
            }
        }
    }
}
