using Telephony.Models.Interfaces;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numberTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] urlTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string number in numberTokens)
            {
                try
                {
                    ICallable phone = number.Length == 10
                       ? new Smartphone()
                       : new StationaryPhone();

                    Console.WriteLine(phone.Call(number));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            IBrowsable device = new Smartphone();
            foreach (string url in urlTokens)
            {
                try
                {
                    Console.WriteLine(device.Browse(url));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}

/*
0882134215 0882134333 0899213421 0558123 3333123
http://softuni.bg http://youtube.com http://www.g00gle.com
 */
