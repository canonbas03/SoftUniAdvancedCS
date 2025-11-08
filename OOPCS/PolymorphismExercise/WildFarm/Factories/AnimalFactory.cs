using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Animals;
using WildFarm.Models.Interfaces;

namespace WildFarm.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string[] animalTokens)
        {
            string type = animalTokens[0];
            string name = animalTokens[1];
            double weight = double.Parse(animalTokens[2]);

            return type switch
            {
                "Owl" => new Owl(name, weight, double.Parse(animalTokens[3])),
                "Hen" => new Hen(name, weight, double.Parse(animalTokens[3])),
                "Mouse" => new Mouse(name, weight, animalTokens[3]),
                "Dog" => new Dog(name, weight, animalTokens[3]),
                "Cat" => new Cat(name, weight, animalTokens[3], animalTokens[4]),
                "Tiger" => new Tiger(name, weight, animalTokens[3], animalTokens[4]),
                _ => throw new ArgumentException("Invalid animal type!")
            };
        }
    }
}
