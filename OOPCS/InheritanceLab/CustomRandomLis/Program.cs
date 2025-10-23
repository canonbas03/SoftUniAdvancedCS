namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList randomList = new RandomList()
            {
                "House", "Wow", "Meow"
            };

            Console.WriteLine(randomList.RandomString());
            Console.WriteLine(randomList.Count);
        }
    }
}
