namespace ListyIterator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split();
            List<string> list = new List<string>(tokens.Skip(1));
            var iterator = new ListyIterator<string>(list);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                Process(input,iterator);
            }
        }

        static void Process<T>(string input, ListyIterator<T> iterator)
        {
            try
            {
                if (input == "Move")
                {
                    bool result = iterator.Move();
                    Console.WriteLine(result);
                }
                else if (input == "HasNext")
                {
                    bool result = iterator.HasNext();
                    Console.WriteLine(result);
                }
                else if (input == "Print")
                {
                    T element = iterator.Print();
                    Console.WriteLine(element);
                }
                else if(input == "PrintAll")
                {
                    foreach (var item in iterator)
                    {
                        Console.Write(item);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
