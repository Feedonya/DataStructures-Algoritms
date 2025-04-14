using System;
using System.IO;
using System.Collections.Generic;

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

        public int Height => this?.height ?? 0;

        public int BalanceFactor
        {
            get
            {
                int rh = right?.Height ?? 0;
                int lh = left?.Height ?? 0;
                return rh - lh;
            }
        }

        public void NewHeight()
        {
            int rh = right?.Height ?? 0;
            int lh = left?.Height ?? 0;
            height = Math.Max(rh, lh) + 1;
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
                if (t.right?.BalanceFactor < 0)
                    RotationRight(ref t.right);
                RotationLeft(ref t);
            }
            if (t.BalanceFactor == -2)
            {
                if (t.left?.BalanceFactor > 0)
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
    }
}