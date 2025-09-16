namespace _03.SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] expression = Console.ReadLine().Split().Reverse().ToArray();
            Stack<string> stack = new Stack<string>(expression);
            bool isAdd = true;
            int total = 0;
            while (stack.Count > 0)
            {
                string currentToken = stack.Pop();
                if (currentToken == "+")
                {
                    isAdd = true;
                }
                else if (currentToken == "-")
                {
                    isAdd = false;
                }
                else
                {
                    int number = int.Parse(currentToken);
                    if(!isAdd)
                    {
                        number *= -1;
                    }
                    total += number;
                }
            }
            Console.WriteLine(total);
        }
    }
}
