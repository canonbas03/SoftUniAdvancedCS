using BorderControl.Models;
using BorderControl.Models.Interfaces;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> list = new();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split();

                IIdentifiable identifiable = tokens.Length == 3
                    ? new Citizen(tokens[2], tokens[0], int.Parse(tokens[1]))
                    : new Robot(tokens[1], tokens[0]);

                list.Add(identifiable);
            }

            string fakeIdDigit = Console.ReadLine();

            foreach (IIdentifiable identifiable in list)
            {
                if(identifiable.ID.EndsWith(fakeIdDigit))
                {
                    Console.WriteLine(identifiable.ID);
                }
            }
        }
    }
}


/*
Peter 22 9010101122
MK-13 558833251
MK-12 33283122
End
122
 */