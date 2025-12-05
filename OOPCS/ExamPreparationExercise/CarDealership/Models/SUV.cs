using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class SUV : Vehicle
    {
        private const double PRICE_MULTIPLIER = 1.2;

        public SUV(string model, double price) 
            : base(model, price * PRICE_MULTIPLIER)
        {
        }
    }
}
