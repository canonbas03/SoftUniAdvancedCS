﻿namespace OddLines
{
    using System.IO;

    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            var reader = new StreamReader(inputFilePath);
            var writer = new StreamWriter(outputFilePath);

            int lineNum = 0;
            while (true)
            {
                var line = reader.ReadLine();
                if (reader == null)
                {
                    break;
                }

                if(lineNum % 2 == 1)
                {
                    writer.WriteLine(line);
                }
                lineNum++;

            }
        }
    }
}
