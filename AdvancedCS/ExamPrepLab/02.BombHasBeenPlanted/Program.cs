namespace _02.BombHasBeenPlanted
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] coordinates = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = coordinates[0];
            int cols = coordinates[1];

            char[,] map = new char[rows, cols];

            int ctStartRow = -1;
            int ctStartCol = -1;
            int bombRow = -1;
            int bombCol = -1;
            for (int row = 0; row < rows; row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < cols;  col++)
                {
                    map[row,col] = rowData[col];

                    if (rowData[col] == 'C')
                    {
                        ctStartRow = row;
                        ctStartCol = col;
                    }
                    else if (rowData[col] == 'B')
                    {
                        bombRow = row;
                        bombCol = col;
                    }
                }
            }
            PlayGame(ctStartRow,ctStartCol,bombRow,bombCol,map);
            PrintMap(map);
        }

        static void PlayGame(int ctRow, int ctCol, int bombRow, int bombCol, char[,] map)
        {
            int seconds = 16;
            bool isDead = false;
            bool isDefused = false;

            while(seconds > 0)
            {
                int prevRow = ctRow;
                int prevCol = ctCol;
                string command = Console.ReadLine();
                seconds--;
                switch (command)
                {
                    case "up":ctRow--; break;
                    case "down":ctRow++; break;
                    case "left":ctCol--; break;
                    case "right": ctCol++; break;
                    case "defuse":
                        if (map[ctRow,ctCol] == 'B')
                        {
                            seconds -= 3;
                            if(seconds >= 0)
                            {
                                map[ctRow, ctCol] = 'D';
                                isDefused = true;
                            }
                        }
                        else
                        {
                            seconds--;
                        }
                        break;
                }

                if((ctRow < 0 || ctRow >= map.GetLength(0) ) || ctCol < 0 ||ctCol >= map.GetLength(1))
                {
                    ctRow = prevRow;
                    ctCol = prevCol;
                }

                if (map[ctRow,ctCol] == 'T')
                {
                    map[ctRow, ctCol] = '*';
                    isDead = true;
                }
                if(isDefused || isDead) break;
            }

            if(isDead)
            {
                Console.WriteLine("Terrorists win!");
            }
            else if(isDefused)
            {
                Console.WriteLine("Counter-terrorist wins!");
                Console.WriteLine($"Bomb has been defused: {seconds} second/s remaining.");
            }
            else
            {
                if(seconds < 0)
                {
                    map[bombRow, bombCol] = 'X';
                }
                Console.WriteLine("Terrorists win!");
                Console.WriteLine("Bomb was not defused successfully!");
                Console.WriteLine($"Time needed: {Math.Abs(seconds)} second/s.");
            }
        }
        static void PrintMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}

/*
5, 7
*****T*
****T**
**B****
***T**T
C*****T
up
up
down
right
right
up
up
defuse
down
defuse
 */
