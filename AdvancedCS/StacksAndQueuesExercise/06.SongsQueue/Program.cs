namespace _06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = ReadSongs();
            while (songs.Count > 0)
            {
                string command = Console.ReadLine();
                if (command == "Play") songs.Dequeue();
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
                else if (command.StartsWith("Add "))
                {
                    string currentSong = command.Substring(4);
                    if(songs.Contains(currentSong))
                    {
                        Console.WriteLine($"{currentSong} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(currentSong);
                    }
                }
            }
            Console.WriteLine("No more songs!");
        }
        static Queue<string> ReadSongs()
        {
            IEnumerable<string> sequence = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            return new Queue<string>(sequence);
        }
    }
}
