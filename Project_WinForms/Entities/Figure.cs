using System.Xml.Serialization;

namespace Project.Entities
{
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Circle))]
    [XmlInclude(typeof(Triangle))]
    [Serializable]
    public abstract class Figure : IComparable<Figure>
    {
        public Figure() { }

        public abstract double GetArea();
        public abstract double GetPerimeter();

        public override string ToString()
        {
            return $"Фигура: {GetType().Name}, Площадь: {GetArea()}, Периметр: {GetPerimeter()}";
        }

        public int CompareTo(Figure other)
        {
            if (other == null) return 1;
            return GetArea().CompareTo(other.GetArea());
        }
    }
}