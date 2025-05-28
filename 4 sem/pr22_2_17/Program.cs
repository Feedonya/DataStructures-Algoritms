using System;
using System.Collections.Generic;
using System.IO;

namespace GraphNPeripheryApp
{
    // Класс для работы с очередью (для BFS и других алгоритмов)
    public class Queue
    {
        private List<int> items = new List<int>();

        public void Add(int item) => items.Add(item);
        public bool IsEmpty => items.Count == 0;
    }

    // Класс стека
    public class Stack
    {
        private List<int> items = new List<int>();

        public void Push(int item) => items.Add(item);
        public bool IsEmpty => items.Count == 0;
    }

    public class Graph
    {
        private class Node
        {
            public int[,] array; // матрица смежности
            private bool[] nov; // непросмотренные вершины

            public int this[int i, int j]
            {
                get => array[i, j];
                set => array[i, j] = value;
            }

            public int Size => array.GetLength(0);

            public Node(int[,] a)
            {
                array = (int[,])a.Clone();
                nov = new bool[a.GetLength(0)];
            }

            public void NovSet()
            {
                for (int i = 0; i < Size; i++)
                    nov[i] = true;
            }

            // Алгоритм Дейкстры
            public long[] Dijkstr(int v, out int[] p)
            {
                NovSet();
                int size = Size;
                long[] d = new long[size];
                p = new int[size];

                for (int i = 0; i < size; i++)
                {
                    d[i] = int.MaxValue;
                    p[i] = -1;
                }

                d[v] = 0;

                while (true)
                {
                    int current = -1;
                    long minDist = int.MaxValue;

                    for (int i = 0; i < size; i++)
                    {
                        if (nov[i] && d[i] < minDist)
                        {
                            minDist = d[i];
                            current = i;
                        }
                    }

                    if (current == -1) break;

                    nov[current] = false;

                    for (int next = 0; next < size; next++)
                    {
                        if (array[current, next] > 0 && nov[next])
                        {
                            long newDist = d[current] + array[current, next];
                            if (newDist < d[next])
                            {
                                d[next] = newDist;
                                p[next] = current;
                            }
                        }
                    }
                }

                return d;
            }
        }

        private Node graph;

        public Graph(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                int n = int.Parse(reader.ReadLine());
                int[,] matrix = new int[n, n];

                for (int i = 0; i < n; i++)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < n; j++)
                        matrix[i, j] = int.Parse(parts[j]);
                }

                graph = new Node(matrix);
            }
        }

        public void NPeriphery(int a, int n, string outputFilename)
        {
            graph.NovSet();// массив для отметки непосещённых вершин
            int[] p;// массив предков для восстановления кратчайших путей
            long[] distances = graph.Dijkstr(a, out p);

            using (StreamWriter writer = new StreamWriter(outputFilename))
            {
                writer.WriteLine($"Вершины, входящие в {n}-периферию вершины {a}:");
                Console.WriteLine($"Вершины, входящие в {n}-периферию вершины {a}:");

                bool found = false;

                for (int i = 0; i < graph.Size; i++)
                {
                    if (i != a && distances[i] != int.MaxValue && distances[i] >= n)
                    {
                        string msg = $"Вершина {i}, расстояние: {distances[i]}";
                        writer.WriteLine(msg);
                        Console.WriteLine(msg);
                        found = true;
                    }
                }

                if (!found)
                {
                    string msg = "Нет таких вершин.";
                    writer.WriteLine(msg);
                    Console.WriteLine(msg);
                }
            }
        }
    
        public void Show()
        {
            for (int i = 0; i < graph.Size; i++)
            {
                for (int j = 0; j < graph.Size; j++)
                {
                    Console.Write($"{graph[i, j],4}");
                }
                Console.WriteLine();
            }
        }
    }
}