using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace pr8_3
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите текст: ");
            string text = Console.ReadLine();

            Console.Write("Введите подстроку для поиска: ");
            string substring = Console.ReadLine();

            // Массив символов-разделителей: пробелы и знаки препинания
            char[] delimiters = { ' ', ',', '.', '!', '?', ';', ':', '-', '(', ')', '"' };

            // Разделение строки на слова
            string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine("Слова, содержащие подстроку \"{0}\":", substring);
            foreach (string word in words)
            {
                if (word.Contains(substring))
                {
                    Console.WriteLine(word);
                }
            }
            Console.Read();
        }
    }
}

//Программирование на C# — это весело и полезно!
//о
//Программирование это весело полезно