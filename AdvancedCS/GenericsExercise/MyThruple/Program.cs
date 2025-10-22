namespace MyThruple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            ProcessFirstLine(tokens);

            tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            ProcessSecondLine(tokens);

            tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            ProcessThirdLine(tokens);
        }
        static void ProcessFirstLine(string[] arr)
        {
            string fullName = $"{arr[0]} {arr[1]}";
            string address = arr[2];
            string town = string.Join(" ", arr.Skip(3));

            var thruple = new CustomThruple<string, string, string>(fullName, address, town);
            Console.WriteLine(thruple);
        }

        private static void ProcessSecondLine(string[] tokens)
        {
            string name = tokens[0];
            int liters = int.Parse(tokens[1]);
            bool isDrunk = tokens[2] == "drunk";

            var thruple = new CustomThruple<string, int, bool>(name, liters, isDrunk);
            Console.WriteLine(thruple);
        }

        static void ProcessThirdLine(string[] arr)
        {
            string name = arr[0];
            double balance = double.Parse(arr[1]);
            string bankName = arr[2];

            var thruple = new CustomThruple<string, double, string>(name, balance, bankName);
            Console.WriteLine(thruple);
        }
    }
}
/*
Adam Smith Wallstreet New York
Mark 18 drunk
Karren 0,10 USBank
 */
