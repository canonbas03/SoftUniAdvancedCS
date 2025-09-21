using System.Drawing;
using System.Runtime.CompilerServices;

namespace _07.KnightGame
{
    internal class Program
    {
        public static char Knight = 'K';
        public static char Empty = '0';

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[][] board = new char[size][];
            for (int i = 0; i < size; i++)
            {
                string input = Console.ReadLine();
                board[i] = new char[size];
                for (int j = 0; j < size; j++)
                {
                    board[i][j] = input[j];
                }
            }
            // while there are no conflicts
            int result = 0;
            while (ResolveConflicts(board)) result++;
            Console.WriteLine(result);

        }
        static bool ResolveConflicts(char[][] board)
        {
            int maxConflicts = 0, maxRow = 0, maxCol = 0;
            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board[row].Length; col++)
                {
                    if (board[row][col] != Knight) continue;
                    // look how many conflicts it has
                    int currentConflicts = CountConflicts(board, row, col);
                    if(currentConflicts > maxConflicts)
                    {
                        maxConflicts = currentConflicts;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }
            if(maxConflicts == 0) return false;
            board[maxRow][maxCol] = Empty;
            return true;
        }

        static int CountConflicts(char[][] board, int row, int col)
        {
            // returns the total conflicts with methods
            return CheckForConflicts(board, row - 2, col - 1) + CheckForConflicts(board, row - 2, col + 1)
                + CheckForConflicts(board, row + 2, col - 1) + CheckForConflicts(board, row + 2, col + 1)
                + CheckForConflicts(board, row - 1, col - 2) + CheckForConflicts(board, row + 1, col - 2)
                + CheckForConflicts(board, row - 1, col + 2) + CheckForConflicts(board, row + 1, col + 2);
        }

        static int CheckForConflicts(char[][] board, int row, int col)
        {
            if (row >= 0 && row < board.Length && col >= 0 && col < board[row].Length && board[row][col] == Knight) return 1;

            return 0;
        }
    }
}
/*
5
0K0K0
K000K
00K00
K000K
0K0K0
 */