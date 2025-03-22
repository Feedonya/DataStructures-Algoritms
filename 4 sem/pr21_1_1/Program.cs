using System;
using System.IO;

namespace AVL_Tree
{
	public class AVLTree
	{
		private class Node
		{
			public int inf; // Информационное поле
			public int height; // Высота узла
			public Node left;  // Левое поддерево
			public Node rigth; // Правое поддерево

			public Node(int nodeInf)
			{
				inf = nodeInf;
				height = 1;
				left = null;
				rigth = null;
			}

			public int Height
			{
				get { return (this != null) ? this.height : 0; }
			}

			public int BalanceFactor
			{
				get
				{
					int rh = (this.rigth != null) ? this.rigth.Height : 0;
					int lh = (this.left != null) ? this.left.Height : 0;
					return rh - lh;
				}
			}

			public void NewHeight()
			{
				int rh = (this.rigth != null) ? this.rigth.Height : 0;
				int lh = (this.left != null) ? this.left.Height : 0;
				this.height = ((rh > lh) ? rh : lh) + 1;
			}

			public static void RotationRigth(ref Node t)
			{
				Node x = t.left;
				t.left = x.rigth;
				x.rigth = t;
				t.NewHeight();
				x.NewHeight();
				t = x;
			}

			public static void RotationLeft(ref Node t)
			{
				Node x = t.rigth;
				t.rigth = x.left;
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
					if (t.rigth.BalanceFactor < 0)
						RotationRigth(ref t.rigth);
					RotationLeft(ref t);
				}
				if (t.BalanceFactor == -2)
				{
					if (t.left.BalanceFactor > 0)
						RotationLeft(ref t.left);
					RotationRigth(ref t);
				}
			}

			public static void Add(ref Node r, int nodeInf)
			{
				if (r == null)
					r = new Node(nodeInf);
				else
				{
					if (((IComparable)(r.inf)).CompareTo(nodeInf) > 0)
						Add(ref r.left, nodeInf);
					else
						Add(ref r.rigth, nodeInf);
				}
				Rotation(ref r);
			}

			public static int SumOddNodes(Node r)
			{
				if (r == null)
					return 0;


				if (r.inf % 2 != 0)
                    return r.inf + SumOddNodes(r.left) + SumOddNodes(r.rigth);
                else
                    return SumOddNodes(r.left) + SumOddNodes(r.rigth);
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

		// Метод для подсчета суммы нечетных значений
		public int SumOddNodes()
		{
			return Node.SumOddNodes(tree);
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			string[] lines = File.ReadAllLines("C:\\Users\\user\\Desktop\\A&SD\\4 sem\\pr21_1_1\\input.txt");
			int[] numbers = Array.ConvertAll(lines, int.Parse);

			AVLTree tree = new AVLTree();
			foreach (int number in numbers)
			{
				tree.Add(number);
			}

			int sumOfOdds = tree.SumOddNodes();

			Console.WriteLine($"Сумма нечетных значений узлов дерева: {sumOfOdds}");
		}
	}
}