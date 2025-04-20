namespace Project.Entities
{
    [Serializable]
    public class Rectangle : Figure
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle() { }

        public Rectangle(double width, double height)
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
}