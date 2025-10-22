namespace _01.ClimbThePeeks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> difficultyByName = new()
            {
                {"Vihren",80 },
                {"Kutelo",90 },
                {"Banski Suhodol",100 },
                {"Polezhan",60 },
                {"Kamenitza",70 },
            };

            Stack<int> food = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Queue<int> stamina = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));

            Queue<string> peaks = new Queue<string>(difficultyByName.Keys);
            List<string> conquredPeaks = new List<string>();

            while (food.Count > 0 && stamina.Count > 0 && peaks.Count > 0)
            {
                int foodPortion = food.Pop();
                int staminaStrength = stamina.Dequeue();
                string peakName = peaks.Peek();
                int difficulty = difficultyByName[peakName];

                if (foodPortion + staminaStrength >= difficulty)
                {
                    conquredPeaks.Add(peaks.Dequeue());
                }
            }

            if(peaks.Count == 0)
            {
                Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
            }
            else
            {
                Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
            }

            if(conquredPeaks.Count > 0)
            {
                Console.WriteLine("Conquered peaks:");
                foreach (string peak in conquredPeaks)
                {
                    Console.WriteLine(peak);
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
