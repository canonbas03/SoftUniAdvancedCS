namespace _07.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            long[][] pascalTriangle = new long[size][];

            pascalTriangle[0] = new long[] { 1 };
            if (size > 1)
            {
                pascalTriangle[1] = new long[] { 1, 1 };

                for (int row = 2; row < size; row++)
                {
                    pascalTriangle[row] = new long[row + 1];
                    pascalTriangle[row][0] = 1;
                    pascalTriangle[row][row] = 1;

                    for (int col = 1; col < row ; col++)
                    {
                        long value = pascalTriangle[row - 1][col - 1] +
                                     pascalTriangle[row - 1][col];

                        pascalTriangle[row][col] = value;
                    }
                }
            }

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(string.Join(" ", pascalTriangle[i]));
            }

        }
    }
}
