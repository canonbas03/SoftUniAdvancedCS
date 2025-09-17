namespace _01.BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = parameters[0], s = parameters[1], x = parameters[2];
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                stack.Push(numbers[i]);
            }
            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }

            if(stack.Count == 2) Console.WriteLine(0);
            else
            {
                int minNumber = int.MaxValue;
                bool found = false;
                foreach (var num in stack)
                {
                    if(num == x)
                    {
                        found = true; 
                        break;
                    }
                    if(num < minNumber) minNumber = num;
                }
                if(found) Console.WriteLine("true");
                else Console.WriteLine(minNumber);
            }
        }
    }
}
