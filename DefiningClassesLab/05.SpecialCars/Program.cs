namespace CarManufacturer
{
    public class StartUp
    {
        public static List<Tire[]> tires = new();
        public static List<Engine> engines = new();
        public static List<Car> cars = new();
        static void Main(string[] args)
        {
            //string make = Console.ReadLine();
            //string model = Console.ReadLine();
            //int year = int.Parse(Console.ReadLine());
            //double fuelQuantity = double.Parse(Console.ReadLine());
            //double fuelConsumption = double.Parse(Console.ReadLine());

            CollectTires();
            CollectEngines();
            CreateCars();
            DriveCars();


        }
        public static void CollectTires()
        {
            string input;
            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] tokens = input.Split();

                int firstYear = int.Parse(tokens[0]); double firstPressure = double.Parse(tokens[1]);
                int secondYear = int.Parse(tokens[2]); double secondPressure = double.Parse(tokens[3]);
                int thirdYear = int.Parse(tokens[4]); double thirdPressure = double.Parse(tokens[5]);
                int fourthYear = int.Parse(tokens[6]); double fourthPressure = double.Parse(tokens[7]);

                Tire[] tiresCollection =
                {
                    new(firstYear,firstPressure),
                    new(secondYear,secondPressure),
                    new(thirdYear,thirdPressure),
                    new(fourthYear,fourthPressure),
                };
                tires.Add(tiresCollection);
            }
        }

        public static void CollectEngines()
        {
            string input;
            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] tokens = input.Split();

                int horsePower = int.Parse(tokens[0]);
                double cubicCapacity = double.Parse(tokens[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);
            }
        }

        public static void CreateCars()
        {
            string input;
            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] tokens = input.Split();

                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                double fuelQuantity = double.Parse(tokens[3]);
                double fuelConsumption = double.Parse(tokens[4]);
                int endineIndex = int.Parse(tokens[5]);
                int tiresIndex = int.Parse(tokens[6]);

                Tire[] tiresCollection = tires[tiresIndex];
                Engine engine = engines[endineIndex];

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tiresCollection);
                cars.Add(car);
            }
        }

        public static void DriveCars()
        {
            List<Car> filteredCars = cars
                .Where(c => c.Year >= 2017)
                .Where(c => c.Engine.HorsePower > 330)
                .Where(c =>
                {
                    double tirePressureSum = c
                    .Tires
                    .Select(t => t.Pressure)
                    .Sum();
                    return tirePressureSum > 9 && tirePressureSum < 10;
                })
                .ToList();

            foreach (Car car in filteredCars)
            {
                car.Drive(20);
                Console.Write(car.WhoAmI());
            }
        }
    }
}

/*
2 2,6 3 1,6 2 3,6 3 1,6
1 3,3 2 1,6 5 2,4 1 3,2
No more tires
331 2,2
145 2,0
Engines done
Audi A5 2017 200 12 0 0
BMW X5 2007 175 18 1 1
Show special
 */
