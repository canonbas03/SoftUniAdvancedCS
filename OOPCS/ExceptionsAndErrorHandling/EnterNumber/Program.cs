using System.Security.Cryptography.X509Certificates;

namespace EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> allNumbers = new List<int>();
            int lastNumber = 1;

            while (true)
            {
                try
                {
                    int number = ReadNumber(lastNumber, 100);
                    allNumbers.Add(number);
                    lastNumber = number;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Number!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                if(allNumbers.Count == 10)
                {
                    break;
                }
            }

            Console.WriteLine(string.Join(", ",allNumbers));
        }

        static int ReadNumber(int start, int end)
        {
            int number = int.Parse(Console.ReadLine());

            if (number <= start || number >= end)
            {
                throw new Exception($"Your number is not in range {start} - {end}!");
            }

            return number;
        }
    }
}
