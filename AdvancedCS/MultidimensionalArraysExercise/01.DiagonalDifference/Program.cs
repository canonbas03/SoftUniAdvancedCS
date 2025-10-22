namespace _01.DiagonalDifference
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

            int primaryDiagonalSum = 0, secondaryDiagonalSum = 0;
            for (int i = 0; i < size; i++)
            {
                primaryDiagonalSum += matrix[i, i];
                secondaryDiagonalSum += matrix[i, size - i -1];
            }

            int result = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);
            Console.WriteLine(result);

        }
    }
}

/* 
3
11 2 4
4 5 6
10 8 -12
 */
