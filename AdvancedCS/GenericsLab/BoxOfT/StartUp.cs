
namespace BoxOfT
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> myBox = new Box<int>();

            myBox.Add(11);
            myBox.Add(22);

            Console.WriteLine(myBox.Count);

            Console.WriteLine(myBox.Remove());
            Console.WriteLine(myBox.Remove());
            Console.WriteLine(myBox.Count);

        }
    }
}
