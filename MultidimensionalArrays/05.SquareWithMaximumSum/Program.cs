namespace _05.SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDimensions = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = matrixDimensions[0];
            int cols = matrixDimensions[1];

            var matrix = ReadMatrix(rows, cols);
            int maxSum = 0;
            int maxRow = 0;
            int maxCol = 0;
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    int currentSum =
                        matrix[row, col] +
                        matrix[row, col + 1] +
                        matrix[row + 1, col] +
                        matrix[row + 1, col + 1];

                    if (currentSum > maxSum)
                    {
                        maxRow = row;
                        maxCol = col;
                        maxSum = currentSum;
                    }
                }
            }

            Console.WriteLine($"{matrix[maxRow,maxCol]} {matrix[maxRow,maxCol + 1]}");
            Console.WriteLine($"{matrix[maxRow +1,maxCol]} {matrix[maxRow + 1,maxCol + 1]}");
            Console.WriteLine(maxSum);
        }
        static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                int[] values = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = values[j];
                }
            }
            return matrix;
        }
    }
}
