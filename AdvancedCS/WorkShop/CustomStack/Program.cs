namespace CustomStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyStack stack = new MyStack();

            stack.Push(1);
            stack.Push(2);

            foreach(int el in stack.ToArray())
            {
                Console.WriteLine(el);
            }
        }
    }
}
