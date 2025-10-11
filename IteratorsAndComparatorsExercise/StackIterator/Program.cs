namespace StackIterator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                ProcessCommand(input, stack);
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (int el in stack)
                {
                    Console.WriteLine(el);
                }
            }
        }

        static void ProcessCommand(string input, Stack<int> stack)
        {
            try
            {
                if (input == "Pop")
                {
                    stack.Pop();
                }
                else if (input.StartsWith("Push"))
                {
                    IEnumerable<int> numbers = input.Substring(5).Split(", ").Select(int.Parse);

                    foreach (int number in numbers)
                    {
                        stack.Push(number);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
