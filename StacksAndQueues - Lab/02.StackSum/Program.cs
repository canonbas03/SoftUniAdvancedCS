namespace _02.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> numberStack = new Stack<int>(numbers);

            string input;
            while((input=Console.ReadLine().ToLower()) != "end")
            {
                string[] tokens = input.Split();
                switch (tokens[0])
                {
                    case "add":
                        int num1 = int.Parse(tokens[1]);
                        int num2 = int.Parse(tokens[2]);
                        numberStack.Push(num1);
                        numberStack.Push(num2);
                        break;
                    case "remove":
                        int removeCount = int.Parse(tokens[1]);
                        if(numberStack.Count >= removeCount)
                        {
                            for (int i = 0; i < removeCount; i++)
                            {
                                numberStack.Pop();
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            int total = default;
            foreach (int num in numberStack)
            {
                total+= num;
            }
            Console.WriteLine($"Sum: {total}");
        }
    }
}
