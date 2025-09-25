namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);

            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = FormatLine(lines[i], i);
            }
            File.WriteAllLines(outputFilePath, lines);
        }

        private static string FormatLine(string line, int index)
        {
            int letterCount = line.Where(x => char.IsLetter(x)).Count();
            int punctCount = line.Where(x => char.IsPunctuation(x)).Count();
            return $"Line {index + 1}: {line} ({letterCount})({punctCount})";
        }
    }
}
