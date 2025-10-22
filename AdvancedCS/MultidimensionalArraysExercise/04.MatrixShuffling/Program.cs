namespace _04.MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[,] matrix = new string[dimensions[0], dimensions[1]];

            for (int i = 0; i < dimensions[0]; i++)
            {
                string[] values = Console.ReadLine().Split();
                for (int j = 0; j < dimensions[1]; j++)
                {
                    matrix[i, j] = values[j];
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split();
                string command = tokens[0];
                if (command == "swap" && tokens.Length == 5)
                {
                    int fromY = int.Parse(tokens[1]);
                    int fromX = int.Parse(tokens[2]);
                    int toY = int.Parse(tokens[3]);
                    int toX = int.Parse(tokens[4]);

                    if (fromY >= 0 && fromY < matrix.GetLength(0) && fromX >= 0 && fromX < matrix.GetLength(1) &&
                        toY >= 0 && toY < matrix.GetLength(0) && toX >= 0 && toX < matrix.GetLength(1))
                    {
                        string initialValue = matrix[fromY, fromX];
                        string destinationValue = matrix[toY, toX];

                        matrix[fromY, fromX] = destinationValue;
                        matrix[toY, toX] = initialValue;
                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                if (j > 0) Console.Write(" ");
                                Console.Write(matrix[i, j]);
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
