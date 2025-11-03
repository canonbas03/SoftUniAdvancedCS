using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;
using BorderControl.Models;
using BorderControl.Models.Interfaces;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IBirthable> list = new();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split();

                IBirthable birthable;
                switch (tokens[0])
                {
                    case "Citizen":
                        birthable = new Citizen(tokens[3], tokens[1], int.Parse(tokens[2]), tokens[4]);
                        list.Add(birthable);

                        break;
                    case "Pet":
                        birthable = new Pet(tokens[1], tokens[2]);
                        list.Add(birthable);

                        break;
                }

            }

            string yearToCheck = Console.ReadLine();

            foreach (IBirthable birthable in list)
            {
                if (birthable.Birthdate.EndsWith(yearToCheck))
                {
                    Console.WriteLine(birthable.Birthdate);
                }
            }
        }
    }
}


/*
Citizen Stam 16 0041018380 01/01/2000
Robot MK-10 12345678
Robot PP-09 00000001
Pet Topcho 24/12/2000
Pet Rex 12/06/2002
End
2000
 */