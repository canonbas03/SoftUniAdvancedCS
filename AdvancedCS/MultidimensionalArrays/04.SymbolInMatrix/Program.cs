namespace _04.SymbolInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            var matrix = ReadMatrix(size, size);

            char symbol = char.Parse(Console.ReadLine());
            int row = 0;
            int col = 0;
            bool isFound = false;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] == symbol)
                    {
                        isFound = true;
                        row = i; col = j; break;
                    }
                }
                if (isFound) break;
            }
            if (isFound)
            {
                Console.WriteLine($"({row}, {col})");
            }
            else
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }

        static char[,] ReadMatrix(int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                string values = Console.ReadLine();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = values[j];
                }
            }
            return matrix;
        }
    }
}
