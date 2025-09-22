namespace _02.AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int entries = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> studentGrades = new();

            for (int i = 0; i < entries; i++)
            {
                string[] values = Console.ReadLine().Split();

                string studentName = values[0];
                decimal grade = decimal.Parse(values[1]);

                if(!studentGrades.ContainsKey(studentName))
                {
                    studentGrades[studentName] = new List<decimal>();
                }
                studentGrades[studentName].Add(grade);
            }

            foreach (var student in studentGrades)
            {
                Console.WriteLine($"{student.Key} -> {string.Join(" ", student.Value.Select(sv => sv.ToString("F2")))} (avg: {student.Value.Average():F2})");
            }
        }
    }
}

/*
5
George 6,00
George 5,50
George 6,00
John 4,40
Peter 3,30

4
Vlad 4,50
Peter 3,00
Vlad 5,00
Peter 3,66
 */