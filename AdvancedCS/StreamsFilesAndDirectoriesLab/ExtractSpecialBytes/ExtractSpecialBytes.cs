namespace ExtractSpecialBytes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            HashSet<byte> bytes;
            using (var reader = new StreamReader(bytesFilePath))
            {
                bytes = new HashSet<byte>();
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    bytes.Add(byte.Parse(line));
                }
            }
            byte[] allBytes = File.ReadAllBytes(binaryFilePath).Where(b => bytes.Contains(b)).ToArray();

            File.WriteAllBytes(outputPath, allBytes);
        }
    }
}
