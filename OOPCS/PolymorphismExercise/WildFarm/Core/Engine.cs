using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Factories;
using WildFarm.Models.Interfaces;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly IAnimalFactory animalFactory;
        private readonly IFoodFactory foodFactory;

        private readonly ICollection<IAnimal> animals;

        public Engine(IAnimalFactory animalFactory, IFoodFactory foodFactory)
        {
            this.animalFactory = animalFactory;
            this.foodFactory = foodFactory;

            animals = new List<IAnimal>();
        }

        public void Run()
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                IAnimal animal = animalFactory.CreateAnimal(tokens);
                Console.WriteLine(animal.AskForFood());
                animals.Add(animal);

                tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                IFood food = foodFactory.CreateFood(tokens);
                animal.Eat(food);
            }

            foreach (IAnimal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
/*
Tiger Rex 167,7 Asia Bengal
Vegetable 1
Dog Tommy 500 Street
Vegetable 150
End
 */
