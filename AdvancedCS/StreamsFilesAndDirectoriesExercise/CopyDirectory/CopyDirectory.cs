namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath =  Console.ReadLine();
            string outputPath = Console.ReadLine();

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            DirectoryInfo outputDirectory = new DirectoryInfo(outputPath);
            if(outputDirectory.Exists) outputDirectory.Delete(true);
            outputDirectory.Create();

            DirectoryInfo inputDirectory = new DirectoryInfo(inputPath);
            foreach (FileInfo file in inputDirectory.GetFiles())
            {
                string destinationFilePath = Path.Combine(outputDirectory.FullName, file.Name);
                file.CopyTo(destinationFilePath);
            }
        }
    }
}
