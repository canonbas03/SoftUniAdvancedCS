using System.Collections;

namespace _11.KeyRevolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int price = int.Parse(Console.ReadLine());
            int gunBarrel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int intelligenceValue = int.Parse(Console.ReadLine());
            int totalBullets = bullets.Count();

            // locks front to back
            // bullets back to front

            Stack<int> bulletStack = new Stack<int>(bullets);
            Queue<int> lockQueue = new Queue<int>(locks);

            int currentBarrel = gunBarrel;
            while (bulletStack.Count > 0 && lockQueue.Count > 0)
            {
                int currentBullet = bulletStack.Pop();
                currentBarrel--;
                if (currentBullet > lockQueue.First())
                {
                    Console.WriteLine("Ping!");
                }
                else
                {
                    Console.WriteLine("Bang!");
                    lockQueue.Dequeue();
                }

                if (currentBarrel == 0 && bulletStack.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    currentBarrel = gunBarrel;
                }
            }
            if (bulletStack.Count() < lockQueue.Count())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {lockQueue.Count}");
            }
            else
            {
                int totalBulletPrice = (totalBullets - bulletStack.Count()) * price;
                int earned = intelligenceValue - totalBulletPrice;
                Console.WriteLine($"{bulletStack.Count} bullets left. Earned ${earned}");
            }
        }
    }
}
