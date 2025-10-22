namespace EvenLines
{
    using System;
    using System.IO;
    using System.Text;

    public class EvenLines
    {
        private static char[] CharsToReplace = ['-', ',', '.', '!', '?'];
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using var reader = new StreamReader(inputFilePath);

            bool isEven = true;
            var sb = new StringBuilder();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (isEven)
                {
                    string formatted = FormatLine(line);
                    sb.AppendLine(formatted);
                }
                isEven = !isEven;
            }
            return sb.ToString();
        }

        private static string FormatLine(string line)
        {
            string[] words = line.Split();
            Array.Reverse(words);
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < CharsToReplace.Length; j++)
                {
                    words[i] = words[i].Replace(CharsToReplace[j], '@');
                }
            }
            return string.Join(" ", words);
        }
    }
}
