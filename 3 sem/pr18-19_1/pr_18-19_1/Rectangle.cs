[Serializable]
public class Rectangle : Figure
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle()
    {
        Width = 0;
        Height = 0;
    }

    public Rectangle(double width, double height) // проверка на правильность данных
    {
        Width = width;
        Height = height;
        if (!IsValid())
        {
            throw new Exception("Прямоугольник не валиден");
        }
    }

    private bool IsValid() => Width > 0 && Height > 0;

    public override double GetArea() => Width * Height;

    public override double GetPerimeter() => 2 * (Width + Height);
}