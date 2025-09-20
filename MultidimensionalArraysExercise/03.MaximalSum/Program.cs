namespace _03.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = dimensions[0], cols = dimensions[1];
            int[][] array = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                int[] values = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                array[i] = values;
            }

            int maxSum = int.MinValue;
            int maxRow = -1;
            int maxCol = -1;
            for (int i = 0; i < rows - 2; i++)
            {
                for (int j = 0; j < cols - 2; j++)
                {
                    int currentSum = SumSubMatrix(array, i, j, 3, 3);
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxRow = i;
                        maxCol = j;
                    }

                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            PrintSubMatrix(array, maxRow, maxCol, 3, 3);
        }

        private static void PrintSubMatrix(int[][] array, int maxRow, int maxCol, int height, int width)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (j > 0) Console.Write(" ");
                    Console.Write(array[i + maxRow][j + maxCol]);
                }
                Console.WriteLine();
            }
        }

        private static int SumSubMatrix(int[][] array, int i, int j, int height, int width)
        {
            int sum = 0;
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    sum += array[row + i][col + j];
                }
            }
            return sum;
        }
    }
}
/*
4 5
1 5 5 2 4
2 1 4 14 3
3 7 11 2 8
4 8 12 16 4
 */