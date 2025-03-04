using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static void Main()
    {
        string inputFile = "C:\\Users\\user\\Desktop\\A&SD\\pr16_1_2\\input.txt";
        string outputFile = "C:\\Users\\user\\Desktop\\A&SD\\pr16_1_2\\output.txt";

        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Файл input.txt не найден.");
            return;
        }

        List<int> numbers = new List<int>();
        foreach (var line in File.ReadAllLines(inputFile))
        {
            var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            numbers.AddRange(parts.Select(int.Parse));
        }
        foreach (var number in numbers)
        {
            Console.WriteLine(number.ToString());
        }
        Console.WriteLine("\n");
        var positiveNumbers = numbers.Where(n => n < 0).OrderBy(num => -num);

        foreach (var number in positiveNumbers)
        {
            Console.WriteLine(number.ToString());
        }

        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            foreach (var number in positiveNumbers)
            {
                writer.WriteLine(number.ToString());
            }
        }

        Console.WriteLine("Результат записан в файл output.txt.");
    }
}