namespace _01.MissionToMars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> solarEnergy = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Queue<int> distances = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));

            Dictionary<string, int> resourceByAmount = new Dictionary<string, int>()
            {
                ["Iron"] = 80,
                ["Titanium"] = 90,
                ["Aluminium"] = 100,
                ["Chlorine"] = 60,
                ["Sulfur"] = 70
            };

            Queue<string> resources = new Queue<string>(resourceByAmount.Keys);
            List<string> collectedResources = new List<string>();

            while(solarEnergy.Count > 0 && distances.Count > 0 && resources.Count > 0)
            {
                int energy = solarEnergy.Pop();
                int distance = distances.Dequeue();

                string currentMineral = resources.Peek();
                if(energy+distance >= resourceByAmount[currentMineral])
                {
                    collectedResources.Add(resources.Dequeue());

                }
            }

            if(collectedResources.Count == resourceByAmount.Keys.Count())
            {
                Console.WriteLine("Mission complete! All minerals have been collected.");
            }
            else
            {
                Console.WriteLine("Mission not completed! Awaiting further instructions from Earth.");
            }

            if(collectedResources.Count > 0)
            {
                Console.WriteLine("Collected resources:");
                foreach (string mineral in collectedResources)
                {
                    Console.WriteLine(mineral);
                }
            }
        }
    }
}


/*
40, 40, 40, 40, 40, 40, 40
40, 50, 60, 20, 30, 5, 2

10, 20, 34, 26, 12, 10, 45
30, 28, 17, 17, 13, 10, 10

 */