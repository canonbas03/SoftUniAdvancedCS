namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> firstScale = new EqualityScale<int>(5,6);
            EqualityScale<double> secondScale = new EqualityScale<double>(5.9,5.9);

            Console.WriteLine(firstScale.AreEqual());
            Console.WriteLine(secondScale.AreEqual());
        }
    }
}
