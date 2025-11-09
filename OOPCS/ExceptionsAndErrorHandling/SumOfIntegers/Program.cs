namespace SumOfIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine().Split();

            int totalSum = 0;
            foreach (string element in elements)
            {
                try
                {
                    int number = int.Parse(element);

                    totalSum += number;

                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{element}' is out of range!");
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{element}' is in wrong format!");
                }
                finally
                {
                    Console.WriteLine($"Element '{element}' processed - current sum: {totalSum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {totalSum}");
        }
    }
}

/*
9876 string 10 -2147483649 -8 3 4.86555 8
 */
