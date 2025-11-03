using BirthdayCelebrations.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShortage.Models
{
    public abstract class BuyerName : IBuyer, INameble
    {
        protected BuyerName(string name)
        {
            Name = name;
        }

        public int Food { get; protected set; }

        public string Name { get; private set; }

        public abstract void BuyFood();
        
    }
}
