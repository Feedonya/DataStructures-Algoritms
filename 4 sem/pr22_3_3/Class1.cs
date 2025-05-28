namespace Graph3;
public class Program
{
    static void Main()
    {
        Graph graph = new("C:\\Users\\user\\Desktop\\A&SD\\4 sem\\pr22_3_3\\input.txt");

        Console.Write("Введите начальный город: ");
        string startCity = Console.ReadLine();

        Console.Write("Введите конечный город: ");
        string endCity = Console.ReadLine();

        Console.WriteLine("Введите города, через которые должен проходить путь (через пробел):");
        string[] intermediateCities = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        graph.FindPathThroughCities(startCity, endCity, new List<string>(intermediateCities));
    }
}