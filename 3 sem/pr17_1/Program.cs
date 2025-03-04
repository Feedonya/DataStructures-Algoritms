using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;

class Point
{
    private int x;
    private int y;

    public Point()
    {
        x = 0;
        y = 0;
    }

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Point(Point other)
    {
        x = other.x;
        y = other.y;
    }

    public double DistanceFromOrigin()
    {
        return Math.Sqrt(x * x + y * y);
    }

    public double DistanceTo(Point other)
    {
        return Math.Sqrt(Math.Pow(other.x - x, 2) + Math.Pow(other.y - y, 2));
    }

    public void Move(int a, int b)
    {
        x += a;
        y += b;
    }

    public override string ToString()
    {
        return $"Point({x}, {y})";
    }

    public override int GetHashCode()
    {
        return x.GetHashCode() ^ y.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if (obj is Point other)
        {
            return x == other.x && y == other.y;
        }
        return false;
    }
    public int X
    {
        get => x;
        set => x = value;
    }

    public int Y
    {
        get => y;
        set => y = value;
    }

    public int Scalar
    {
        set
        {
            x *= value;
            y *= value;
        }
    }

    public int this[int index]
    {
        get
        {
            return index switch
            {
                0 => x,
                1 => y,
                _ => throw new IndexOutOfRangeException("Invalid index. Use 0 for x and 1 for y.")
            };
        }
        set
        {
            switch (index)
            {
                case 0:
                    x = value;
                    break;
                case 1:
                    y = value;
                    break;
                default:
                    throw new IndexOutOfRangeException("Invalid index. Use 0 for x and 1 for y.");
            }
        }
    }

    public static Point operator ++(Point p)
    {
        return new Point(p.x + 1, p.y + 1);
    }

    public static Point operator --(Point p)
    {
        return new Point(p.x - 1, p.y - 1);
    }

    public static Point operator +(Point p, int scalar)
    {
        return new Point(p.x + scalar, p.y + scalar);
    }

    public static Point operator +(int scalar, Point p)
    {
        return p + scalar;
    }

    public static bool operator true(Point p)
    {
        return p.x == p.y;
    }

    public static bool operator false(Point p)
    {
        return p.x != p.y;
    }
}

class Program
{
    static void Main()
    {
        Point p1 = new Point(1, 1);

        Point p2 = p1++;

        Point p3 = p1--;

        Point p4 = p1 + 5;

        Point p5 = 10 + p1;

        p1++;
        p2.X = 100;
        p3.Y = 10;

        ++p2;

        --p3;

        Console.WriteLine(p1);
        Console.WriteLine(p2);
        Console.WriteLine(p3);
        Console.WriteLine(p4);
        Console.WriteLine(p5);

    }

    //static void Main()
    //{
    //    string inputFile = "C:\\Users\\user\\Desktop\\A&SD\\pr17_1\\input.txt";
    //    string outputFile = "C:\\Users\\user\\Desktop\\A&SD\\pr17_1\\output.txt";

    //    if (!File.Exists(inputFile))
    //    {
    //        Console.WriteLine("Файл input.txt не найден.");
    //        return;
    //    }

    //    List<Point> points = new List<Point>();

    //    foreach (var line in File.ReadAllLines(inputFile))
    //    {
    //        var parts = line.Split(',');
    //        int x = int.Parse(parts[0]);
    //        int y = int.Parse(parts[1]);
    //        points.Add(new Point(x, y));
    //    }
    //    points.Add(new Point());

    //    //using (StreamReader reader = new StreamReader(inputFile))
    //    //{
    //    //    string line;
    //    //    while ((line = reader.ReadLine()) != null)
    //    //    {
    //    //        string[] parts = line.Split(',');
    //    //        if (parts.Length == 2)
    //    //        {
    //    //            int x = int.Parse(parts[0].Trim());
    //    //            int y = int.Parse(parts[1].Trim());
    //    //            points.Add(new Point(x, y));
    //    //        }
    //    //    }
    //    //    if (points.Count > 0)
    //    //    {
    //    //        Console.WriteLine($"Точка 1 из файла: {points[0]}");

    //    //        Point copiedPoint = new Point(points[0]);
    //    //        Console.WriteLine($"Копия точки 1 (через конструктор копирования): {copiedPoint}");

    //    //        points[0] = new Point(10, 20);
    //    //        Console.WriteLine($"После изменения точки 1: {points[0]}");

    //    //        Console.WriteLine($"Точка, скопированная из первой точки: {copiedPoint}");
    //    //    }
    //    //    else
    //    //    {
    //    //        Console.WriteLine("Файл пуст или не содержит данных для точек.");
    //    //    }
    //    //}

    //    using (StreamWriter writer = new StreamWriter(outputFile))
    //    {
    //        // все точки и проверка IndexOf
    //        writer.WriteLine("Список точек:");
    //        foreach (var point in points)
    //        {
    //            int i = points.IndexOf(point) + 1;
    //            writer.WriteLine($"{i}. {point}");
    //        }

    //        // Проверка методов
    //        writer.WriteLine($"\nРасстояние до начала координат для первой точки: {points[0].DistanceFromOrigin():F2}");
    //        writer.WriteLine($"Расстояние между точками: {points[0].DistanceTo(points[1]):F2}");

    //        points[0].Move(2, -1);
    //        writer.WriteLine($"После перемещения первой точки: {points[0]}");

    //        points[0].Scalar = 3;
    //        writer.WriteLine($"После умножения координат первой точки на скаляр: {points[0]}");

    //        // изменение через свойства
    //        writer.WriteLine($"\nКоордината X: {points[1].X}");
    //        writer.WriteLine($"Координата Y: {points[1].Y}");
    //        points[1].X = 10;
    //        points[1].Y = 20;
    //        writer.WriteLine($"Измененные координаты через свойства: {points[1]}");

    //        // индексатор
    //        writer.WriteLine($"\nКоординаты (X,Y): {points[0]}");
    //        points[0][0] = 15;
    //        writer.WriteLine($"Измененные координаты через индексатор: {points[0]}");

    //        writer.WriteLine($"\nКоординаты (X,Y): {points[0]}");
    //        points[0][1] = 15;
    //        writer.WriteLine($"Измененные координаты через индексатор: {points[0]}");

    //        // перегрузки методов предка object
    //        writer.WriteLine("\nПерегрузки методов предков:");
    //        writer.WriteLine($"ToString: {points[0].ToString()}");
    //        writer.WriteLine($"HashCode: {points[0].GetHashCode()}");
    //        writer.WriteLine($"Равность: {points[0].Equals(points[1])}");
    //        writer.WriteLine($"Равность: {points[0].Equals(points[0])}\n");

    //        Point p = new Point(2, 2);
    //        writer.WriteLine($"\nНачальная точка: {p}");

    //        // (ин/де)кременты
    //        points[2]++;
    //        writer.WriteLine($"\nПосле ++: {points[2]}");

    //        points[2]--;
    //        writer.WriteLine($"\nПосле --: {points[2]}");

    //        writer.WriteLine($"\nТочка: {points[2]}");
    //        writer.WriteLine($"Равны ли x и y? {((points[2] ? "Да" : "Нет"))}");
    //        points[2].X = 5;
    //        writer.WriteLine($"Точка после изменения: {points[2]}");
    //        writer.WriteLine($"Равны ли x и y? {((points[2] ? "Да" : "Нет\n"))}");

    //        // снова выводим все элементы после изменений
    //        foreach (var point in points)
    //        {
    //            writer.WriteLine(point);
    //        }
    //    }

    //    Console.WriteLine("Данные записаны в файл output.txt.");
    //}
}