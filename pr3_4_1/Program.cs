using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr3
{
    internal class Program
    {
        static void Main()
        {
            //квадраты всех целых чисел из диапазона от А до В (АВ) в обратном порядке;

            Console.Write("Введите значение A: ");
            int A = int.Parse(Console.ReadLine());

            Console.Write("Введите значение B: ");
            int B = int.Parse(Console.ReadLine());

            Console.WriteLine("Квадраты чисел в диапазоне от B до A:");
            if (A > 0) {
                for (int i = B; i >= A; i--){
                    Console.WriteLine($"{i}^2 = {i * i}");
                }
            }
            else {
                for (int i = A; i <= B; i++)
                {
                    Console.WriteLine($"{i}^2 = {i * i}");
                }
            }
            Console.ReadLine();
        }
    }
}
