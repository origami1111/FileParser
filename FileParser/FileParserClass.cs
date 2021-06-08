using System;
using System.IO;
using System.Text.RegularExpressions;

namespace FileParser
{
    public class FileParserClass
    {
        private const string filePathReplaced = "TEXT_replaced.txt";
        private string filePathSource;
        private string searchStr;
        private string replacementStr;

        public FileParserClass(string filePathSource, string strCounting)
        {
            this.filePathSource = filePathSource;
            this.searchStr = strCounting;
        }
        public FileParserClass(string filePathSource, string searchStr, string replacementStr)
        {
            this.filePathSource = filePathSource;
            this.searchStr = searchStr;
            this.replacementStr = replacementStr;
        }
        public int QuantityStr()
        {
            int quantity = 0;
            string line;
            char[] separators = new char[] { ' ', '.', ',', '?', '!', '\n' };

            using (StreamReader readFile = new StreamReader(filePathSource))
            {
                while ((line = readFile.ReadLine()) != null)
                {
                    string[] words = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (words[i] == searchStr)
                        {
                            quantity++;
                        }
                    }
                }

                readFile.Close();
            }

            return quantity;
        }

        public bool IsReplacedStr() // перезаписывать изменения в другой файл
        {
            bool isReplaced = false;
            string[] lines = File.ReadAllLines(filePathSource);

            for (int i = 0; i < lines.Length; i++)
            {
                if(Regex.IsMatch(lines[i], $@"\b{searchStr}\b"))
                {
                    lines[i] = Regex.Replace(lines[i], $@"\b{searchStr}\b", replacementStr);
                    isReplaced = true;
                }
            }

            File.WriteAllLines(filePathReplaced, lines);

            return isReplaced;
        }
    }
}
