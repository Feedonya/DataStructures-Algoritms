using System;
using System.Collections.Generic;
using System.IO;

public abstract class Figure : IComparable<Figure>
{
    public abstract double GetArea();
    public abstract double GetPerimeter();

    public virtual void PrintInfo()
    {
        Console.WriteLine($"Фигура: {GetType().Name}");
        Console.WriteLine($"Площадь: {GetArea()}");
        Console.WriteLine($"Периметр: {GetPerimeter()}");
    }

    public int CompareTo(Figure other)
    {
        if (other == null) return 1;
        return GetArea().CompareTo(other.GetArea());
    }
}

class Rectangle : Figure
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double GetArea() => Width * Height;

    public override double GetPerimeter() => 2 * (Width + Height);
}

class Circle : Figure
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double GetArea() => Math.PI * Radius * Radius;

    public override double GetPerimeter() => 2 * Math.PI * Radius;
}

class Triangle : Figure
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    public Triangle(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }

    private bool IsValid() => A + B > C && A + C > B && B + C > A;

    public override double GetArea()
    {
        double p = GetPerimeter() / 2;
        return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
    }

    public override double GetPerimeter() => A + B + C;
}

class Program
{
    static void Main()
    {
        string inputFilePath = "C:\\Users\\user\\Desktop\\A&SD\\pr18-19_1\\pr_18-19_1\\figures.txt";
        List<Figure> figures = new List<Figure>();

        foreach (var line in File.ReadAllLines(inputFilePath))
        {
            var parts = line.Split();
            string figureType = parts[0].ToLower();
            switch (figureType)
            {
                case "rectangle":
                    double width = double.Parse(parts[1]);
                    double height = double.Parse(parts[2]);
                    figures.Add(new Rectangle(width, height));
                    break;
                case "circle":
                    double radius = double.Parse(parts[1]);
                    figures.Add(new Circle(radius));
                    break;
                case "triangle":
                    double a = double.Parse(parts[1]);
                    double b = double.Parse(parts[2]);
                    double c = double.Parse(parts[3]);
                    figures.Add(new Triangle(a, b, c));
                    break;
            }
        }

        figures.Sort();

        foreach (var figure in figures)
        {
            figure.PrintInfo();
            Console.WriteLine();
        }
       
    }
}
