using System;
using System.IO;
using System.Collections.Generic;

public class BinaryTree
{
    private class Node
    {
        public int inf;
        public Node left;
        public Node right;

        public Node(int nodeInf)
        {
            inf = nodeInf;
            left = null;
            right = null;
        }

        public static void Add(ref Node r, int nodeInf)
        {
            if (r == null)
            {
                r = new Node(nodeInf);
            }
            else
            {
                if (r.inf > nodeInf)
                {
                    Add(ref r.left, nodeInf);
                }
                else
                {
                    Add(ref r.right, nodeInf);
                }
            }
        }

        public static int Height(Node r)
        {
            if (r == null) return 0;
            return 1 + Math.Max(Height(r.left), Height(r.right));
        }

        public static int CountNodes(Node r)
        {
            if (r == null) return 0;
            return 1 + CountNodes(r.left) + CountNodes(r.right);
        }
    }

    Node tree;

    public BinaryTree()
    {
        tree = null;
    }

    public void Add(int nodeInf)
    {
        Node.Add(ref tree, nodeInf);
    }

    public int Height()
    {
        return Node.Height(tree);
    }

    public int Count()
    {
        return Node.CountNodes(tree);
    }

    // Вычисляет минимальное количество узлов для сбалансированного дерева высоты h
    private int MinNodesForBalancedTree(int height)
    {
        if (height <= 0) return 0;
        if (height == 1) return 1;

        int[] minNodes = new int[height + 1];
        minNodes[0] = 0;
        minNodes[1] = 1;

        for (int h = 2; h <= height; h++)
        {
            minNodes[h] = minNodes[h - 1] + minNodes[h - 2] + 1;
        }

        return minNodes[height];
    }

    public bool CanBalanceWithAdditions(int n, out List<(int, int)> possibleValues, out int nodesNeeded)
    {
        possibleValues = new List<(int, int)>();

        int currentHeight = Height();
        int currentNodes = Count();

        // Вычисляем минимальное количество узлов для сбалансированного дерева текущей высоты
        int minNodesRequired = MinNodesForBalancedTree(currentHeight);

        // Вычисляем, сколько узлов нужно добавить
        nodesNeeded = minNodesRequired - currentNodes;

        // Если нужно добавить не больше n узлов, то балансировка возможна
        if (nodesNeeded <= n)
        {
            // Собираем возможные значения для добавления
            CollectPossibleValues(tree, possibleValues);
            return true;
        }

        return false;
    }

    private void CollectPossibleValues(Node r, List<(int, int)> possibleValues)
    {
        if (r == null) return;

        // Для каждого узла предлагаем значения для добавления
        if (r.left == null)
        {
            // Если нет левого потомка, предлагаем значение меньше текущего
            possibleValues.Add((r.inf - 10, r.inf - 1));
        }

        if (r.right == null)
        {
            // Если нет правого потомка, предлагаем значение больше текущего
            possibleValues.Add((r.inf + 1, r.inf + 10));
        }

        // Рекурсивно обрабатываем левое и правое поддеревья
        CollectPossibleValues(r.left, possibleValues);
        CollectPossibleValues(r.right, possibleValues);
    }
}

class Program
{
    static void Main(string[] args)
    {
        BinaryTree bst = new BinaryTree();

        string[] numbers = File.ReadAllText("C:\\Users\\user\\Desktop\\A&SD\\4 sem\\pr21_3_9\\input.txt").Split();

        foreach (string num in numbers)
        {
            if (int.TryParse(num, out int value))
            {
                bst.Add(value);
            }
        }

        Console.Write("Введите n: ");
        int n = int.Parse(Console.ReadLine());

        List<(int, int)> possibleValues;
        int nodesNeeded;

        bool canBalance = bst.CanBalanceWithAdditions(n, out possibleValues, out nodesNeeded);

        Console.WriteLine($"Текущая высота дерева: {bst.Height()}");
        Console.WriteLine($"Текущее количество узлов: {bst.Count()}");
        Console.WriteLine($"Требуется добавить узлов для балансировки: {nodesNeeded}");

        if (canBalance)
        {
            Console.WriteLine($"Дерево можно сбалансировать, добавив не более {n} узлов.");
            Console.WriteLine("Допустимые диапазоны значений для добавления:");
            foreach (var range in possibleValues)
            {
                Console.WriteLine($"От {range.Item1} до {range.Item2}");
            }
        }
        else
        {
            Console.WriteLine($"Дерево нельзя сбалансировать, добавив не более {n} узлов.");
            Console.WriteLine($"Требуется минимум {nodesNeeded} дополнительных узлов.");
        }
    }
}
