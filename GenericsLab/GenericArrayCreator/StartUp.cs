namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] myArray = ArrayCreator.Create(5, 111);


            foreach (int el in myArray)
            {
                Console.WriteLine(el);
            }
        }
    }
}
