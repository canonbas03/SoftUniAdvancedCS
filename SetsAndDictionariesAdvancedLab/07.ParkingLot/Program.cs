using System.Globalization;

namespace _07.ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var parkingLot = new HashSet<string>();
            string input;
            while((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split(", ");
                string action = tokens[0];
                string licensePlate = tokens[1];

                if(action == "IN")
                {
                    parkingLot.Add(licensePlate);
                }
                else
                {
                    parkingLot.Remove(licensePlate);
                }
            }
            if(parkingLot.Count > 0)
            {
                foreach (var car in parkingLot)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
