namespace _03.PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            var matrix = ReadMatrix(size, size);

            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum += matrix[i,i];
            }
            Console.WriteLine(sum);
        }
        static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                int[] values = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = values[j];
                }
            }
            return matrix;
        }
    }
}
