namespace _02.Fortress
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const char Spy = 'S';
            const char Exit = 'E';
            const char Guard = 'G';
            const char Blind = 'B';
            const char Corridor = '.';
            int n = int.Parse(Console.ReadLine());
            char[,] map = new char[n, n];

            int startRow = -1, startCol = -1;
            for (int i = 0; i < n; i++)
            {
                string rowData = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    map[i, j] = rowData[j];

                    if (rowData[j] == Spy)
                    {
                        startRow = i;
                        startCol = j;
                    }
                }
            }

            int stealth = 100;
            bool isCought = false, isExit = false;
            while (!isCought && !isExit)
            {
                int prevRow = startRow;
                int prevCol = startCol;

                string command = Console.ReadLine();
                if (command == "up") startRow--;
                else if (command == "down") startRow++;
                else if (command == "right") startCol++;
                else if (command == "left") startCol--;

                if (startRow < 0 || startRow >= n || startCol < 0 || startCol >= n)
                {
                    startRow = prevRow;
                    startCol = prevCol;
                    continue;
                }
                map[prevRow, prevCol] = Corridor;

                if (map[startRow, startCol] == Guard)
                {
                    stealth -= 40;
                    if (stealth <= 0)
                    {

                        isCought = true;
                        map[startRow, startCol] = Spy;
                        break;
                    }

                }

                else if (map[startRow, startCol] == Blind)
                {

                    stealth = Math.Min(100, stealth + 15);
                    map[startRow, startCol] = Spy;

                }

                else if (map[startRow, startCol] == Exit)
                {

                    isExit = true;
                    break;
                }

                if (isCought || isExit)
                    break;
            }

            if (isCought)
            {
                Console.WriteLine("Mission failed. Spy compromised.");
            }
            else if (isExit)
            {
                Console.WriteLine("Mission accomplished. Spy extracted successfully.");
            }

            Console.WriteLine($"Stealth level: {stealth} units");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}

/*
5
...G.
.SG..
.G...
..GB.
.E.B.
down
right
down
down
left

14
..............
.G..GB........
..............
..............
.....G...BG...
...S..........
.......B......
..............
....GB...BG...
..............
.G............
.......E......
..............
..............
up
right
right
right
right
right
right
right
down
left
down
down
down
right
down
down
down
left
left
left
left
left
left

8
..B.....
...S...E
........
..G..G..
..B..G..
B.....G.
........
......B.
down
right
right
down
down
right
down
left
up
up
 */
