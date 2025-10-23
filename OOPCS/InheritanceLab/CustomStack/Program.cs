namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings strings = new StackOfStrings();

            Console.WriteLine(strings.IsEmpty());

            Stack<string> values = new Stack<string>();
            values.Push("hello");
            values.Push("there");

            strings.AddRange(values);
        }
    }
}
