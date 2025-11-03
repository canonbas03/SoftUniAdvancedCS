using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;
using BorderControl.Models;
using BorderControl.Models.Interfaces;
using FoodShortage.Models;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<BuyerName> list = new();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                BuyerName buyer;
                if(tokens.Length == 4)
                {
                    buyer = new Citizen(tokens[2], tokens[0], int.Parse(tokens[1]), tokens[3]);
                }
                else
                {
                    buyer = new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]);
                }
                list.Add(buyer);
            }

            int totalFood = 0;
            string command;
            while((command = Console.ReadLine()) != "End")
            {
                BuyerName buyer = list.FirstOrDefault(b => b.Name == command);
                if(buyer != null)
                {
                    buyer.BuyFood();
                }
            }
            Console.WriteLine(list.Sum(b => b.Food));
        }
    }
}


/*
4
Stam 23 TheSwarm
Ton 44 7308185527 18/08/1973
George 31 Terrorists
Pen 27 881222212 22/12/1988
John
Geo rge
John
Joro
Stam
Pen
End
 */