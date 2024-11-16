using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

static class Program
{
    public static IEnumerable<int> GetPositiveNumbers(this IEnumerable<int> numbers)
    {
        return numbers.Where(n => n > 0);
    }

    public static IEnumerable<int> SortDescending(this IEnumerable<int> numbers)
    {
        return numbers.OrderByDescending(n => n);
    }

    static void Main()
    {
        string inputFile = "C:\\Users\\user\\Desktop\\A&SD\\pr16_1_2\\input.txt";
        string outputFile = "C:\\Users\\user\\Desktop\\A&SD\\pr16_1_2\\output.txt";

        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Файл input.txt не найден.");
            return;
        }

        List<int> numbers = File.ReadAllLines(inputFile)
                                .Select(int.Parse)
                                .ToList();

        var positiveNumbers = numbers.GetPositiveNumbers()
                                     .SortDescending()
                                     .ToList();

        File.WriteAllLines(outputFile, positiveNumbers.Select(num => num.ToString()));

        Console.WriteLine("Результат записан в файл output.txt.");
    }
}
