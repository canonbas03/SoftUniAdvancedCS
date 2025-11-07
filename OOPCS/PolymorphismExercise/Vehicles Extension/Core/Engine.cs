using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesExstension.Models.Interfaces;
using VehiclesExstention.Core.Interfaces;
using VehiclesExstention.Factories;
using VehiclesExstention.Factories.Interfaces;
using VehiclesExstention.IO.Interfaces;

namespace VehiclesExstention.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;

        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;
        }

        public void Run()
        {
            List<IVehicle> vehicles = new List<IVehicle>();

            string[] tokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            IVehicle vehicle = vehicleFactory.Create(tokens[0], double.Parse(tokens[1]), double.Parse(tokens[2]), double.Parse(tokens[3]));
            vehicles.Add(vehicle);

            tokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            vehicle = vehicleFactory.Create(tokens[0], double.Parse(tokens[1]), double.Parse(tokens[2]), double.Parse(tokens[3]));
            vehicles.Add(vehicle);

            tokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            vehicle = vehicleFactory.Create(tokens[0], double.Parse(tokens[1]), double.Parse(tokens[2]), double.Parse(tokens[3]));
            vehicles.Add(vehicle);

            int n = int.Parse(reader.ReadLine());
            for (int i = 0; i < n; i++)
            {
                tokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string type = tokens[1];

                vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == type);

                if (command == "Drive")
                {
                    double distance = double.Parse(tokens[2]);
                    writer.WriteLine(vehicle.Drive(distance));

                }
                else if (command == "DriveEmpty")
                {
                    double distance = double.Parse(tokens[2]);

                    if (vehicle is ISpecializedVehicle)
                    {
                        writer.WriteLine(((ISpecializedVehicle)vehicle).DriveEmpty(distance));
                    }

                }
                else if (command == "Refuel")
                {
                    double fuel = double.Parse(tokens[2]);
                    string refuelMessage = vehicle.Refuel(fuel);

                    if (refuelMessage != "Refueled")
                    {
                        writer.WriteLine(refuelMessage);
                    }

                }
            }

            foreach (IVehicle each_vehicle in vehicles)
            {
                writer.WriteLine(each_vehicle.ToString());
            }
        }
    }
}
