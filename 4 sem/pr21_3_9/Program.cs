using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BST_BalanceCheck
{
    public class BinarySearchTree
    {
        private class Node
        {
            public int Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(int value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
        }

        private Node root;

        public BinarySearchTree()
        {
            root = null;
        }

        // Метод для добавления элемента в дерево
        public void Add(int value)
        {
            root = Insert(root, value);
        }

        private Node Insert(Node node, int value)
        {
            if (node == null)
            {
                return new Node(value);
            }

            if (value < node.Value)
            {
                node.Left = Insert(node.Left, value);
            }
            else if (value > node.Value)
            {
                node.Right = Insert(node.Right, value);
            }

            return node;
        }

        // Проверка, является ли дерево сбалансированным
        public bool IsBalanced()
        {
            return CheckBalance(root) != -1;
        }

        private int CheckBalance(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            int leftHeight = CheckBalance(node.Left);
            if (leftHeight == -1)
            {
                return -1; // Левое поддерево несбалансировано
            }

            int rightHeight = CheckBalance(node.Right);
            if (rightHeight == -1)
            {
                return -1; // Правое поддерево несбалансировано
            }

            if (Math.Abs(leftHeight - rightHeight) > 1)
            {
                return -1; // Текущий узел несбалансирован
            }

            return Math.Max(leftHeight, rightHeight) + 1;
        }

        // Получение всех значений в дереве для анализа
        public List<int> GetAllValues()
        {
            List<int> values = new List<int>();
            InOrderTraversal(root, values);
            return values;
        }

        private void InOrderTraversal(Node node, List<int> values)
        {
            if (node == null)
            {
                return;
            }

            InOrderTraversal(node.Left, values);
            values.Add(node.Value);
            InOrderTraversal(node.Right, values);
        }

        // Проверка возможности сбалансировать дерево добавлением до n узлов
        public List<int> CanBalanceByAdding(int n)
        {
            List<int> values = GetAllValues();
            HashSet<int> possibleValues = new HashSet<int>();

            // Генерация всех возможных значений для добавления
            for (int i = -1000; i <= 1000; i++) // Диапазон значений для добавления
            {
                if (!values.Contains(i))
                {
                    possibleValues.Add(i);
                }
            }

            // Проверка всех комбинаций добавления до n узлов
            foreach (var combination in GetCombinations(possibleValues.ToList(), n))
            {
                BinarySearchTree testTree = new BinarySearchTree();
                foreach (var value in values)
                {
                    testTree.Add(value);
                }

                foreach (var value in combination)
                {
                    testTree.Add(value);
                }

                if (testTree.IsBalanced())
                {
                    return combination;
                }
            }

            return new List<int>(); // Если невозможно сбалансировать
        }

        // Вспомогательный метод для генерации комбинаций
        private IEnumerable<List<int>> GetCombinations(List<int> list, int n)
        {
            if (n == 0)
            {
                yield return new List<int>();
                yield break;
            }

            for (int i = 0; i < list.Count; i++)
            {
                int current = list[i];
                List<int> remaining = list.Skip(i + 1).ToList();

                foreach (var combo in GetCombinations(remaining, n - 1))
                {
                    combo.Insert(0, current);
                    yield return combo;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\user\\Desktop\\A&SD\\4 sem\\pr21_1_1\\input.txt";

            string fileContent = File.ReadAllText(filePath).Trim();
            int[] numbers = fileContent
                .Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            BinarySearchTree bst = new BinarySearchTree();
            foreach (int number in numbers)
            {
                bst.Add(number);
            }

            bool isBalanced = bst.IsBalanced();
            Console.WriteLine(isBalanced
                ? "Дерево сбалансировано."
                : "Дерево несбалансировано.");

            if (!isBalanced)
            {
                Console.Write("Введите максимальное количество узлов для добавления (n): ");
                int n = int.Parse(Console.ReadLine());

                List<int> result = bst.CanBalanceByAdding(n);
                if (result.Count > 0)
                {
                    Console.WriteLine($"Можно добавить следующие узлы: {string.Join(", ", result)}");
                }
                else
                {
                    Console.WriteLine("Невозможно сбалансировать дерево добавлением до n узлов.");
                }
            }
        }
    }
}