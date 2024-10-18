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
            Console.Write("Введите сообщение: ");
            string message = Console.ReadLine();

            Console.Write("Введите подстроку для поиска: ");
            string substring = Console.ReadLine();

            string[] words = Regex.Split(message, @"\W+");

            Console.WriteLine("Слова, содержащие подстроку:");
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
