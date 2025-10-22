namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            byte[] allBytes = File.ReadAllBytes(sourceFilePath);
            int firstPartLength = (allBytes.Length + 1) / 2;

            byte[] partOne = allBytes.Take(firstPartLength).ToArray();
            byte[] partTwo = allBytes.Skip(firstPartLength).ToArray();

            File.WriteAllBytes(partOneFilePath, partOne);
            File.WriteAllBytes(partTwoFilePath, partTwo);
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            byte[] partOne = File.ReadAllBytes(partOneFilePath);
            byte[] partTwo = File.ReadAllBytes(partTwoFilePath);

            byte[] merged = partOne.Concat(partTwo).ToArray();
            File.WriteAllBytes(joinedFilePath, merged);
        }
    }
}