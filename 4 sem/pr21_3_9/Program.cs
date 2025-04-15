using System;
using System.IO;
using System.Collections.Generic;

public class BinaryTree
{
    private class Node
    {
        public int inf;
        public int counter;
        public Node left;
        public Node right;

        public Node(int nodeInf)
        {
            inf = nodeInf;
            counter = 1;
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
                r.counter++;
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
            return r.counter;
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

    public bool CanBalanceWithAdditions(int n, out List<(int, int)> possibleValues)
    {
        possibleValues = new List<(int, int)>();

        int currentNodes = Count();
        int currentHeight = Height();

        // Минимальное количество узлов для сбалансированного дерева данной высоты
        int minNodesForHeight = (1 << currentHeight) - 1;

        // Если текущее количество узлов плюс n меньше минимального для текущей высоты,
        // балансировка невозможна
        if (currentNodes + n < minNodesForHeight)
        {
            return false;
        }

        // Проверяем, можно ли достичь баланса добавлением узлов
        int nodesToAdd = minNodesForHeight - currentNodes;

        if (nodesToAdd <= n)
        {
            // Собираем возможные значения для добавления
            CollectPossibleValues(tree, possibleValues);
            return true;
        }

        return false;
    }

    // Собирает возможные значения для добавления узлов
    private void CollectPossibleValues(Node r, List<(int, int)> possibleValues)
    {
        if (r == null) return;

        // Для каждого узла можно добавить значения чуть меньше или чуть больше
        // чтобы сохранить свойство BST
        possibleValues.Add((r.inf - 1, r.inf)); // Меньше текущего узла
        possibleValues.Add((r.inf, r.inf + 1)); // Больше текущего узла

        CollectPossibleValues(r.left, possibleValues);
        CollectPossibleValues(r.right, possibleValues);
    }
}

class Program
{
    static void Main(string[] args)
    {
        BinaryTree bst = new BinaryTree();

        // Чтение входных данных
        string[] numbers = File.ReadAllText("C:\\Users\\user\\Desktop\\A&SD\\4 sem\\pr21_3_9\\input.txt").Split();

        // Построение дерева
        foreach (string num in numbers)
        {
            if (int.TryParse(num, out int value))
            {
                bst.Add(value);
            }
        }

        // Проверка возможности балансировки (предположим n=10)
        Console.Write("Введите n: ");
        int n = int.Parse(Console.ReadLine());

        List<(int, int)> possibleValues;

        bool canBalance = bst.CanBalanceWithAdditions(n, out possibleValues);

        // Вывод результатов
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
        }
    }
}