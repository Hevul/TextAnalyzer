using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer
{
    class TextProcessingStage
    {
        public static string ToLowerCase(string text)
        {
            return text.ToLower();
        }

        public static string DeleteNeedlessSymbols(string text, string needlessSymbols)
        {

            string symb;
            foreach (char c in needlessSymbols)
            {
                symb = c.ToString();
                text = text.Replace(symb, " ");
            }
            return text;
        }

        public static string[] TextToWords(string text)
        {
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }

        public static int WordCount(string word, string[] text)
        {
            int count = 0;
            string compare_word;
            for(int i = 0; i < text.Length; i++)
            {
                compare_word = text[i];
                if(word == compare_word)
                {
                    count++;
                }
            }
            return count;
        }

        public static string[] UniqueWordsArray(string[] inText) 
        {
            string[] text = new string[inText.Length];
            inText.CopyTo(text, 0);
            for (int i = 0; i < text.Length; i++)
            {
                for(int j = i + 1; j < text.Length; j++)
                {
                    if (text[i] == text[j])
                    {
                        for (int k = j; k < text.Length - 1; k++)
                        {
                            text[k] = text[k + 1];
                        }
                        Array.Resize(ref text, text.Length - 1);
                        j--;
                    }
                }
            }
            return text;
        }
    }
}
