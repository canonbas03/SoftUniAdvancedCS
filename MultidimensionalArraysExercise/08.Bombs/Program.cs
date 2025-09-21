

namespace _08.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                int[] values = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = values[j];
                }
            }
            var coordinates = Console.ReadLine().Split();
            for (int i = 0; i < coordinates.Length; i++)
            {
                int[] values = coordinates[i].Split(",").Select(int.Parse).ToArray();
                int row = values[0], col = values[1];
                BombExplosion(row, col, matrix);

            }
                PrintMatrix(matrix);
        }

       

        private static void BombExplosion(int row, int col, int[,] matrix)
        {
           int bombValue = matrix[row, col];
            for (int i = 0;i < 3;i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if(i + (row - 1) >= 0 && i + (row - 1) < matrix.GetLength(0) && j + (col - 1) >= 0 && j + (col - 1) < matrix.GetLength(1))
                    {
                        if(matrix[i + (row - 1), j + (col - 1)] > 0)
                        matrix[i + (row -1),j + (col -1)] -= bombValue;
                    }
                }
            }
        }
        private static void PrintMatrix(int[,] matrix)
        {
            int aliveCells = 0, sum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] > 0)
                    {
                        aliveCells++;
                        sum += matrix[i,j];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(j > 0) Console.Write(" ");
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}

/*
4
8 3 2 5
6 4 7 9
9 9 3 6
6 8 1 2
1,2 2,1 2,0
 */