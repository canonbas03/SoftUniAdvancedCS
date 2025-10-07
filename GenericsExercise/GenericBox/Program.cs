﻿namespace GenericBox
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();
                var box = new Box<string>(text);
                Console.WriteLine(box);
            }
        }
    }
}
