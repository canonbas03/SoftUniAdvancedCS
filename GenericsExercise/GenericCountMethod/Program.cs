using System.Diagnostics.Metrics;

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

        static int CountGreaterThan<T>(List<T> list, T compareValue) => Count(list, el => Comparer<T>.Default.Compare(el, compareValue) > 0);
        //{
        //    int count = 0;
        //    foreach (T item in list)
        //    {
        //        int compareResult = Comparer<T>.Default.Compare(item, compareValue);
        //        if (compareResult > 0) count++;
        //    }
        //    return count;
        //}
        static int Count<T>(List<T> list, Func<T, bool> condition)
        {
            int count = 0;
            foreach (T item in list)
                if (condition(item)) count++;

            return (count);
        }
    }
}
