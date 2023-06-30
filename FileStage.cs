using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer
{
    class FileStage
    {
        public static string FileReader(string path)
        {
            string line = "";
            try
            {
                StreamReader sr = new StreamReader(path);
                line = sr.ReadToEnd();
                sr.Close();
            } catch {
                Console.WriteLine("FileStage:\nError: File is not found.");
            }
            return line;
        }
    }
}
