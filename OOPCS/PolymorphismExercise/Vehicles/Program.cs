using Vehicles.Models;
using Vehicles.Models.Interfaces;

namespace Vehicles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IVehicle> vehicles = new List<IVehicle>();

            string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            IVehicle car = new Car(double.Parse(tokens[1]), double.Parse(tokens[2]));
            vehicles.Add(car);

            tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            IVehicle truck = new Truck(double.Parse(tokens[1]), double.Parse(tokens[2]));
            vehicles.Add(truck);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string type = tokens[1];

                IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == type);

                if (command == "Drive")
                {
                    double distance = double.Parse(tokens[2]);
                    Console.WriteLine(vehicle.Drive(distance));
                    
                }
                else if (command == "Refuel")
                {
                    double fuel = double.Parse(tokens[2]);
                    vehicle.Refuel(fuel);
                   
                }
            }
            foreach (IVehicle vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }

        }
    }
}

/*
Car 15 0,3
Truck 100 0,9
4
Drive Car 9
Drive Car 30
Refuel Car 50
Drive Truck 10
 */
