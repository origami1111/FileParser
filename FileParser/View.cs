using System;
using System.IO;

namespace FileParser
{
    class View
    {
        private FileParserClass fileParser;

        private void PrintTask()
        {
            Console.WriteLine("========================================================");
            Console.WriteLine("Нужно написать программу, которая будет иметь два режима: " +
                "\n1. Считать количество вхождений строки в текстовом файле." +
                "\n2. Делать замену строки на другую в указанном файле" +
                "\nПрограмма должна принимать аргументы на вход при запуске:" +
                "\n1. <путь к файлу> <строка для подсчёта>" +
                "\n2. <путь к файлу> <строка для поиска> <строка для замены>");
            Console.WriteLine("========================================================");
        }
        
        private void PrintHelp()
        {
            Console.WriteLine("========================================================");
            Console.WriteLine("Возможные параметры:" +
                "\n-help - выводит информаци. о параметрах" +
                "\n-task - выводит условие задания");
            Console.WriteLine("========================================================");
        }
        
        public void PrintInstructions(string[] args)
        {
            if (args.Length == 0)
            {
                PrintHelp();
            }
            else
            {
                foreach (string str in args)
                {
                    switch (str)
                    {
                        case "-help":
                            PrintHelp();
                            break;
                        case "-task":
                            PrintTask();
                            break;
                        default:
                            Console.WriteLine($"Аргумент '{str}' не найден, или введен неверно!");
                            break;
                    }
                }
            }
        }
        
        public void SetParameters()
        {
            bool flag = true;

            while (flag)
            {
                Console.Write("\nВведите параметры:" +
                "\n1. <путь к файлу> <строка для подсчёта>" +
                "\n2. <путь к файлу> <строка для поиска> <строка для замены>" +
                "\n > ");
                string inputStr = Console.ReadLine();
                string[] parameters = inputStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    switch (parameters.Length)
                    {
                        case 2:
                            QuantityStr(parameters);
                            flag = false;
                            break;
                        case 3:
                            ReplaceStr(parameters);
                            flag = false;
                            break;
                        default:
                            Console.WriteLine("Параметры введены неверно!");
                            break;
                    }
                }
                catch (DirectoryNotFoundException)
                {
                    Console.Write("Путь к файлу указан неверно!");
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine($"Файл с названием {parameters[0]} не найден!");
                }

            }
        }

        private void QuantityStr(string[] parameters)
        {
            fileParser = new FileParserClass(parameters[0], parameters[1]);
            Console.WriteLine($"Количество вхождений слова '{parameters[1]}' в тексте = '{fileParser.QuantityStr()}'");
        }

        private void ReplaceStr(string[] parameters)
        {
            fileParser = new FileParserClass(parameters[0], parameters[1], parameters[2]);

            if (fileParser.IsReplacedStr())
            {
                Console.WriteLine($"Слово '{parameters[1]}' было успешно заменено на '{parameters[2]}'");
            }
            else
            {
                Console.WriteLine($"Слово '{parameters[1]}' не было найдено, поэтому замена не состоялась");
            }
        }
    }
}
