using System;
using System.IO;

namespace GraphFileConsoleApp
{
    public class Graph
    {
        private int[,] adjacencyMatrix;
        private int size;

        public Graph(int[,] matrix)
        {
            size = matrix.GetLength(0);
            adjacencyMatrix = (int[,])matrix.Clone();
        }

        public int this[int i, int j]
        {
            get { return adjacencyMatrix[i, j]; }
            set { adjacencyMatrix[i, j] = value; }
        }

        public int Size => size;

        public void AddEdge(int a, int b, int weight)
        {
            if (a < 0 || a >= size || b < 0 || b >= size)
            {
                throw new ArgumentException("Номер вершины выходит за границы.");
            }

            adjacencyMatrix[a, b] = weight;

            if (a != b)
            {
                adjacencyMatrix[b, a] = weight;
            }

            Console.WriteLine($"\nРебро ({a}, {b}) с весом {weight} успешно добавлено.");
        }

        public void Show()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{adjacencyMatrix[i, j],4}");
                }
                Console.WriteLine();
            }
        }

        public void SaveToFile(string filename)
        {
            using (var writer = new StreamWriter(filename))
            {
                writer.WriteLine(size);
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        writer.Write(adjacencyMatrix[i, j] + " ");
                    }
                    writer.WriteLine();
                }
            }
            Console.WriteLine($"\nГраф сохранён в файл: {filename}");
        }
    }

    class Program
    {
        static void Main()
        {
            string inputFileName = "C:\\Users\\user\\Desktop\\A&SD\\4 sem\\pr22_1_17\\input.txt";
            string outputFileName = "C:\\Users\\user\\Desktop\\A&SD\\4 sem\\pr22_1_17\\output.txt";

            if (!File.Exists(inputFileName))
            {
                Console.WriteLine($"Ошибка: файл '{inputFileName}' не найден.");
                return;
            }

            string[] lines = File.ReadAllLines(inputFileName);

            if (lines.Length == 0)
            {
                Console.WriteLine("Файл пуст.");
                return;
            }

            int n = int.Parse(lines[0]);
            int[,] matrix = new int[n, n];

            for (int i = 1; i <= n && i < lines.Length; i++)
            {
                string[] row = lines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < n && j < row.Length; j++)
                {
                    matrix[i - 1, j] = int.Parse(row[j]);
                }
            }

            Graph graph = new Graph(matrix);


            Console.WriteLine("Текущий граф:");
            graph.Show();

            Console.Write("Введите вершину A: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Введите вершину B: ");
            int b = int.Parse(Console.ReadLine());

            Console.Write("Введите вес ребра: ");
            int weight = int.Parse(Console.ReadLine());

            try
            {
                graph.AddEdge(a, b, weight);

                Console.WriteLine("\nОбновлённый граф:");
                graph.Show();

                graph.SaveToFile(outputFileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }

            Console.WriteLine("Работа завершена.");
        }
    }
}