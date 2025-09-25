namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            string[] filePaths = Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories);

            long totalBytes = 0;
            foreach (var file in filePaths)
            {
                FileInfo info = new FileInfo(file);
                totalBytes += info.Length;
            }

            double totalKb = totalBytes / 1024.0;
            File.WriteAllText(outputFilePath, totalKb + "KB");
        }
    }
}
