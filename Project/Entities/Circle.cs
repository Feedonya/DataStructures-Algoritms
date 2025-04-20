namespace Project.Entities
{
    [Serializable]
    public class Circle : Figure
    {
        public double Radius { get; set; }

        public Circle() { }

        public Circle(double radius)
        {
            Radius = radius;
            if (!IsValid())
            {
                throw new Exception("Круг не валиден");
            }
        }

        private bool IsValid() => Radius > 0;

        public override double GetArea() => Math.PI * Radius * Radius;

        public override double GetPerimeter() => 2 * Math.PI * Radius;
    }
}