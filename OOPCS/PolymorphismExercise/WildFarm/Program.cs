using WildFarm.Core;
using WildFarm.Factories;

namespace WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            IAnimalFactory animalFactory = new AnimalFactory();
            IFoodFactory foodFactory = new FoodFactory();

            Engine engine = new Engine(animalFactory,foodFactory);

            engine.Run();

        }
    }
}
