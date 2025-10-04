namespace _05.DateModifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(DateModifier.DaysBetweenDates("19 05 31", "2016 06 17")); 
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();

            Console.WriteLine(DateModifier.DaysBetweenDates(date1, date2));
        }
    }
}
