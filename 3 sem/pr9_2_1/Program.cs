using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr9_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileF = "C:\\Users\\user\\Desktop\\A&SD\\pr9_2_1\\f.txt";
            string fileG = "C:\\Users\\user\\Desktop\\A&SD\\pr9_2_1\\g.txt";
            string fileH = "C:\\Users\\user\\Desktop\\A&SD\\pr9_2_1\\h.txt";

            if (!File.Exists(fileF))
            {
                Console.WriteLine("Файл f не найден. Проверьте путь к файлу.");
                return;
            }

            using (StreamWriter writerG = new StreamWriter(fileG))
            using (StreamWriter writerH = new StreamWriter(fileH))
            {
                string[] numbers = File.ReadAllText(fileF).Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string numStr in numbers)
                {
                    if (int.TryParse(numStr, out int number))
                    {
                        if (number % 2 == 0)
                        {
                            writerG.WriteLine(number);
                        }
                        else
                        {
                            writerH.WriteLine(number);
                        }
                    }
                }
            }

        }
    }
}