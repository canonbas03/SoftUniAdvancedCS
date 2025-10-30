using PizzaCalories.Models;
using System.Threading.Channels;

namespace PizzaCalories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] pizzaData = Console.ReadLine().Split();
            string pizzaName = pizzaData[1];

            string[] doughData = Console.ReadLine().Split();

            string flourType = doughData[1];
            string bakingTech = doughData[2];
            double doughWeight = double.Parse(doughData[3]);

            try
            {
                Dough dough = new(flourType, bakingTech, doughWeight);

                Pizza pizza = new Pizza(pizzaName, dough);

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] toppingData = command.Split();
                    Topping topping = new Topping(toppingData[1], double.Parse(toppingData[2]));

                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
/*
Pizza Meatless
Dough Wholegrain Crispy 100
Topping Veggies 50
Topping Cheese 50
END
 */