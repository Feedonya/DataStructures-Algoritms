using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr2
{
    internal class Program
    {
        static void Main()
        {
            // является ли заданное целое число четным;

            Console.Write("Введите целое число: ");
            int number = int.Parse(Console.ReadLine());

            string result = (number % 2 == 0) ? "Чётное" : "Нечётное";

            Console.WriteLine($"Число {number} является: {result}");
            Console.ReadLine();
        }
    }
}
