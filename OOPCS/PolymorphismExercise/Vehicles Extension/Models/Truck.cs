using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesExstension.Models
{
    public class Truck : Vehicle
    {
        private const double summerIncrease = 1.6;
        private const double fuelLoss = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption 
            => base.FuelConsumption + summerIncrease;

        public override string Refuel(double fuelAmount)
        {
            if (fuelAmount < 0)
            {
                return "Fuel must be a positive number";
            }
            else if (fuelAmount + FuelQuantity > TankCapacity)
            {
                return $"Cannot fit {fuelAmount} fuel in the tank";
            }

            return base.Refuel(fuelAmount * fuelLoss);
        }
    }
}
