using System;
using System.IO;
using System.Linq;

namespace AVL_Tree
{
    public class AVLTree
    {
        private class Node
        {
            public int inf;
            public int height;
            public Node left;
            public Node right;

            public Node(int nodeInf)
            {
                inf = nodeInf;
                height = 1;
                left = null;
                right = null;
            }

            public int Height
            {
                get { return (this != null) ? this.height : 0; }
            }

            public int BalanceFactor
            {
                get
                {
                    int rh = (this.right != null) ? this.right.Height : 0;
                    int lh = (this.left != null) ? this.left.Height : 0;
                    return rh - lh;
                }
            }

            public void NewHeight()
            {
                int rh = (this.right != null) ? this.right.Height : 0;
                int lh = (this.left != null) ? this.left.Height : 0;
                this.height = ((rh > lh) ? rh : lh) + 1;
            }

            public static void RotationRight(ref Node t)
            {
                Node x = t.left;
                t.left = x.right;
                x.right = t;
                t.NewHeight();
                x.NewHeight();
                t = x;
            }

            public static void RotationLeft(ref Node t)
            {
                Node x = t.right;
                t.right = x.left;
                x.left = t;
                t.NewHeight();
                x.NewHeight();
                t = x;
            }

            public static void Rotation(ref Node t)
            {
                t.NewHeight();
                if (t.BalanceFactor == 2)
                {
                    if (t.right.BalanceFactor < 0)
                        RotationRight(ref t.right);
                    RotationLeft(ref t);
                }
                if (t.BalanceFactor == -2)
                {
                    if (t.left.BalanceFactor > 0)
                        RotationLeft(ref t.left);
                    RotationRight(ref t);
                }
            }

            public static void Add(ref Node r, int nodeInf)
            {
                if (r == null)
                    r = new Node(nodeInf);
                else
                {
                    if (r.inf.CompareTo(nodeInf) > 0)
                        Add(ref r.left, nodeInf);
                    else
                        Add(ref r.right, nodeInf);
                }
                Rotation(ref r);
            }

            public static int FindDepth(Node node, int target, int currentDepth)
            {
                if (node == null)
                    return -1;
                if (node.inf == target)
                    return currentDepth;
                int leftDepth = FindDepth(node.left, target, currentDepth + 1);
                return leftDepth != -1 ? leftDepth : FindDepth(node.right, target, currentDepth + 1);
            }
        }

        private Node tree;

        public AVLTree()
        {
            tree = null;
        }

        public void Add(int nodeInf)
        {
            Node.Add(ref tree, nodeInf);
        }

        public int FindDepth(int target)
        {
            return Node.FindDepth(tree, target, 0);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string fileContent = File.ReadAllText("C:\\Users\\user\\Desktop\\A&SD\\4 sem\\pr21_1_1\\input.txt").Trim();

            int[] numbers = fileContent
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            AVLTree tree = new AVLTree();
            foreach (int number in numbers)
            {
                tree.Add(number);
            }

            Console.Write("Введите значение для поиска глубины: ");
            int target = int.Parse(Console.ReadLine());

            int depth = tree.FindDepth(target);
            Console.WriteLine(depth == -1
                ? $"Узел {target} не найден."
                : $"Глубина узла {target}: {depth}");
            
        }
    }
}