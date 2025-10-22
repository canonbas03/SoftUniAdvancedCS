namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car()
            {
                Make = "Merc",
                Model = "wow",
                Year = 2026,
                FuelQuantity = 50,
                FuelConsumption = 10
            };

            car.Drive(50);
            Console.WriteLine(car.WhoAmI());
        }
    }
}
