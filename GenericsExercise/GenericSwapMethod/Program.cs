namespace GenericSwapMethod
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var list = new List<Box<string>>(capacity: n);
            for (int i = 0; i < n; i++)
            {
                string value = Console.ReadLine();
                var box = new Box<string>(value);
                list.Add(box);
            }
            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Swap(list, indexes[0], indexes[1]);
            foreach (Box<string> item in list)
            {
                Console.WriteLine(item);
            }
        }

        static void Swap<T>(List<T> list, int index1, int index2)
        {
            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}
