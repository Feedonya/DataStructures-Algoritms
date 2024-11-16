using System;
using System.Collections.Generic;
using System.IO;

struct SPoint //описание структуры
{
    public int x, y; //поля структуры
    public SPoint(int x, int y) //конструктор структуры
    {
        this.x = x;
        this.y = y;
    }
    //методы структуры
    public void Show()
    {
        Console.WriteLine("({0}, {1})", x, y);
    }
    public double Distance()
    {
        return Math.Sqrt(x* x+y* y);
    }
} //конец описания структуры

class Program
{
    static void Main()
    {
        string inputFile = "C:\\Users\\user\\Desktop\\A&SD\\pr14_1_1\\input.txt";
        string outputFile = "C:\\Users\\user\\Desktop\\A&SD\\pr14_1_1\\output.txt";

        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Файл input.txt не найден.");
            return;
        }

        string[] lines = File.ReadAllLines(inputFile);
        SPoint[] points = new SPoint[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(',');
            int x = int.Parse(parts[0].Trim());
            int y = int.Parse(parts[1].Trim());
            points[i] = new SPoint(x, y);
        }

        SPoint farthestPoint = points[0];
        double maxDistance = farthestPoint.Distance();

        for (int i = 1; i < points.Length; i++)
        {
            double distance = points[i].Distance();
            if (distance > maxDistance)
            {
                maxDistance = distance;
                farthestPoint = points[i];
            }
        }

        string result = $"Наиболее удалённая точка: ({farthestPoint.x}, {farthestPoint.y})";
        File.WriteAllText(outputFile, result);

        Console.WriteLine("Результат записан в файл output.txt.");
    }
}