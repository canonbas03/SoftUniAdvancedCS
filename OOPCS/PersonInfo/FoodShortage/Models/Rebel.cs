using BirthdayCelebrations.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShortage.Models
{
    public class Rebel : BuyerName
    {
        public Rebel(string name, int age, string group) : base (name)
        {
            Age = age;
            Group = group;
        }

        public int Age { get; private set; }
        public string Group { get; private set; }


        public override void BuyFood()
        {
            base.Food += 5;
        }
    }
}
