namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());

            Car carOne = new Car();
            Car carTwo = new Car(make, model, year);
            Car carThree = new Car(make, model, year, fuelQuantity, fuelConsumption);

        }
    }
}
