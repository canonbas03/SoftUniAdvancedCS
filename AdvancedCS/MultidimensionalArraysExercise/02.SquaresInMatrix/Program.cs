namespace _02.SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0], cols = dimensions[1];
            char[,] matrix = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                char[] values = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i,j] = values[j];
                }
            }

            int counter = 0;
            for (int i = 0; i < rows -1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    char c = matrix[i,j];
                    if (c == matrix[i,j +1] && c == matrix[i +1, j] && c == matrix[i+1,j+1])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
