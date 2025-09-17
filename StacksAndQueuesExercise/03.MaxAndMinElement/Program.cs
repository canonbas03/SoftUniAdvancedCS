namespace _03.MaxAndMinElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int operationsCount = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            List<int> list = new List<int>();
            if (operationsCount <= 105 && operationsCount >= 1)
            {
                for (int i = 0; i < operationsCount; i++)
                {
                    int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
                    int initial = parameters[0];
                    if (initial >= 1 && initial <= 4)
                    {
                        switch (initial)
                        {
                            case 1:

                                if (parameters[1] >= 1 && parameters[1] <= 109)
                                    stack.Push(parameters[1]);
                                break;
                            case 2:
                                stack.Pop();
                                break;
                            case 3:
                                if (stack.Count > 0)
                                {
                                    int max = int.MinValue;
                                    foreach (var item in stack)
                                    {
                                        if (item > max) max = item;
                                    }
                                    Console.WriteLine(max);
                                }
                                break;
                            case 4:
                                if (stack.Count > 0)
                                {
                                    int min = int.MaxValue;
                                    foreach (var item in stack)
                                    {
                                        if (item < min) min = item;
                                    }
                                    Console.WriteLine(min);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
                while (stack.Count > 0)
                {
                    list.Add(stack.Pop());
                }
                Console.WriteLine(string.Join(", ", list));
            }

        }
    }
}

