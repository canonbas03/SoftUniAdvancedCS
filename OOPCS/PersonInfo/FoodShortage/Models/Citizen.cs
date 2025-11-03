using BirthdayCelebrations.Models.Interfaces;
using BorderControl.Models.Interfaces;
using FoodShortage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl.Models
{
    public class Citizen : BuyerName, IIdentifiable, IBirthable
    {
        public Citizen(string id, string name, int age, string birthdate) : base( name)
        {
            ID = id;
            Age = age;
            Birthdate = birthdate;
        }
        public string ID { get; private set; }
        public int Age { get; private set; }

        public string Birthdate { get; private set; }


        public override void BuyFood()
        {
            base.Food += 10;
        }
    }
}
