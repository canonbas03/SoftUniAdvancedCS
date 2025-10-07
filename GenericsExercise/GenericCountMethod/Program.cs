namespace GenericCountMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var list = new List<double>(n);
            for (int i = 0; i < n; i++)
            {
                double value = double.Parse(Console.ReadLine());
                list.Add(value);
            }

            double compareValue = double.Parse(Console.ReadLine());
            Console.WriteLine(CountGreaterThan(list, compareValue));

        }
        static int CountGreaterThan<T>(List<T> list, T compareValue)
        {
            int count = 0;
            foreach (T item in list)
            {
                int compareResult = Comparer<T>.Default.Compare(item, compareValue);
                if(compareResult > 0) count++; 
            }
            return count;
        }
    }
}
