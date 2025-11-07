using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesExstension.Models.Interfaces;

namespace VehiclesExstension.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public virtual double FuelQuantity
        {
            get => fuelQuantity;

            protected set
            {
                if(TankCapacity < value)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }

        public virtual double FuelConsumption { get; protected set; }

        public double TankCapacity { get; protected set; }

        public string Drive(double distance)
        {
            if (FuelQuantity < FuelConsumption * distance)
            {
                return $"{GetType().Name} needs refueling";
            }

            FuelQuantity -= FuelConsumption * distance;
            return $"{GetType().Name} travelled {distance} km";
        }

        public virtual string Refuel(double fuelAmount)
        {
            if (fuelAmount <= 0)
            {
                return "Fuel must be a positive number";
            }
            else if (fuelAmount + FuelQuantity > TankCapacity)
            {
                return $"Cannot fit {fuelAmount} fuel in the tank";
            }

            FuelQuantity += fuelAmount;

            return "Refueled";
        }

        public override string ToString() => $"{GetType().Name}: {FuelQuantity:f2}";
    }
}
