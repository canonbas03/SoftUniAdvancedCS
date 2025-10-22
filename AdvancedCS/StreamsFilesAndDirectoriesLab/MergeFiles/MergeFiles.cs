namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (var read = new StreamReader(firstInputFilePath))
            {
                using (var readSecond = new StreamReader(secondInputFilePath))
                {
                    using (var write = new StreamWriter(outputFilePath))
                    {
                        while (!read.EndOfStream || !readSecond.EndOfStream)
                        {
                            if (!read.EndOfStream)
                            {
                                var lineOne = read.ReadLine();
                                write.WriteLine(lineOne);
                            }
                            if (!readSecond.EndOfStream)
                            {
                                var lineTwo = readSecond.ReadLine();
                                write.WriteLine(lineTwo);
                            }
                        }
                    }
                }
            }
        }
    }
}
