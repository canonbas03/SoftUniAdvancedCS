namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car()
            {
                Make = "BMW",
                Model = "OMG",
                Year = 2031
            };
            Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}");

        }
    }
}
