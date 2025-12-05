using CarDealership.Models.Contracts;
using CarDealership.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public abstract class Customer : ICustomer
    {
        private string name;
        private readonly List<string> purchases;
        public Customer(string name)
        {
            Name = name;
            purchases = new List<string>();
        }
        public string Name
        {
            get => name;

            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameIsRequired);
                }
                name = value;
            }
        }

        public IReadOnlyCollection<string> Purchases 
            => purchases.AsReadOnly();

        public void BuyVehicle(string vehicleModel)
        {
            purchases.Add(vehicleModel);
        }

        public override string ToString()
            => $"{Name} - Purchases: {Purchases.Count}";
    }
}