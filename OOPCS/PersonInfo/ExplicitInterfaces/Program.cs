namespace ExplicitInterfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                IPerson person = new Citizen(tokens[0], tokens[1], int.Parse(tokens[2]));
                Console.WriteLine( person.GetName());

                IResident resident = new Citizen(tokens[0], tokens[1], int.Parse(tokens[2]));
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
