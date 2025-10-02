namespace _11.TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int givenNumber = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Func<string, int, bool> sumCheck = (name, n) =>
            {
                int sum = 0;
                foreach (char ch in name)
                {
                    sum += (int)ch;
                }
                return sum >= givenNumber;
            };

            Action<string[], int, Func<string,int, bool>> final = (nameArr, num, check) =>
            {
                foreach (string name in nameArr)
                {
                    if(check(name, num))
                    {
                        Console.WriteLine(name);
                        break;
                    }

                }
            };
            final(names, givenNumber, sumCheck);
        }
    }
}
