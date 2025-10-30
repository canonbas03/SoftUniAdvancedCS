using PizzaCalories.Models;

namespace PizzaCalories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] data = command.Split();
                string flourType = data[0];
                string bakingType = data[1];
                double weight = double.Parse(data[2]);
                try
                {
                    Dough dough = new Dough(flourType, bakingType, weight);
                    Console.WriteLine(dough.CalculateCalories());
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            
        }
    }
}
