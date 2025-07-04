﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Graph
{
    private class Node
    {
        private float[,] array;
        private bool[] visited;

        public float this[int i, int j]
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

        public Node(float[,] a)
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
                if (array[v, u] > 0 && visited[u])
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
                    if (array[v, u] > 0 && visited[u])
                    {
                        queue.Enqueue(u);
                        visited[u] = false;
                    }
                }
            }
        }

        public float[] Dijkstra(int start, out int[] prev)
        {
            visited[start] = false;

            float[,] cost = new float[Size, Size];
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    cost[i, j] = (i == j || array[i, j] == 0) ? float.PositiveInfinity : array[i, j];

            float[] dist = new float[Size];
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
                float min = float.PositiveInfinity;
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
                    if (!used[j] && cost[w, j] != float.PositiveInfinity && dist[j] > dist[w] + cost[w, j])
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

        public float[,] Floyd(out int[,] p)
        {
            float[,] a = new float[Size, Size];
            p = new int[Size, Size];

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    a[i, j] = (i == j) ? 0 : (array[i, j] != 0 ? array[i, j] : float.PositiveInfinity);
                    p[i, j] = -1;
                }
            }

            for (int k = 0; k < Size; k++)
            {
                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        if (a[i, k] < float.PositiveInfinity && a[k, j] < float.PositiveInfinity)
                        {
                            float dist = a[i, k] + a[k, j];
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
    private List<(float x, float y)> coordinates = new();

    public Graph(string filename)
    {
        using StreamReader file = new(filename);
        int n = int.Parse(file.ReadLine());
        float[,] adjacency = new float[n, n];

        for (int i = 0; i < n; i++)
        {
            string[] parts = file.ReadLine().Split();
            cityNames.Add(parts[0]);
            float x = float.Parse(parts[1]);
            float y = float.Parse(parts[2]);
            coordinates.Add((x, y));
        }

        for (int i = 0; i < n; i++)
        {
            string[] parts = file.ReadLine().Split();
            for (int j = 0; j < n; j++)
                adjacency[i, j] = float.Parse(parts[j]);
        }

        float[,] weighted = new float[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (adjacency[i, j] > 0)
                {
                    var dx = coordinates[i].x - coordinates[j].x;
                    var dy = coordinates[i].y - coordinates[j].y;
                    weighted[i, j] = (float)Math.Sqrt(dx * dx + dy * dy);
                }
                else
                {
                    weighted[i, j] = 0;
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
                Console.Write($"{graph[i, j],8:F2}");
            Console.WriteLine();
        }
    }

    public void ShowCoordinates()
    {
        for (int i = 0; i < cityNames.Count; i++)
        {
            var (x, y) = coordinates[i];
            Console.WriteLine($"{cityNames[i]}: ({x:F4}, {y:F4})");
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
        float[] dist = graph.Dijkstra(v, out int[] prev);
        Console.WriteLine($"Кратчайшие пути от вершины {v}:");

        for (int i = 0; i < graph.Size; i++)
        {
            if (i == v) continue;
            if (dist[i] == float.PositiveInfinity)
            {
                Console.WriteLine($"До вершины {i} пути нет.");
            }
            else
            {
                Console.Write($"До вершины {i}: длина = {dist[i]:F2}, путь: ");
                Stack<int> path = new();
                graph.BuildPathDijkstra(v, i, prev, ref path);
                Console.WriteLine(string.Join(" -> ", path.Select(x => cityNames[x])));
            }
        }
    }

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
        float[] dist = graph.Dijkstra(start, out int[] prev);

        if (dist[end] == float.PositiveInfinity)
        {
            Console.WriteLine("Пути не существует.");
            return;
        }

        Stack<int> path = new();
        graph.BuildPathDijkstra(start, end, prev, ref path);

        Console.WriteLine($"Кратчайший путь от {cityA} до {cityB}:");
        Console.WriteLine($"Длина = {dist[end]:F2}");
        Console.WriteLine(string.Join(" -> ", path.Select(i => cityNames[i])));
    }

    public void FindAllPathsThroughCities(string startCity, List<string> allowedCities)
    {
        int startIndex = cityNames.IndexOf(startCity);
        if (startIndex == -1)
        {
            Console.WriteLine("Начальный город не найден.");
            return;
        }

        // Фильтруем граф по списку разрешённых городов
        HashSet<string> allowedSet = new(allowedCities) { startCity };
        FilterGraphByCities(allowedSet);

        graph.ResetVisited();
        float[] dist = graph.Dijkstra(startIndex, out int[] prev);

        Console.WriteLine($"\nКратчайшие пути из города {startCity}, проходящие только через указанные города:");

        for (int i = 0; i < graph.Size; i++)
        {
            if (i == startIndex) continue;

            if (dist[i] == float.PositiveInfinity)
            {
                Console.WriteLine($"Путь до {cityNames[i]}: недоступен.");
            }
            else
            {
                Stack<int> path = new();
                graph.BuildPathDijkstra(startIndex, i, prev, ref path);

                bool allCitiesInAllowed = true;
                foreach (var node in path)
                {
                    if (!allowedSet.Contains(cityNames[node]))
                    {
                        allCitiesInAllowed = false;
                        break;
                    }
                }

                if (allCitiesInAllowed)
                {
                    Console.WriteLine($"До {cityNames[i]}, длина = {dist[i]:F2}: " +
                                      string.Join(" → ", path.Select(x => cityNames[x])));


                }
                else
                {
                    Console.WriteLine($"Путь до {cityNames[i]} содержит запрещённые города.");
                }
            }
        }
    }
}