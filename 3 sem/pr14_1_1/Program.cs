using System;
using System.IO;

struct SPoint //описание структуры
{
    public int x, y; //поля структуры
    public SPoint(int x, int y) //конструктор структуры
    {
        this.x = x;
        this.y = y;
    }

    public double Distance()
    {
        return Math.Sqrt(x * x + y * y);
    }

    public override string ToString()
    {
        return $"({x}, {y})";
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
            int x = int.Parse(parts[0]);
            int y = int.Parse(parts[1]);
            points[i] = new SPoint(x, y);
        }

        double maxDistance = 0;

        foreach (var point in points)
        {
            double distance = point.Distance();
            if (distance > maxDistance)
            {
                maxDistance = distance;
            }
        }

        string[] farthestPoints = new string[points.Length];
        int count = 0;
        foreach (var point in points)
        {
            if (point.Distance() == maxDistance)
            {
                farthestPoints[count] = point.ToString();
                count++;
            }
        }

        File.WriteAllLines(outputFile, farthestPoints);

        Console.WriteLine("Результат записан в файл output.txt.");
    }
}