using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    public class Person
    {
        private double money;
        private string name;
        private readonly List<Product> productsBought;

        public Person(string name, double money)
        {
            Name = name;
            Money = money;

            productsBought = new List<Product>();
        }
        public string Name
        {
            get => name; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");

                name = value;
            }
        }
        public double Money
        {
            get => money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }

        public List<Product> ProductsBought { get => productsBought; } 

        public void BuyProduct(Product product)
        {
            if (Money >= product.Price)
            {
                productsBought.Add(product);
                Money -= product.Price;

                Console.WriteLine($"{Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}"); 
            }
        }
    }
}
