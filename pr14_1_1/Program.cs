using System;

struct SPoint
{
    public int x, y; // Поля структуры

    // Конструктор структуры
    public SPoint(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    // Метод для вывода координат точки
    public void Show()
    {
        Console.WriteLine("({0}, {1})", x, y);
    }

    // Метод для вычисления расстояния от начала координат
    public double Distance()
    {
        return Math.Sqrt(x * x + y * y);
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введите количество точек: ");
        int n = int.Parse(Console.ReadLine());

        SPoint[] points = new SPoint[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введите координаты точки {i + 1} (x y): ");
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            points[i] = new SPoint(x, y);
        }

        SPoint farthestPoint = points[0];
        double maxDistance = farthestPoint.Distance();

        for (int i = 1; i < n; i++)
        {
            double distance = points[i].Distance();
            if (distance > maxDistance)
            {
                maxDistance = distance;
                farthestPoint = points[i];
            }
        }

        Console.WriteLine("Точка, наиболее удаленная от начала координат:");
        farthestPoint.Show();
        Console.WriteLine("Расстояние: {0:F2}", maxDistance);
    }
}
