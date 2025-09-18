namespace _07.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int petrolPumps = int.Parse(Console.ReadLine());
            Queue<(int index,int fuel, int distance)> pumps = new Queue<(int ,int ,int )>();

            for (int i = 0; i < petrolPumps; i++)
            {
                int[] values = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int fuel = values[0];
                int distance = values[1];
                pumps.Enqueue((i,fuel,distance));
            }

            int currentPump = pumps.Peek().index;
        }
    }
}
