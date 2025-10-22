namespace _05.SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();
            int rows = dimensions[0], cols = dimensions[1];
            char[,] matrix = new char[rows, cols];

            string word = Console.ReadLine();

            for (int row = 0; row < rows; row++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int col = row % 2 == 0 ? j : cols - (1 + j);
                    matrix[row, col] = word[(row * cols + j) % word.Length];
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
