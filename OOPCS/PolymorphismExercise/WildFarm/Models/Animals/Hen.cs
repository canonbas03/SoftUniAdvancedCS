using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double WeightMultiplier = 0.35;
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override string AskForFood() => "Cluck";

        public override void Eat(IFood food)
        {
            Weight += WeightMultiplier * food.Quantity;
            FoodEaten += food.Quantity;
        }

    }
}
