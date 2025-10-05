namespace CustomListClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomList customList = new CustomList();
            customList.Add(2);
            customList.Add(8);
            Console.WriteLine(customList[0]);

            //for (int i = 0; i < 5; i++)
            //{
            //    customList.Add(i);
            //    Console.WriteLine(customList[i]);
            //}
            //customList.RemoveAt(2);
            //for (int i = 0; i < 4; i++)
            //{
            //    Console.WriteLine(customList[i]);

            //}

            
        }
    }
}
