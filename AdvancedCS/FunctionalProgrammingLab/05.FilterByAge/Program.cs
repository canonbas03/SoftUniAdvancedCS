namespace _05.FilterByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            List<(string name, int age)> people = new List<(string name, int age)>();
            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine().Split(", ");
                string name = tokens[0];
                int age = int.Parse(tokens[1]);


                people.Add((name, age));
            }
            string condition = Console.ReadLine();
            int ageTreshold = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<int, bool> conditionCheck = 
            condition == "younger" 
            ? conditionCheck = age => age < ageTreshold 
            : conditionCheck = age => age >= ageTreshold;

            List<(string name, int age)> filteredPeople = Filter(people, conditionCheck);

            Func<string, int, string> formatter;
            if (format == "name")
            {
                formatter = (name, age) => name;
            }
            else if (format == "age")
            {
                formatter = (name, age) => age.ToString();
            }
            else
            {
                formatter = (name, age) => $"{name} - {age}";
            }

            foreach (var (name, age) in filteredPeople)
            {
                string result = formatter(name, age);

                Console.WriteLine(result);

            }
        }

        private static List<(string name, int age)> Filter(List<(string name, int age)> people, Func<int, bool> conditionCheck)
        {
            List<(string name, int age)> result = new List<(string name, int age)>();
            foreach (var person in people)
            {
                if (conditionCheck(person.age))
                {
                    result.Add(person);
                }
            }
            return result;
        }
    }
}

/*
5
Lucas, 20
Tomas, 18
Mia, 29
Noah, 31
Simo, 16
older
20
name age
 */