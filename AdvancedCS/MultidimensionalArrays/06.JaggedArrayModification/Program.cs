
namespace _06.JaggedArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                int[] values = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jaggedArray[i] = values;
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split();
                string command = tokens[0];
                int row = int.Parse(tokens[1]), col = int.Parse(tokens[2]), value = int.Parse(tokens[3]);
                if (command == "Add")
                {
                    if (ValidCoordinate(jaggedArray, row, col))
                    {
                        jaggedArray[row][col] += value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                else
                {
                    if (ValidCoordinate(jaggedArray, row, col))
                    {
                        jaggedArray[row][col] -= value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
            }
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(string.Join(" ", jaggedArray[i]));
            }
        }

        private static bool ValidCoordinate(int[][] array, int row, int col)
        {

            if (row < 0 || row >= array.Length)
            {
                return false;
            }
            if (col < 0 || col >= array[row].Length)
            {
                return false;
            }
            return true;

        }
    }
}
// 1 2 3
// 1 2
// 1 2 3 4 5