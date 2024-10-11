using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_4
{
    class Program
    {
        static void PrintDigitsInReverse(int number)
        {
            if (number < 10)
            {
                Console.Write(number);
                return;
            }

            Console.Write(number % 10);

            PrintDigitsInReverse(number / 10);
        }

        static void Main()
        {
            Console.Write("Введите значение A: ");
            int A = int.Parse(Console.ReadLine());

            Console.Write("Введите значение B: ");
            int B = int.Parse(Console.ReadLine());

            if (A > B)
            {
                Console.WriteLine("Ошибка: A должно быть меньше или равно B.");
                return;
            }

            Console.WriteLine($"Вывод чисел в обратном порядке на отрезке [{A}, {B}]:");
            for (int i = A; i <= B; i++)
            {
                Console.Write($"{i} в обратном порядке: ");
                PrintDigitsInReverse(i);
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }

}
