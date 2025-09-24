namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            var wordsByCount = new Dictionary<string, int>();

            using (var reader = new StreamReader(wordsFilePath))
            {
                string[] words = reader.ReadLine().ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(w => w.ToLower()).ToArray();
                foreach (string word in words)
                {
                    if (!wordsByCount.ContainsKey(word))
                    {
                        wordsByCount[word] = 0;
                    }
                }
            }

            using (var reader = new StreamReader(textFilePath))
            {
                string[] text = reader.ReadToEnd()
                                      .ToLower()
                                      .Split(new char[] { ' ', '-', '.', '!', ',', '?', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in text)
                {
                    if (wordsByCount.ContainsKey(word))
                    {
                        wordsByCount[word]++;
                    }
                }

            }
            using (var writer = new StreamWriter(outputFilePath))
                foreach (var (word, amount) in wordsByCount.OrderByDescending(wc => wc.Value))
                {
                    writer.WriteLine($"{word} - {amount}");
                }
        }
    }
}
