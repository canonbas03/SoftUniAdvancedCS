using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private double price;

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");

                name = value;
            }
        }
        public double Price
        {
            get => price;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Money cannot be negative");

                price = value;
            }
        }




    }
}
