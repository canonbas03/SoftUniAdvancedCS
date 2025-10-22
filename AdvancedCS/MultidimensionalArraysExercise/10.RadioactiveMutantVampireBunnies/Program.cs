namespace _10.RadioactiveMutantVampireBunnies
{
    internal class Program
    {
        public static char Bunny = 'B';
        public static char BunnyPlaceholder = 'A';
        public static char Player = 'P';
        public static char Empty = '.';

        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            char[,] lair = new char[dimensions[0], dimensions[1]];

            int playerRow = -1, playerCol = -1;

            // Fill lair and find player
            for (int i = 0; i < lair.GetLength(0); i++)
            {
                char[] values = Console.ReadLine().ToCharArray();
                for (int j = 0; j < lair.GetLength(1); j++)
                {
                    lair[i, j] = values[j];
                    if (lair[i, j] == Player)
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }

            char[] directions = Console.ReadLine().ToCharArray();
            Dictionary<char, (int, int)> moves = new Dictionary<char, (int, int)>
            {
                {'U',(-1, 0)},
                {'D',( 1, 0)},
                {'L',( 0,-1)},
                {'R',( 0, 1)}
            };

            bool isDead = false;
            bool hasWon = false;
            int lastRow = playerRow, lastCol = playerCol;

            foreach (var dir in directions)
            {
                // Step 1: player moves
                int newRow = playerRow + moves[dir].Item1;
                int newCol = playerCol + moves[dir].Item2;

                lair[playerRow, playerCol] = Empty; // leave old position

                if (newRow < 0 || newRow >= lair.GetLength(0) ||
                    newCol < 0 || newCol >= lair.GetLength(1))
                {
                    hasWon = true;
                    lastRow = playerRow;
                    lastCol = playerCol;
                }
                else if (lair[newRow, newCol] == Bunny)
                {
                    isDead = true;
                    lastRow = newRow;
                    lastCol = newCol;
                }
                else
                {
                    lair[newRow, newCol] = Player;
                    playerRow = newRow;
                    playerCol = newCol;
                    lastRow = newRow;
                    lastCol = newCol;
                }

                // Step 2: spread bunnies
                for (int i = 0; i < lair.GetLength(0); i++)
                {
                    for (int j = 0; j < lair.GetLength(1); j++)
                    {
                        if (lair[i, j] == Bunny)
                            MultiplyBunny(lair, i, j);
                    }
                }

                // Step 3: finalize bunny spread
                for (int i = 0; i < lair.GetLength(0); i++)
                {
                    for (int j = 0; j < lair.GetLength(1); j++)
                    {
                        if (lair[i, j] == BunnyPlaceholder)
                            lair[i, j] = Bunny;
                    }
                }

                // Step 4: check if bunnies killed player
                if (!hasWon && !isDead && lair[playerRow, playerCol] == Bunny)
                {
                    isDead = true;
                    lastRow = playerRow;
                    lastCol = playerCol;
                }

                if (isDead || hasWon)
                    break;
            }

            // Print final lair
            for (int i = 0; i < lair.GetLength(0); i++)
            {
                for (int j = 0; j < lair.GetLength(1); j++)
                {
                    Console.Write(lair[i, j]);
                }
                Console.WriteLine();
            }

            if (hasWon)
                Console.WriteLine($"won: {lastRow} {lastCol}");
            else if (isDead)
                Console.WriteLine($"dead: {lastRow} {lastCol}");
        }

        private static void MultiplyBunny(char[,] lair, int row, int col)
        {
            int[,] directions = new int[,]
            {
                {-1, 0}, // up
                { 1, 0}, // down
                { 0,-1}, // left
                { 0, 1}  // right
            };

            for (int d = 0; d < 4; d++)
            {
                int newRow = row + directions[d, 0];
                int newCol = col + directions[d, 1];

                if (newRow >= 0 && newRow < lair.GetLength(0) &&
                    newCol >= 0 && newCol < lair.GetLength(1))
                {
                    if (lair[newRow, newCol] != Bunny)
                        lair[newRow, newCol] = BunnyPlaceholder;
                }
            }
        }
    }
}


/*
5 8
.......B
...B....
....B..B
........
..P.....
ULLL

4 5
.....
.....
.B...
...P.
LLLLLLLL
 */