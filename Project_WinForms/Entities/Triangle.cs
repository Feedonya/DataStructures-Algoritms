﻿namespace Project.Entities
{
    [Serializable]
    public class Triangle : Figure
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public Triangle() { }

        public Triangle(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
            if (!IsValid())
            {
                throw new Exception("Треугольник не валиден");
            }
        }

        private bool IsValid() => A + B > C && A + C > B && B + C > A;

        public override double GetArea()
        {
            double p = GetPerimeter() / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public override double GetPerimeter() => A + B + C;
    }
}