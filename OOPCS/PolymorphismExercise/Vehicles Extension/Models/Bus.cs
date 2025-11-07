using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesExstension.Models;
using VehiclesExstention.Factories.Interfaces;

namespace VehiclesExstention.Models
{
    public class Bus : Vehicle, ISpecializedVehicle
    {
        private const double summerIncrease = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption
            => base.FuelConsumption + summerIncrease;

        public string DriveEmpty(double distance)
        {
            double neededFuel = base.FuelConsumption * distance;
            if (FuelQuantity < neededFuel)
            {
                return $"{GetType().Name} needs refueling";
            }

            FuelQuantity -= neededFuel;
            {
                return $"{GetType().Name} travelled {distance} km";
            }
        }
    }
}
