using CarDealership.Core.Contracts;
using CarDealership.Models;
using CarDealership.Models.Contracts;
using CarDealership.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CarDealership.Core
{
    public class Controller : IController
    {
        private Dealership dealership;
        public Controller()
        {
            dealership = new Dealership();
        }
        public string AddCustomer(string customerTypeName, string customerName)
        {
            if (customerTypeName != nameof(IndividualClient) &&
                customerTypeName != nameof(LegalEntityCustomer))
            {
                return string.Format(OutputMessages.InvalidType, customerTypeName);
            }

            if (dealership.Customers.Exists(customerName))
            {
                return string.Format(OutputMessages.CustomerAlreadyAdded, customerName);
            }

            ICustomer customer = customerTypeName == nameof(IndividualClient)
                ? new IndividualClient(customerName)
                : new LegalEntityCustomer(customerName);

            dealership.Customers.Add(customer);
            return string.Format(OutputMessages.CustomerAddedSuccessfully, customerName);
        }

        public string AddVehicle(string vehicleTypeName, string model, double price)
        {
            if (vehicleTypeName != nameof(SaloonCar) &&
                vehicleTypeName != nameof(SUV) &&
                vehicleTypeName != nameof(Truck))
            {
                return string.Format(OutputMessages.InvalidType, vehicleTypeName);
            }

            if (dealership.Vehicles.Exists(model))
            {
                return string.Format(OutputMessages.VehicleAlreadyAdded, model);
            }

            IVehicle vehicle;
            if (vehicleTypeName == nameof(SaloonCar))
            {
                vehicle = new SaloonCar(model, price);
            }
            else if (vehicleTypeName == nameof(SUV))
            {
                vehicle = new SUV(model, price);
            }
            else
            {
                vehicle = new Truck(model, price);
            }

            dealership.Vehicles.Add(vehicle);

            return string.Format(OutputMessages.VehicleAddedSuccessfully, vehicleTypeName, model, $"{vehicle.Price:f2}");

        }

        public string CustomerReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Customer Report:");
            foreach(ICustomer customer in dealership.Customers.Models.OrderBy(m => m.Name))
            {
                sb.AppendLine(customer.ToString());
                sb.AppendLine("-Models:");

                if(customer.Purchases.Count > 0)
                {
                    foreach(string purchase in customer.Purchases.OrderBy(p=>p))
                    {
                        sb.AppendLine($"--{purchase}");
                    }
                }
                else
                {
                    sb.AppendLine("--none");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string PurchaseVehicle(string vehicleTypeName, string customerName, double budget)
        {
            if (!dealership.Customers.Exists(customerName))
            {
                return string.Format(OutputMessages.CustomerNotFound, customerName);
            }

            if (!dealership.Vehicles.Models.Any(v => v.GetType().Name == vehicleTypeName))
            {
                return string.Format(OutputMessages.VehicleTypeNotFound, vehicleTypeName);
            }

            ICustomer customer = dealership.Customers.Get(customerName);
            string customerType = customer.GetType().Name;

            if (customerType == nameof(IndividualClient) && vehicleTypeName == nameof(Truck) ||
                customerType == nameof(LegalEntityCustomer) && vehicleTypeName == nameof(SaloonCar))
            {
                return string.Format(OutputMessages.CustomerNotEligibleToPurchaseVehicle, customerName, vehicleTypeName);
            }

            IVehicle[] eligibleVehicles = dealership.Vehicles.Models
                .Where(v => v.GetType().Name == vehicleTypeName && v.Price <= budget)
                .OrderByDescending(v => v.Price)
                .ToArray();

            if (!eligibleVehicles.Any())
            {
                return string.Format(OutputMessages.BudgetIsNotEnough, customerName, vehicleTypeName);
            }

            IVehicle vehicleForPurchase = eligibleVehicles[0];

            customer.BuyVehicle(vehicleForPurchase.Model);
            vehicleForPurchase.SellVehicle(customerName);

            return string.Format(OutputMessages.VehiclePurchasedSuccessfully,customerName,vehicleForPurchase.Model);

        }

        public string SalesReport(string vehicleTypeName)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{vehicleTypeName} Sales Report:");

            int totalSold = 0;
            foreach(IVehicle vehicle in dealership.Vehicles.Models
                .Where(m => m.GetType().Name == vehicleTypeName)
                .OrderBy(v => v.Model))
            {
                sb.AppendLine($"--{vehicle.ToString()}");

                totalSold += vehicle.SalesCount;
            }

            sb.AppendLine($"-Total Purchases: {totalSold}");

            return sb.ToString().TrimEnd();
        }
    }
}
