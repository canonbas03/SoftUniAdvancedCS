namespace AuthorProblem
{
    [Author("Dzhan")]
    public class StartUp
    {
        [Author("Dzhan")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}
