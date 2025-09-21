namespace _06.JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int[] values = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                jaggedArray[i] = values;
            }

            for (int i = 0; i < jaggedArray.Length - 1; i++)
            {
                if (jaggedArray[i].Length == jaggedArray[i + 1].Length)
                {
                    for (int j = 0; j < jaggedArray[i].Length; j++)
                    {
                        jaggedArray[i][j] *= 2;
                        jaggedArray[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < jaggedArray[i].Length; j++)
                    {
                        jaggedArray[i][j] /= 2;
                    }
                    for (int j = 0; j < jaggedArray[i + 1].Length; j++)
                    {
                        jaggedArray[i + 1][j] /= 2;
                    }
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();
                string command = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int val = int.Parse(tokens[3]);
                if (command == "Add")
                {
                    if (IndexValidator(jaggedArray, row, col))
                    {
                        jaggedArray[row][col] += val;
                    }
                }
                else if (command == "Subtract")
                {
                    if (IndexValidator(jaggedArray, row, col))
                    {
                        jaggedArray[row][col] -= val;
                    }
                }
            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine(string.Join(" ", jaggedArray[i]));
            }

            static bool IndexValidator(int[][] array, int row, int col)
            {
                int arrayRowLength = array.GetLength(0);
                int arrayColLength = -1;
                if (row <= arrayRowLength && row >= 0)
                {
                    arrayColLength = array[row].Length;
                }
                if (arrayColLength != -1 && col < arrayColLength && col >= 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}

/*
5
10 20 30
1 2 3
2
2
10 10
Add 0 10 10
Add 0 0 10
Subtract -3 0 10
Subtract 3 0 10
End
 */