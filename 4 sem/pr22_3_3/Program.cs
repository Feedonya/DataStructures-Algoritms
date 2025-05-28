using System;
using System.Collections.Generic;
using System.IO;

public class Graph
{
    private class Node
    {
        private int[,] array;
        private bool[] visited;


        public int this[int i, int j]
        {
            get => array[i, j];
            set => array[i, j] = value;
        }

        public int Size => array.GetLength(0);

        public void ResetVisited()
        {
            for (int i = 0; i < Size; i++)
                visited[i] = true;
        }

        public Node(int[,] a)
        {
            array = a;
            visited = new bool[a.GetLength(0)];
        }

        public void Dfs(int v)
        {
            Console.Write($"{v} ");
            visited[v] = false;

            for (int u = 0; u < Size; u++)
            {
                if (array[v, u] != 0 && visited[u])
                    Dfs(u);
            }
        }

        public void Bfs(int v)
        {
            Queue<int> queue = new();
            queue.Enqueue(v);
            visited[v] = false;

            while (queue.Count > 0)
            {
                v = queue.Dequeue();
                Console.Write($"{v} ");

                for (int u = 0; u < Size; u++)
                {
                    if (array[v, u] != 0 && visited[u])
                    {
                        queue.Enqueue(u);
                        visited[u] = false;
                    }
                }
            }
        }

        public long[] Dijkstra(int start, out int[] prev)
        {
            visited[start] = false;

            int[,] cost = new int[Size, Size];
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    cost[i, j] = (i == j || array[i, j] == 0) ? int.MaxValue : array[i, j];

            long[] dist = new long[Size];
            prev = new int[Size];
            bool[] used = new bool[Size];

            for (int i = 0; i < Size; i++)
            {
                dist[i] = cost[start, i];
                prev[i] = start;
            }

            dist[start] = 0;
            used[start] = true;

            for (int i = 0; i < Size - 1; i++)
            {
                long min = long.MaxValue;
                int w = -1;

                for (int j = 0; j < Size; j++)
                {
                    if (!used[j] && dist[j] < min)
                    {
                        min = dist[j];
                        w = j;
                    }
                }

                if (w == -1) break;
                used[w] = true;

                for (int j = 0; j < Size; j++)
                {
                    if (!used[j] && cost[w, j] != int.MaxValue && dist[j] > dist[w] + cost[w, j])
                    {
                        dist[j] = dist[w] + cost[w, j];
                        prev[j] = w;
                    }
                }
            }

            return dist;
        }

        public void BuildPathDijkstra(int a, int b, int[] p, ref Stack<int> path)
        {
            path.Push(b);
            if (a == p[b])
                path.Push(a);
            else
                BuildPathDijkstra(a, p[b], p, ref path);
        }

        public long[,] Floyd(out int[,] p)
        {
            long[,] a = new long[Size, Size];
            p = new int[Size, Size];

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    a[i, j] = (i == j) ? 0 : (array[i, j] != 0 ? array[i, j] : long.MaxValue);
                    p[i, j] = -1;
                }
            }

            for (int k = 0; k < Size; k++)
            {
                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        if (a[i, k] < long.MaxValue && a[k, j] < long.MaxValue)
                        {
                            long dist = a[i, k] + a[k, j];
                            if (a[i, j] > dist)
                            {
                                a[i, j] = dist;
                                p[i, j] = k;
                            }
                        }
                    }
                }
            }

            return a;
        }

        public void BuildPathFloyd(int a, int b, int[,] p, ref List<int> path)
        {
            int k = p[a, b];
            if (k != -1)
            {
                BuildPathFloyd(a, k, p, ref path);
                path.Add(k);
                BuildPathFloyd(k, b, p, ref path);
            }
        }
    }

    private Node graph;
    private List<string> cityNames = new();
    private List<(int x, int y)> coordinates = new();

    public Graph(string filename)
    {
        using StreamReader file = new(filename);
        int n = int.Parse(file.ReadLine());
        int[,] adjacency = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            string[] parts = file.ReadLine().Split();
            cityNames.Add(parts[0]);
            int x = int.Parse(parts[1]);
            int y = int.Parse(parts[2]);
            coordinates.Add((x, y));
        }

        for (int i = 0; i < n; i++)
        {
            string[] parts = file.ReadLine().Split();
            for (int j = 0; j < n; j++)
                adjacency[i, j] = int.Parse(parts[j]);
        }

        int[,] weighted = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (adjacency[i, j] == 1)
                {
                    var dx = coordinates[i].x - coordinates[j].x;
                    var dy = coordinates[i].y - coordinates[j].y;
                    weighted[i, j] = (int)Math.Sqrt(dx * dx + dy * dy);
                }
            }
        }

        graph = new Node(weighted);

    }

    public void Show()
    {
        for (int i = 0; i < graph.Size; i++)
        {
            for (int j = 0; j < graph.Size; j++)
                Console.Write($"{graph[i, j],4}");
            Console.WriteLine();
        }
    }

    public void Dfs(int v)
    {
        graph.ResetVisited();
        graph.Dfs(v);
        Console.WriteLine();
    }

    public void Bfs(int v)
    {
        graph.ResetVisited();
        graph.Bfs(v);
        Console.WriteLine();
    }

    public void Dijkstra(int v)
    {
        graph.ResetVisited();
        long[] dist = graph.Dijkstra(v, out int[] prev);
        Console.WriteLine($"Кратчайшие пути от вершины {v}:");

        for (int i = 0; i < graph.Size; i++)
        {
            if (i == v) continue;
            if (dist[i] == int.MaxValue)
            {
                Console.WriteLine($"До вершины {i} пути нет.");
            }
            else
            {
                Console.Write($"До вершины {i}: длина = {dist[i]}, путь: ");
                Stack<int> path = new();
                graph.BuildPathDijkstra(v, i, prev, ref path);
                Console.WriteLine(string.Join(" -> ", path));
            }
        }
    }

    //Обнуляет рёбра, если хотя бы один из соединяемых городов не находится в списке разрешённых.
    public void FilterGraphByCities(HashSet<string> allowedCities)
    {
        for (int i = 0; i < graph.Size; i++)
        {
            for (int j = 0; j < graph.Size; j++)
            {
                if (!allowedCities.Contains(cityNames[i]) || !allowedCities.Contains(cityNames[j]))
                    graph[i, j] = 0;
            }
        }
    }

    //Ищет кратчайший путь из города cityA в город cityB, используя только города из списка allowed. Если путь существует — выводит его.
    public void FindPathThroughCities(string cityA, string cityB, List<string> allowed)
    {
        int start = cityNames.IndexOf(cityA);
        int end = cityNames.IndexOf(cityB);

        if (start == -1 || end == -1)
        {
            Console.WriteLine("Город не найден.");
            return;
        }

        HashSet<string> set = new(allowed) { cityA, cityB };
        FilterGraphByCities(set);

        graph.ResetVisited();
        long[] dist = graph.Dijkstra(start, out int[] prev);

        if (dist[end] == int.MaxValue)
        {
            Console.WriteLine("Пути не существует.");
            return;
        }

        Stack<int> path = new();
        graph.BuildPathDijkstra(start, end, prev, ref path);

        Console.WriteLine($"Кратчайший путь от {cityA} до {cityB}:");
        Console.WriteLine($"Длина = {dist[end]}");
        Console.WriteLine(string.Join(" -> ", path.Select(i => cityNames[i])));
    }
}