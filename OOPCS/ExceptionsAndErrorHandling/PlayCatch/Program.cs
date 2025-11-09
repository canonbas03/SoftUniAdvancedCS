namespace PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int exceptionCounter = 0;
            while (exceptionCounter < 3)
            {
                try
                {
                    string[] tokens = Console.ReadLine().Split();

                    string command = tokens[0];
                    if (command == "Replace")
                    {
                        int index = int.Parse(tokens[1]);
                        int element = int.Parse(tokens[2]);

                        numbers[index] = element;
                    }
                    else if (command == "Print")
                    {
                        int startIndex = int.Parse(tokens[1]);
                        int endIndex = int.Parse(tokens[2]);

                        List<int> result = new List<int>();
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            result.Add(numbers[i]);
                        }

                        Console.WriteLine(string.Join(", ", result));
                    }
                    else if (command == "Show")
                    {
                        int index = int.Parse(tokens[1]);

                        Console.WriteLine(numbers[index]);
                    }
                }
                catch (FormatException)
                {

                    Console.WriteLine("The variable is not in the correct format!");
                    exceptionCounter++;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptionCounter++;
                }
            }

            Console.WriteLine(string.Join(", ",numbers));
        }
    }
}
/*
1 2 3 4 5
Replace 3 9
Print 1 4
Print -3 12
Print 1 5
Show 3
Show 12,3
 */