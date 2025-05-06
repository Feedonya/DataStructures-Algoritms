using System.Xml.Serialization;
using Project.Entities;

namespace Project.Data
{
    public class FigureRepository
    {
        private const string FilePath = @"C:\\Users\\user\\Desktop\\A&SD\\Project\\Projectfigures.xml";

        public List<Figure> GetAll()
        {
            if (!File.Exists(FilePath))
                return new List<Figure>();

            var serializer = new XmlSerializer(typeof(List<Figure>));
            using var stream = new FileStream(FilePath, FileMode.Open);
            return (List<Figure>)serializer.Deserialize(stream);
        }

        public void SaveAll(List<Figure> figures)
        {
            var serializer = new XmlSerializer(typeof(List<Figure>));
            using var stream = new FileStream(FilePath, FileMode.Create);
            serializer.Serialize(stream, figures);
        }
    }
}