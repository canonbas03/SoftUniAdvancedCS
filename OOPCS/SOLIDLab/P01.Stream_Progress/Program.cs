using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {   
            var stream = new StreamProgressInfo(new Music("","",100,5));
            Console.WriteLine(stream.CalculateCurrentPercent());
        }
    }
}
