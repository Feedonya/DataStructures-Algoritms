using System.Xml.Serialization;

[XmlInclude(typeof(Rectangle))]
[XmlInclude(typeof(Circle))]
[XmlInclude(typeof(Triangle))]
[Serializable]
public abstract class Figure : IComparable<Figure>
{
    public Figure() { }
    public abstract double GetArea();
    public abstract double GetPerimeter();

    //public virtual void PrintInfo() // перегрузить ToString
    //{
    //    Console.WriteLine($"Фигура: {GetType().Name}");
    //    Console.WriteLine($"Площадь: {GetArea()}");
    //    Console.WriteLine($"Периметр: {GetPerimeter()}");
    //}

    public override string ToString()
    {
        return ($"Фигура: { GetType().Name + '\n' + "Площадь: " + GetArea() + '\n' + "Периметр: " + GetPerimeter()}" );
    }

    public int CompareTo(Figure other)
    {
        if (other == null) return 1;
        return GetArea().CompareTo(other.GetArea());
    }
}