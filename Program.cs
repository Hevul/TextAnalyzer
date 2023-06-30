using System;
using System.IO;

namespace TextAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "D:\\СSharpCode\\TextAnalyzer\\Texts\\grob_text.txt";
            string line;
            line = FileStage.FileReader(path);
            Console.WriteLine(line + "\n\n\n");

            string unwantedSymbs = "—.!?,-:;()*\"\\/|–«»=+@#¹$%^&~\n\r\b\t\v\f\a";
            line = TextProcessingStage.ToLowerCase(line);
            line = TextProcessingStage.DeleteNeedlessSymbols(line, unwantedSymbs);
            string[] words = TextProcessingStage.TextToWords(line);

            string[] uniqueWords = TextProcessingStage.UniqueWordsArray(words);
            foreach (string word in uniqueWords)
            {
                Console.Write(word + " ");
            }

            Console.WriteLine("\n\n");

            Map map = new Map();
            map.Fill(uniqueWords, words);
            map.Print();
        }

    }
}