namespace _09.SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string text = string.Empty;
            Stack<string> history = new Stack<string>();
            history.Push("");

            for (int i = 0; i < count; i++)
            {
                string[] arguments = Console.ReadLine().Split();
                string command = arguments[0];

                if (command == "1")
                {
                    history.Push(text);
                    string value = arguments[1];
                    text += value;
                }
                else if (command == "2")
                {
                    int value = int.Parse(arguments[1]);
                    if (text.Count() >= value)
                    {
                        history.Push(text);
                        text = text.Substring(0, text.Count() - value);
                    }
                }
                else if (command == "3")
                {
                    int value = int.Parse(arguments[1])-1;
                    Console.WriteLine(text[value]);
                }
                else if(command == "4")
                {
                    if(history.Count > 0)
                    {
                       

                        text = history.Pop();
                        //Console.WriteLine(text);
                    }
                }

            }

        }
    }
}
