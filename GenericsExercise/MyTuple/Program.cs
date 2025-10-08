namespace MyTuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var tuple1 = new CustomTuple<string, string>($"{tokens[0]} {tokens[1]}", tokens[2]);
            Console.WriteLine(tuple1);

            tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var tuple2 = new CustomTuple<string, int>(tokens[0], int.Parse(tokens[1]));
            Console.WriteLine(tuple2);

            tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var tuple3 = new CustomTuple<int, double>(int.Parse(tokens[0]), double.Parse(tokens[1]));
            Console.WriteLine(tuple3);
        }
    }
}
