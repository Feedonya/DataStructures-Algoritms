using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6
{
    class Program
    {
        static double CalculatePower(double x, int n)
        {
            if (n == 0)
            {
                return 1; // x^0 = 1
            }
            else if (n < 0)
            {
                return 1.0 / Math.Pow(Math.Abs(x), Math.Abs(n)); // 1 / |x|^|n|
            }
            else
            {
                return x * Math.Pow(x, n - 1); // x * x^(n-1)
            }
        }

        static void Main()
        {
            Console.Write("Введите значение x (вещественное число, x != 0): ");
            double x = double.Parse(Console.ReadLine());

            if (x == 0)
            {
                Console.WriteLine("Ошибка: x не может быть равным 0.");
                return;
            }

            Console.Write("Введите значение n (целое число): ");
            int n = int.Parse(Console.ReadLine());

            double result = CalculatePower(x, n);

            Console.WriteLine($"Значение {x}^{n} = {result}");
            Console.ReadLine();
        }
    }

}
