namespace _7.RawData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                Tire[] tireCollection = new Tire[]
                {
                    new (double.Parse(input[5]), int.Parse(input[6])),
                    new (double.Parse(input[7]), int.Parse(input[8])),
                    new (double.Parse(input[9]), int.Parse(input[10])),
                    new (double.Parse(input[11]), int.Parse(input[12]))
                };

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoType, cargoWeight);
                Tire[] tires = tireCollection;

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();
            Func<Car, bool> condition;
            if (command == "fragile")
            {
                condition = c => c.Cargo.Type == command && c.Tires.Any(t => t.Pressure < 1);
            }
            else if (command == "flammable")
            {
                condition = c => c.Cargo.Type == command && c.Engine.Power > 250;
            }
            else
                condition = _ => false;

            foreach (Car car in cars.Where(condition))
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}

/*
4
ChevroletExpress 215 255 1200 flammable 2,5 1 2,4 2 2,7 1 2,8 1
ChevroletAstro 210 230 1000 flammable 2 1 1,9 2 1,7 3 2,1 1
DaciaDokker 230 275 1400 flammable 2,2 1 2,3 1 2,4 1 2 1
Citroen2CV 190 165 1200 fragile 0,8 3 0,85 2 0,7 5 0,95 2
flammable
 */
