namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //string make = Console.ReadLine();
            //string model = Console.ReadLine();
            //int year = int.Parse(Console.ReadLine());
            //double fuelQuantity = double.Parse(Console.ReadLine());
            //double fuelConsumption = double.Parse(Console.ReadLine());

            //Car carOne = new Car();
            //Car carTwo = new Car(make, model, year);
            //Car carThree = new Car(make, model, year, fuelQuantity, fuelConsumption);

            Engine engine = new Engine(200, 5);
            Tire[] tires = new Tire[]
            {
                new Tire(2025,5),
                new Tire(2025,4.8),
                new Tire(2024,5),
                new Tire(2025,4.9)
            };
            Car carFour = new Car(
                make: "Lambo",
                model: "Alaturka",
                year: 2026,
                fuelQuantity: 50,
                fuelConsumption: 15,
                engine,
                tires);
        }
    }
}
