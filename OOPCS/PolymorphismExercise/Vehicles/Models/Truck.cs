using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double summerIncrease = 1.6;
        private const double fuelLoss = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + summerIncrease;

        public override void Refuel(double fuelAmount)
        {
            base.Refuel(fuelAmount * fuelLoss);
        }
    }
}
