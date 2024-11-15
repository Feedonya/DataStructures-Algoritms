using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string inputFile = "C:\\Users\\user\\Desktop\\A&SD\\pr15_1_1\\input.txt";
        string outputFile = "C:\\Users\\user\\Desktop\\A&SD\\pr15_1_1\\output.txt";

        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Файл input.txt не найден.");
            return;
        }

        // Чтение данных из файла
        List<int> numbers = File.ReadAllLines(inputFile)
                                .Select(int.Parse)
                                .ToList();

        // Фильтрация и сортировка положительных чисел
        var positiveNumbers = numbers.Where(num => num > 0)
                                        .OrderBy(num => num)
                                        .ToList();

        // Вывод результата на экран
        Console.WriteLine("Положительные числа, отсортированные по возрастанию:");
        Console.WriteLine(string.Join(", ", positiveNumbers));

        // Запись результата в файл
        File.WriteAllLines(outputFile, positiveNumbers.Select(num => num.ToString()));

        Console.WriteLine("Результат записан в файл output.txt.");
    }
}