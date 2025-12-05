using CarDealership.Models;
using CarDealership.Models.Contracts;
using CarDealership.Repositories.Contracts;

namespace CarDealership.Repositories
{
    internal class VehicleRepository : IRepository<IVehicle>
    {
        private List<IVehicle> vehicles = new List<IVehicle>();

        public IReadOnlyCollection<IVehicle> Models => vehicles.AsReadOnly();

        public void Add(IVehicle model)
        {
            vehicles.Add(model);
        }

        public bool Exists(string vehicle)
        {
            return vehicles.Any(v => v.Model == vehicle);
        }

        public IVehicle Get(string vehicle)
        {
            return vehicles.FirstOrDefault(v => v.Model == vehicle);
        }

        public bool Remove(string vehicle)
        {
            return vehicles.Remove(Get(vehicle));
        }
    }
}
