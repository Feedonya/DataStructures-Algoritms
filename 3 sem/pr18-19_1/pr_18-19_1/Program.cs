using System.Xml.Serialization;

class Program
{
    static void Main()
    {
        List<Figure> figures = new List<Figure>();
        XmlSerializer xmlSerializer = new(typeof(List<Figure>));
        string XML_PATH = "C:\\Users\\user\\Desktop\\A&SD\\3 sem\\pr18-19_1\\pr_18-19_1\\figures.xml";
        string TXT_PATH = "C:\\Users\\user\\Desktop\\A&SD\\3 sem\\pr18-19_1\\pr_18-19_1\\figures.txt";

        if (File.Exists(XML_PATH) && new FileInfo(XML_PATH).Length > 0)
        {
            try
            {
                using (FileStream fileStream = new(XML_PATH, FileMode.Open, FileAccess.Read))
                {
                    figures = (List<Figure>)xmlSerializer.Deserialize(fileStream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке XML: {ex.Message}");
                figures = LoadFromTxt(TXT_PATH);
            }
        }
        else
        {
            figures = LoadFromTxt(TXT_PATH);
        }

        figures.Sort();

        foreach (var figure in figures)
        {
            Console.WriteLine(figure);
            Console.WriteLine();
        }

        using (FileStream fileStream = new(XML_PATH, FileMode.Create, FileAccess.Write))
        {
            xmlSerializer.Serialize(fileStream, figures);
        }
    }

    static List<Figure> LoadFromTxt(string path)
    {
        List<Figure> figures = new List<Figure>();
        if (!File.Exists(path)) return figures;

        foreach (var line in File.ReadAllLines(path))
        {
            var parts = line.Split();
            if (parts.Length == 0) continue;

            string figureType = parts[0].ToLower();
            try
            {
                switch (figureType)
                {
                    case "rectangle":
                        figures.Add(new Rectangle(double.Parse(parts[1]), double.Parse(parts[2])));
                        break;
                    case "circle":
                        figures.Add(new Circle(double.Parse(parts[1])));
                        break;
                    case "triangle":
                        figures.Add(new Triangle(double.Parse(parts[1]), double.Parse(parts[2]), double.Parse(parts[3])));
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке фигуры из TXT: {ex.Message}");
            }
        }
        return figures;
    }
}