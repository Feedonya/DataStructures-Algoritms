using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    class Program
    {
        static int CountOddDigits(int N)
        {
            int count = 0;
            while (N > 0)
            {
                int digit = N % 10;
                if (digit % 2 != 0)
                {
                    count++;
                }
                N /= 10;
            }
            return count;
        }

        static void Main()
        {
            Console.Write("Введите значение a: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Введите значение b: ");
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine("a) Количество нечётных цифр в числах на отрезке [a, b]:");
            for (int i = a; i <= b; i++)
            {
                int oddCount = CountOddDigits(i);
                Console.WriteLine($"{i}: {oddCount}");
            }

            Console.WriteLine("\nb) Числа, у которых количество нечётных цифр равно 0:");
            for (int i = a; i <= b; i++)
            {
                if (CountOddDigits(i) == 0)
                {
                    Console.WriteLine(i);
                }
            }

            Console.WriteLine("\nc) Числа с максимальным количеством нечётных цифр:");
            int maxOddCount = 0;
            for (int i = a; i <= b; i++)
            {
                maxOddCount = Math.Max(maxOddCount, CountOddDigits(i));
            }

            for (int i = a; i <= b; i++)
            {
                if (CountOddDigits(i) == maxOddCount)
                {
                    Console.WriteLine(i);
                }
            }

            Console.Write("\nВведите значение A: ");
            int A = int.Parse(Console.ReadLine());

            Console.Write("Введите значение B: ");
            int B = int.Parse(Console.ReadLine());

            int nextNumber = A + 1;
            while (CountOddDigits(nextNumber) != B)
            {
                nextNumber++;
            }

            Console.WriteLine($"d) Ближайшее число большее {A}, у которого количество нечётных цифр равно {B}: {nextNumber}");
            Console.ReadLine();
        }
    }
}

/*
 *      Dictionary<int, int> cache = new Dictionary<int, int>(); // Кэш для результатов
        int nextNumber = start + 1;

        // Если исходное число чётное, сразу перейдём к нечётному
        if (nextNumber % 2 == 0) nextNumber++;

        // Условие поиска ближайшего числа
        while (true)
        {
            if (!cache.ContainsKey(nextNumber)) // Проверяем кэш
            {
                cache[nextNumber] = CountOddDigits(nextNumber); // Сохраняем результат в кэш
            }

            if (cache[nextNumber] == targetOddDigits)
            {
                break; // Если нашли число с нужным количеством нечётных цифр
            }

            nextNumber += 2; // Увеличиваем на 2, так как нечётные цифры меняются при добавлении нечётного числа
        
 */