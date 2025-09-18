namespace _07.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int petrolPumps = int.Parse(Console.ReadLine());
            Queue<(int index, int fuel, int distance)> pumps = new Queue<(int, int, int)>();

            for (int i = 0; i < petrolPumps; i++)
            {
                int[] values = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int fuel = values[0];
                int distance = values[1];
                pumps.Enqueue((i, fuel, distance));
            }

            int currentFuel = 0;
            int processed = 0;
            int currentPump = pumps.Peek().index;

            while (true)
            {
                var pump = pumps.Dequeue();
                currentFuel += pump.fuel - pump.distance;
                pumps.Enqueue(pump);
                
                if(currentFuel < 0)
                {
                    processed = 0;
                    currentFuel = 0;
                    currentPump = pumps.Peek().index; 
                }
                else
                {
                    processed++;
                }

                if(processed == petrolPumps)
                {
                    break;
                }

            }
            Console.WriteLine(currentPump);
        }
    }
}
