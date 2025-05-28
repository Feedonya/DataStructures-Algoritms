using GraphNPeripheryApp;

class Program
{
    static void Main()
    {
        string inputFileName = "C:\\Users\\user\\Desktop\\A&SD\\4 sem\\pr22_2_17\\input.txt";
        string outputFileName = "C:\\Users\\user\\Desktop\\A&SD\\4 sem\\pr22_2_17\\output.txt";

        if (!File.Exists(inputFileName))
        {
            Console.WriteLine($"Ошибка: файл '{inputFileName}' не найден.");
            return;
        }

        Graph graph = new Graph(inputFileName);

        Console.WriteLine("Граф из файла:");
        graph.Show();

        Console.Write("Введите вершину A: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Введите N для N-периферии: ");
        int n = int.Parse(Console.ReadLine());

        graph.NPeriphery(a, n, outputFileName);

        Console.WriteLine("Работа завершена. Результат сохранён в файл.");
    }
}