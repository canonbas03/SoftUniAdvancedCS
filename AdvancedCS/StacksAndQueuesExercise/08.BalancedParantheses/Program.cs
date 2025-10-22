namespace _08.BalancedParantheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string parantheses = Console.ReadLine();
            Dictionary<char, char> map = new Dictionary<char, char>
            {
                ['{'] = '}',
                ['['] = ']',
                ['('] = ')'
            };

            if (IsBalanced(parantheses, map)) Console.WriteLine("YES");
            else Console.WriteLine("NO");

        }

        private static bool IsBalanced(string text, Dictionary<char, char> dict)
        {
            Stack<char> stack = new Stack<char>();
            foreach (var ch in text)
            {
                if (dict.ContainsKey(ch)) stack.Push(dict[ch]);
                else if (stack.Count == 0 || stack.Pop() != ch) return false;
            }
            return stack.Count == 0;
        }
    }
}
