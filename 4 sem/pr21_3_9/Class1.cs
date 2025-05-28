namespace BalancedBinaryTree
{
    class Program
    {
        static void Main()
        {
            string[] lines = File.ReadAllLines("C:\\Users\\user\\Desktop\\A&SD\\4 sem\\pr21_3_9\\input.txt");
            int[] numbers = Array.ConvertAll(lines, int.Parse);
            BalancedBinaryTree tree = new BalancedBinaryTree();

            foreach (int number in numbers)
            {
                tree.Add(number);
            }

            Console.WriteLine("Введите n: ");
            int n = Console.Read();

            //Dictionary<object, (object min, object max)> range = tree.GetLeafValueRanges();
            tree.CheckIfCanBeRepairedByAddingNodes(n);
            

            
        }
    }
}