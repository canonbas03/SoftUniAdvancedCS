namespace _02.EscapeTheMaze
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const char Player = 'P';
            const char Exit = 'X';
            const char Monster = 'M';
            const char HealthPotion = 'H';
            const char Empty = '-';

            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n,n];

            int playerRow = -1, playerCol = -1;
            for (int i = 0; i < n; i++)
            {
                string data = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = data[j];

                    if (data[j] ==  Player)
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }

            int health = 100;
            bool isExit = false;
            bool isDead = false;
            while(!isExit && !isDead)
            {
                int nextRow = playerRow;
                int nextCol = playerCol;
                string command = Console.ReadLine();
                if (command == "up") nextRow--;
                else if (command == "down") nextRow++;
                else if (command == "right") nextCol++;
                else if(command == "left") nextCol--;

                if (nextRow < 0 || nextRow >= n || nextCol < 0 || nextCol >= n)
                    continue;

                if (matrix[nextRow,nextCol] == Monster)
                {
                    health = Math.Max(0, health - 40);
                    if(health == 0) isDead = true;
                }
                else if (matrix[nextRow,nextCol] == HealthPotion)
                {
                    health = Math.Min(100, health += 15);
                }
                else if (matrix[nextRow,nextCol] == Exit)
                {
                    isExit = true;
                }

                matrix[playerRow, playerCol] = Empty;
                playerRow = nextRow;
                playerCol = nextCol;

                matrix[playerRow, playerCol] = Player;
            }

            if(isDead)
            {
                Console.WriteLine("Player is dead. Maze over!");
            }
            else
            {
                Console.WriteLine("Player escaped the maze. Danger passed!");
            }

            Console.WriteLine($"Player's health: {health} units");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}

/*
5
-----
-PM--
-M---
---H-
-X---
down
right
down
down
left

8
--H-----
---P---X
--------
--M--M--
--H--M--
H-----M-
--------
------H-
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