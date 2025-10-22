using System.Threading.Channels;

namespace GenericSwapMethod
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var list = new List<Box<int>>(capacity: n);
            for (int i = 0; i < n; i++)
            {
                int value = int.Parse(Console.ReadLine());
                var box = new Box<int>(value);
                list.Add(box);
            }
            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Swap(list, indexes[0], indexes[1]);
            list.ForEach(Console.WriteLine);
        }

        static void Swap<T>(List<T> list, int index1, int index2)
        {
            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}
