namespace _06.SpeedRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> carByModel = new();

            int numberOfCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string model = tokens[0];
                double fuelAmount = double.Parse(tokens[1]);
                double fuelConsumption = double.Parse(tokens[2]);

                carByModel[model] = new Car
                {
                    Model = model,
                    FuelAmount = fuelAmount,
                    FuelConsumption = fuelConsumption
                };
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();

                string model = tokens[1];
                int distance = int.Parse(tokens[2]);

                if (!carByModel[model].Drive(distance))
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }

            foreach (Car car in carByModel.Values)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TraveledDistance}");
            }
        }
    }
}
/*
2
AudiA4 23 0,3
BMW-M2 45 0,42
Drive BMW-M2 56
Drive AudiA4 5
Drive AudiA4 13
End
 */