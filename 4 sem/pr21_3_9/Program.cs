namespace BalancedBinaryTree
{
    public class BalancedBinaryTree
    {
        private class Node
        {
            public object inf; // информационное поле
            public Node left; // ссылка на левое поддерево
            public Node right; // ссылка на правое поддерево
            private int height;

            public int Height
            {
                get { return (this != null) ? height : 0; }
            }

            public int BalanceFactor
            {
                get
                {
                    int rh = (right != null) ? right.Height : 0;
                    int lh = (left != null) ? left.Height : 0;
                    return rh - lh;
                }
            }

            public double minRange = -1000;
            public double maxRange = 1000;

            public void NewHeight()
            {
                int rh = (right != null) ? right.Height : 0;
                int lh = (left != null) ? left.Height : 0;
                height = ((rh > lh) ? rh : lh) + 1;
            }

            public Node(object nodeInf)
            {
                inf = nodeInf;
                left = null;
                right = null;
                height = 1;
            }

            // добавляет узел в дерево так, чтобы дерево оставалось деревом бинарного поиска
            public static void Add(ref Node r, object nodeInf, int min, int max)
            {
                if (r == null)
                {
                    r = new Node(nodeInf);
                    r.minRange = min;
                    r.maxRange = max;
                }
                else
                {
                    if (((IComparable)(r.inf)).CompareTo(nodeInf) > 0)
                    {
                        Add(ref r.left, nodeInf, min, (int)r.inf);
                    }
                    else
                    {
                        Add(ref r.right, nodeInf, (int)r.inf, max);
                    }
                    r.NewHeight();
                }
            }

            // прямой обход дерева
            public static void Preorder(Node r)
            {
                if (r != null)
                {
                    Console.Write("{0} ", r.inf);
                    Preorder(r.left);
                    Preorder(r.right);
                }
            }

            public static List<object> PreorderToList(Node r)
            {
                List<object> result = new List<object>();
                PreorderHelper(r, result);
                return result;
            }

            private static void PreorderHelper(Node r, List<object> result)
            {
                if (r != null)
                {
                    result.Add(r.inf);
                    PreorderHelper(r.left, result);
                    PreorderHelper(r.right, result);
                }
            }

            // симметричный обход дерева
            public static void Inorder(Node r)
            {
                if (r != null)
                {
                    Inorder(r.left);
                    Console.Write("{0} ({1}) ", r.inf, r.height);
                    Inorder(r.right);
                }
            }

            // обратный обход дерева
            public static void Postorder(Node r)
            {
                if (r != null)
                {
                    Postorder(r.left);
                    Postorder(r.right);
                    Console.Write("{0} ({1}) ", r.inf, r.height);
                }
            }

            // поиск ключевого узла в дереве
            public static void Search(Node r, object key, out Node item)
            {
                if (r == null)
                {
                    item = null;
                }
                else
                {
                    if (((IComparable)(r.inf)).CompareTo(key) == 0)
                    {
                        item = r;
                    }
                    else
                    {
                        if (((IComparable)(r.inf)).CompareTo(key) > 0)
                        {
                            Search(r.left, key, out item);
                        }
                        else
                        {
                            Search(r.right, key, out item);
                        }
                    }
                }
            }

            //методы Del и Delete позволяют удалить узел в дереве так, чтобы дерево при этом
            //оставалось АВЛ-деревом
            private static void Del(Node t, ref Node tr)
            {
                if (tr.right != null)
                {
                    Del(t, ref tr.right);
                }
                else
                {
                    t.inf = tr.inf;
                    tr = tr.left;
                }
            }

            public static void Delete(ref Node t, object key)
            {
                if (t == null)
                {
                    Console.WriteLine("Данное значение в дереве отсутствует");
                }
                else
                {
                    if (((IComparable)(t.inf)).CompareTo(key) > 0)
                    {
                        Delete(ref t.left, key);
                        t.left.NewHeight();
                    }
                    else
                    {
                        if (((IComparable)(t.inf)).CompareTo(key) < 0)
                        {
                            Delete(ref t.right, key);
                            t.right.NewHeight();
                        }
                        else
                        {
                            if (t.left == null)
                            {
                                t = t.right;
                            }
                            else
                            {
                                if (t.right == null)
                                {
                                    t = t.left;
                                }
                                else
                                {
                                    Del(t, ref t.left);
                                    t.left.NewHeight();
                                }
                            }

                            t.NewHeight();
                        }
                    }
                }
            }
        }

        Node tree; // ссылка на корень дерева

        public object Inf // свойство позволяет получить доступ к значению информационного поля корня дерева
        {
            set { tree.inf = value; }
            get { return tree.inf; }
        }

        public BalancedBinaryTree() // открытый конструктор
        {
            tree = null;
        }

        private BalancedBinaryTree(Node r) // закрытый конструктор
        {
            tree = r;
        }

        public void Add(object nodeInf) // добавление узла в дерево
        {
            Node.Add(ref tree, nodeInf, -1000, 1000);
        }

        public void Preorder()
        {
            Node.Preorder(tree);
        }

        public List<object> PreorderToList()
        {
            return Node.PreorderToList(tree);
        }

        public void Inorder()
        {
            Node.Inorder(tree);
        }

        public void Postorder()
        {
            Node.Postorder(tree);
        }

        // поиск ключевого узла в дереве
        public BalancedBinaryTree Search(object key)
        {
            Node r;
            Node.Search(tree, key, out r);
            BalancedBinaryTree t = new BalancedBinaryTree(r);
            return t;
        }

        // удаление ключевого узла в дереве
        public void Delete(object key)
        {
            Node.Delete(ref tree, key);
        }

        public Dictionary<object, (object min, object max)> GetNodeValueRanges()
        {
            Dictionary<object, (object min, object max)> ranges = new();
            CollectRanges(tree, ranges);
            return ranges;
        }

        private void CollectRanges(Node node, Dictionary<object, (object min, object max)> ranges)
        {
            if (node != null)
            {
                ranges[node.inf] = ((object)node.minRange, (object)node.maxRange);
                CollectRanges(node.left, ranges);
                CollectRanges(node.right, ranges);
            }
        }

        public bool CheckIfCanBeRepairedByAddingNodes(int n)
        {
            List<int> addedNodes = new();

            while (addedNodes.Count < n)
            {
                var badNodes = GetBadNodes(tree);
                if (badNodes.Count == 0)
                {
                    Console.WriteLine("Дерево сбалансировано.");
                    break;
                }

                Node nodeToFix = badNodes.Dequeue();

                // Определяем, куда нужно добавлять узел для балансировки
                int newValue;
                if (nodeToFix.BalanceFactor < -1)
                {
                    // Левое поддерево слишком маленькое — идём вправо до листа
                    Node insertPoint = nodeToFix;
                    while (insertPoint.right != null)
                        insertPoint = insertPoint.right;

                    // Выбираем значение между insertPoint.inf и maxRange
                    var ranges = GetNodeValueRanges();
                    double min = (double)ranges[insertPoint.inf].min;
                    double max = (double)ranges[insertPoint.inf].max;
                    newValue = (int)((insertPoint.inf is double d ? d : (int)insertPoint.inf + 1 + max) / 2);
                }
                else
                {
                    // Правое поддерево слишком маленькое — идём влево до листа
                    Node insertPoint = nodeToFix;
                    while (insertPoint.left != null)
                        insertPoint = insertPoint.left;

                    // Выбираем значение между minRange и insertPoint.inf
                    var ranges = GetNodeValueRanges();
                    double min = (double)ranges[insertPoint.inf].min;
                    double max = (double)ranges[insertPoint.inf].max;
                    newValue = (int)((min + (insertPoint.inf is double d ? d : (int)insertPoint.inf)) / 2);
                }

                // Добавляем новое значение
                Add(newValue);
                addedNodes.Add(newValue);

                // Выводим прогресс
                Console.WriteLine($"Добавлен узел {newValue}. Текущее дерево:");
                Preorder();
            }

            // Проверяем финальное состояние
            if (IsBalanced(tree))
            {
                Console.WriteLine("✅ Дерево успешно отбалансировано.");
                Console.WriteLine("Итоговое дерево:");
                Preorder();
                return true;
            }
            else
            {
                Console.WriteLine("❌ Не удалось полностью отбалансировать дерево за заданное число операций.");
                Console.WriteLine("Частично восстановленное дерево:");
                Preorder();
                return false;
            }
        }

        private Queue<Node> GetBadNodes(Node r)
        {
            List<Node> result = new List<Node>();
            GetBadNodesHelper(r, result);
            return new(result.OrderBy(n => -n.Height).ToList());
        }

        private void GetBadNodesHelper(Node r, List<Node> result)
        {
            if (r != null)
            {
                GetBadNodesHelper(r.left, result);
                GetBadNodesHelper(r.right, result);
                if (Math.Abs(r.BalanceFactor) > 1)
                {
                    result.Add(r);
                }
            }
        }

        private bool IsBalanced(Node node)
        {
            if (node == null) return true;

            return Math.Abs(node.BalanceFactor) <= 1
                && IsBalanced(node.left)
                && IsBalanced(node.right);
        }

        private int GetSuitableValueForInsert(Node node, bool isLeft)
        {
            var ranges = GetNodeValueRanges();
            double min = (double)ranges[node.inf].min;
            double max = (double)ranges[node.inf].max;

            int candidate;

            if (isLeft)
            {
                // Вставляем значение между min и node.inf
                candidate = (int)((min + (int)node.inf) / 2);
                if (candidate >= (int)node.inf)
                    candidate = (int)(node.inf) - 1;
            }
            else
            {
                // Вставляем значение между node.inf и max
                candidate = (int)(((int)node.inf + max) / 2);
                if (candidate <= (int)node.inf)
                    candidate = (int)(node.inf) + 1;
            }

            // Проверяем, что такого значения еще нет в дереве
            while (IsValueExists(candidate))
            {
                candidate += isLeft ? -1 : 1;
            }

            return candidate;
        }

        private bool IsValueExists(int value)
        {
            Node result;
            Node.Search(tree, value, out result);
            return result != null;
        }
        private bool RepairTree(Node node, int remainingAdds, List<int> addedNodes)
        {
            if (node == null || remainingAdds <= 0) return IsBalanced(tree);

            // Сначала рекурсивно восстанавливаем левое поддерево
            RepairTree(node.left, remainingAdds, addedNodes);
            // Затем рекурсивно восстанавливаем правое поддерево
            RepairTree(node.right, remainingAdds - addedNodes.Count, addedNodes);

            // Проверяем, сбалансирован ли текущий узел
            if (Math.Abs(node.BalanceFactor) > 1)
            {
                // Определяем, в какую сторону нужно добавлять
                if (node.left?.Height < node.right?.Height)
                {
                    // Добавляем в левое поддерево
                    int newValue = GetSuitableValueForInsert(node, isLeft: true);
                    Add(newValue);
                    addedNodes.Add(newValue);
                }
                else
                {
                    // Добавляем в правое поддерево
                    int newValue = GetSuitableValueForInsert(node, isLeft: false);
                    Add(newValue);
                    addedNodes.Add(newValue);
                }
            }

            // После всех изменений проверяем общее состояние дерева
            return IsBalanced(tree);
        }
    }
}