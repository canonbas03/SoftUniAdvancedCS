

namespace _08.CarSalesman
{
    internal class Program
    {
        static Dictionary<string, Engine> enginesByModel = new Dictionary<string, Engine>();
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                Engine engine = ParseEngine(tokens);
                enginesByModel[engine.Model] = engine;
            }
            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                Car car = ParseCar(tokens);
                cars.Add(car);
            }

            PrintCars(cars);
        }

        public static Engine ParseEngine(string[] tokens)
        {
            string model = tokens[0];
            int power = int.Parse(tokens[1]);
            int? displacement = null;
            string? efficiency = null;

            if (tokens.Count() == 3)
            {
                if (int.TryParse(tokens[2], out int value))
                    displacement = value;
                else
                    efficiency = tokens[2];
            }
            else if(tokens.Count() == 4)
            {
                displacement = int.Parse(tokens[2]);
                efficiency = tokens[3];
            }

                Engine engine = new(model, power, displacement, efficiency);
            return engine;
        }
        private static Car ParseCar(string[] tokens)
        {
            string model = tokens[0];
            Engine engine = enginesByModel[tokens[1]];

            int? weight = null;
            string? color = null;

            if (tokens.Count() == 3)
            {
                if (int.TryParse(tokens[2], out int value))
                    weight = value;
                else
                    color = tokens[2];
            }
            else if(tokens.Count() == 4)
            {
               weight = int.Parse(tokens[2]);
               color = tokens[3];
            }
                Car car = new(model, engine, weight, color);
            return car;
        }
        private static void PrintCars(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model}: ");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                Console.WriteLine($"    Displacement: {car.Engine.Displacement?.ToString() ?? "n/a"}");
                Console.WriteLine($"    Efficiency: {car.Engine.Efficiency ?? "n/a"}");
                Console.WriteLine($"  Weight: {car.Weight?.ToString() ?? "n/a"}");
                Console.WriteLine($"  Color: {car.Color ?? "n/a"}");

            }
        }

    }
}
/*
2
V8-101 220 50
V4-33 140 28 B
3
FordFocus V4-33 1300 Silver
FordMustang V8-101
VolkswagenGolf V4-33 Orange
 */