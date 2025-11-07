
using VehiclesExstention.Core;
using VehiclesExstention.Core.Interfaces;
using VehiclesExstention.Factories;
using VehiclesExstention.Factories.Interfaces;
using VehiclesExstention.IO;
using VehiclesExstention.IO.Interfaces;

namespace Vehicles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IVehicleFactory vehicleFactory = new VehicleFactory();

            IEngine engine = new Engine(reader,writer,vehicleFactory);

            engine.Run();
        }
    }
}

/*
Car 30 0,04 70
Truck 100 0,5 300
Bus 40 0,3 150
8
Refuel Car -10
Refuel Truck 0
Refuel Car 10
Refuel Car 300
Drive Bus 10
Refuel Bus 1000
DriveEmpty Bus 100
Refuel Truck 1000
*/
