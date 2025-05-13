using System;
using Project.Domain.Services;
using Project.Entities;

namespace Project.App
{
    public class ConsoleApp
    {
        private readonly IFigureService _figureService;

        public ConsoleApp(IFigureService figureService)
        {
            _figureService = figureService;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Показать все фигуры");
                Console.WriteLine("2. Добавить фигуру");
                Console.WriteLine("3. Удалить фигуру");
                Console.WriteLine("4. Выход");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowAllFigures();
                        break;
                    case "2":
                        AddFigure();
                        break;
                    case "3":
                        RemoveFigure();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор");
                        break;
                }
            }
        }

        private void ShowAllFigures()
        {
            var figures = _figureService.GetAllFigures();
            if (figures.Count == 0)
            {
                Console.WriteLine("Фигур нет.");
                return;
            }

            for (int i = 0; i < figures.Count; i++)
            {
                Console.WriteLine($"Индекс: {i}");
                Console.WriteLine(figures[i]);
                Console.WriteLine(new string('-', 30));
            }
        }

        private void AddFigure()
        {
            Console.WriteLine("Введите тип фигуры (triangle, circle, rectangle):");
            var type = Console.ReadLine();

            Figure figure = type switch
            {
                "triangle" => CreateTriangle(),
                "circle" => CreateCircle(),
                "rectangle" => CreateRectangle(),
                _ => throw new Exception("Неизвестный тип фигуры")
            };

            _figureService.AddFigure(figure);
            Console.WriteLine("Фигура добавлена.");
        }

        private Figure CreateTriangle()
        {
            Console.WriteLine("Введите стороны треугольника (A B C):");
            var input = Console.ReadLine().Split(' ');
            return new Triangle(double.Parse(input[0]), double.Parse(input[1]), double.Parse(input[2]));
        }

        private Figure CreateCircle()
        {
            Console.WriteLine("Введите радиус круга:");
            var radius = double.Parse(Console.ReadLine());
            return new Circle(radius);
        }

        private Figure CreateRectangle()
        {
            Console.WriteLine("Введите ширину и высоту прямоугольника (Width Height):");
            var input = Console.ReadLine().Split(' ');
            return new Project.Entities.Rectangle(double.Parse(input[0]), double.Parse(input[1]));
        }

        private void RemoveFigure()
        {
            Console.WriteLine("Введите индекс фигуры для удаления:");
            var index = int.Parse(Console.ReadLine());
            _figureService.RemoveFigure(index);
            Console.WriteLine("Фигура удалена.");
        }
    }
}