namespace _04.MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    stack.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int openBracketIndex = stack.Pop();
                    Console.WriteLine(expression.Substring(openBracketIndex,i - openBracketIndex + 1));
                }
            }
        }
    }
}
