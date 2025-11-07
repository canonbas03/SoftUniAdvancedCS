using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesExstension.Models.Interfaces;

namespace VehiclesExstention.Factories.Interfaces
{
    public interface IVehicleFactory
    {
        IVehicle Create(string type, double fuelQuantity,double fuelConsumption, double tankCapacity);
    }
}
