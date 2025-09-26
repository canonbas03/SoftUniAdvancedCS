namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            var directory = new DirectoryInfo(inputFolderPath);
            var filesByExtension = new Dictionary<string, List<FileInfo>>();
            foreach (FileInfo file in directory.GetFiles())
            {
                if (!filesByExtension.ContainsKey(file.Extension))
                {
                    filesByExtension[file.Extension] = new List<FileInfo>();
                }
                filesByExtension[file.Extension].Add(file);
            }

            StringBuilder sb = new StringBuilder();
            foreach ((string extension, List<FileInfo> files) in filesByExtension.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                sb.AppendLine(extension);
                foreach (FileInfo file in files.OrderBy(x => x.Length))
                {
                    2sb.AppendLine($"--{file.Name} - {file.Length / 1024m}kb");
                }
            }
            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string destination = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);
            File.WriteAllText(Path.Combine(destination, reportFileName), textContent);
        }
    }
}
