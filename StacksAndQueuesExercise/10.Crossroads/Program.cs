namespace _10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int green = int.Parse(Console.ReadLine());
            int free = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            string input;
            int passedCars = 0;
            string crashedCar = string.Empty;
            int crashIndex = -1;
            bool crashHappened = false;
            while (!crashHappened && (input = Console.ReadLine()) != "END" )
            {
                if (input == "green")
                {
                    int remainingGreenTime = green;
                    while (remainingGreenTime > 0 && cars.Count > 0 && !crashHappened)
                    {
                        string car = cars.Dequeue();
                        // 5 2 - abcd - 1 2 - abc - -2 2 - abc
                        if (car.Length > remainingGreenTime + free)
                        {
                            crashedCar = car;
                            crashHappened = true;
                            crashIndex = remainingGreenTime + free;
                        }
                        else
                        {
                            passedCars++;
                            remainingGreenTime -= car.Length;
                        }
                    }
                }
                else cars.Enqueue(input);
            }
            if (crashHappened)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{crashedCar} was hit at {crashedCar[crashIndex]}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passedCars} total cars passed the crossroads.");
            }
        }
    }
}
