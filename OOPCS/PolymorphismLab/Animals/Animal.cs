using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Animal
    {
        public Animal(string name, string favoriteFood)
        {
            Name = name;
            FavoriteFood = favoriteFood;
        }

        public string Name { get; private set; }
        public string FavoriteFood { get; private set; }

        public virtual string ExplainSelf() => $"I am {Name} and my favorite food is {FavoriteFood}";
    }
}
