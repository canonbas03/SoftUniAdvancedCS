using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string command;
            while ((command = Console.ReadLine()) != "Beast!")
            {
                string animalType = command;
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = data[0];
                int age = int.Parse(data[1]);
                string gender = data[2];

                try
                {
                    Animal animal;
                    switch (animalType)
                    {
                        case "Frog":
                            animal = new Frog(name,age,gender);
                            break;
                        case "Dog":
                            animal = new Dog(name,age,gender);
                            break;
                        case "Cat":
                            animal = new Cat(name,age,gender);
                            break;
                        case "Kitten":
                            animal = new Kitten(name,age);
                            break;
                        case "Tomcat":
                            animal = new Tomcat(name,age);
                            break;
                        default:
                            Console.WriteLine("Invalid input!");
                            continue;
                    }
                    animals.Add(animal);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
                

            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}
