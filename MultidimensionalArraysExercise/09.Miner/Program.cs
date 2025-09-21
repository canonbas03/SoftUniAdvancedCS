namespace _09.Miner
{
    internal class Program
    {
        public static char Coal = 'c';
        public static char End = 'e';
        public static char Regular = '*';
        public static char Start = 's';
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            char[,] field = new char[size, size];

            int minerRow = 0, minerCol = 0;
            int totalCoals = 0;
            for (int i = 0; i < size; i++)
            {
                char[] line = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int j = 0; j < size; j++)
                {
                    field[i, j] = line[j];

                    if (field[i, j] == Start)
                    {
                        minerRow = i; minerCol = j;
                    }
                    else if (field[i, j] == Coal)
                    {
                        totalCoals++;
                    }
                }
            }

            int row = minerRow, col = minerCol;
            Dictionary<string, (int, int)> moves = new Dictionary<string, (int, int)>
            {
                {"up",(-1,0) },
                {"down",(1,0) },
                {"right",(0,1) },
                {"left",(0,-1) }
            };
            int collectedCoals = 0;
            foreach (string command in commands)
            {
                var (rowChange, colChange) = moves[command];
                int nextRow = minerRow + rowChange;
                int nextCol = minerCol + colChange;

                if (nextRow < 0 || nextRow >= size || nextCol < 0 || nextCol >= size)
                {
                    continue;
                }

                field[minerRow, minerCol] = Regular;
                minerRow = nextRow; minerCol = nextCol;
                if (field[minerRow, minerCol] == Coal)
                {
                    collectedCoals++;
                    if (collectedCoals == totalCoals)
                    {
                        break;
                    }
                }
                else if (field[minerRow, minerCol] == End)
                    break;
            }
            if (field[minerRow,minerCol] == End)
            {
                Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
            }
            else if (totalCoals == collectedCoals)
            {
                Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
            }
            else
            {
                Console.WriteLine($"{totalCoals-collectedCoals} coals left. ({minerRow}, {minerCol})");
            }
        }
    }
}
/*
4
up right right right down
* * * e
* * c *
* s * c
* * * *
 */
