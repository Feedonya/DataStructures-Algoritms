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

        List<int> numbers = new List<int>();
        foreach (var line in File.ReadAllLines(inputFile))
        {
            var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            numbers.AddRange(parts.Select(int.Parse));
        }

        var positiveNumbers =
                    from num in numbers
                    where num > 0
                    orderby num descending
                    select num;

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