//using System;
//using System.IO;
//using System.Collections.Generic;

//namespace CityGraph
//{
//    public class City
//    {
//        public string Name { get; set; }
//        public int X { get; set; }
//        public int Y { get; set; }

//        public City(string name, int x, int y)
//        {
//            Name = name;
//            X = x;
//            Y = y;
//        }
//    }

//    public class Graph
//    {
//        private List<City> cities;
//        private float[,] adjacencyMatrix;

//        public Graph(string filename)
//        {
//            cities = new List<City>();
//            ReadInputFile(filename);
//        }

//        private void ReadInputFile(string filename)
//        {
//            using (StreamReader file = new StreamReader(filename))
//            {
//                // Чтение количества городов
//                int n = int.Parse(file.ReadLine());

//                // Чтение информации о городах
//                for (int i = 0; i < n; i++)
//                {
//                    string[] parts = file.ReadLine().Split(' ');
//                    string name = parts[0];
//                    int x = int.Parse(parts[1]);
//                    int y = int.Parse(parts[2]);
//                    cities.Add(new City(name, x, y));
//                }

//                // Чтение матрицы смежности
//                adjacencyMatrix = new float[n, n];
//                for (int i = 0; i < n; i++)
//                {
//                    string[] row = file.ReadLine().Split(' ');
//                    for (int j = 0; j < n; j++)
//                    {
//                        adjacencyMatrix[i, j] = int.Parse(row[j]) == 1 ? (int)CalculateDistance(i, j) : 0;
//                    }
//                }

//                Show();
//            }
//        }

//        private float CalculateDistance(int cityIndex1, int cityIndex2)
//        {
//            City c1 = cities[cityIndex1];
//            City c2 = cities[cityIndex2];
//            return MathF.Sqrt(MathF.Pow(c2.X - c1.X, 2) + MathF.Pow(c2.Y - c1.Y, 2));
//        }

//        public (float distance, List<int> path) Dijkstra(int start, int end)
//        {
//            int n = cities.Count;
//            float[] distances = new float[n];
//            int[] previous = new int[n];
//            bool[] visited = new bool[n];

//            for (int i = 0; i < n; i++)
//            {
//                distances[i] = float.PositiveInfinity;
//                previous[i] = -1;
//            }
//            distances[start] = 0;

//            for (int count = 0; count < n - 1; count++)
//            {
//                int u = -1;
//                float minDistance = float.PositiveInfinity;

//                for (int i = 0; i < n; i++)
//                {
//                    if (!visited[i] && distances[i] < minDistance)
//                    {
//                        minDistance = distances[i];
//                        u = i;
//                    }
//                }

//                if (u == -1) break;
//                visited[u] = true;

//                for (int v = 0; v < n; v++)
//                {
//                    if (!visited[v] && adjacencyMatrix[u, v] != 0)
//                    {
//                        float alt = distances[u] + CalculateDistance(u, v);
//                        if (alt < distances[v])
//                        {
//                            distances[v] = alt;
//                            previous[v] = u;
//                        }
//                    }
//                }
//            }

//            // Восстановление пути
//            List<int> path = new List<int>();
//            if (distances[end] == float.PositiveInfinity)
//                return (float.PositiveInfinity, path);

//            for (int at = end; at != -1; at = previous[at])
//            {
//                path.Add(at);
//            }
//            path.Reverse();

//            return (distances[end], path);
//        }

//        public void FindPathThroughCity(string cityA, string cityB, string cityC)
//        {
//            int indexA = cities.FindIndex(c => c.Name.Equals(cityA, StringComparison.OrdinalIgnoreCase));
//            int indexB = cities.FindIndex(c => c.Name.Equals(cityB, StringComparison.OrdinalIgnoreCase));
//            int indexC = cities.FindIndex(c => c.Name.Equals(cityC, StringComparison.OrdinalIgnoreCase));

//            if (indexA == -1 || indexB == -1 || indexC == -1)
//            {
//                Console.WriteLine("Один из указанных городов не найден!");
//                return;
//            }

//            // Находим путь от A до C
//            var (distanceAC, pathAC) = Dijkstra(indexA, indexC);

//            // Находим путь от C до B
//            var (distanceCB, pathCB) = Dijkstra(indexC, indexB);

//            if (distanceAC == float.PositiveInfinity || distanceCB == float.PositiveInfinity)
//            {
//                Console.WriteLine("Путь через указанный город не существует!");
//                return;
//            }

//            // Объединяем пути
//            List<int> fullPath = new List<int>(pathAC);
//            fullPath.AddRange(pathCB.GetRange(1, pathCB.Count - 1));

//            float totalDistance = distanceAC + distanceCB;

//            // Вывод результата
//            Console.WriteLine($"Кратчайший путь из {cityA} в {cityB} через {cityC}:");
//            Console.WriteLine($"Общая длина: {totalDistance:F2}");
//            Console.Write("Маршрут: ");
//            for (int i = 0; i < fullPath.Count; i++)
//            {
//                Console.Write(cities[fullPath[i]].Name);
//                if (i < fullPath.Count - 1)
//                    Console.Write(" -> ");
//            }
//            Console.WriteLine();
//        }

//        public void Show()
//        {
//            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
//            {
//                for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
//                {
//                    Console.Write("{0,4}", adjacencyMatrix[i, j]);
//                }
//                Console.WriteLine();
//            }
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            try
//            {
//                string filePath = "C:\\Users\\user\\Desktop\\A&SD\\4 sem\\pr22_3_3\\input.txt"; // Убедись, что файл лежит здесь

//                Graph graph = new Graph(filePath);

//                Console.WriteLine("\nВведите город A:");
//                string cityA = Console.ReadLine();

//                Console.WriteLine("Введите город B:");
//                string cityB = Console.ReadLine();

//                Console.WriteLine("Введите город C (через который должен проходить путь):");
//                string cityC = Console.ReadLine();

//                graph.FindPathThroughCity(cityA, cityB, cityC);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Ошибка: {ex.Message}");
//            }
//        }
//    }
//}