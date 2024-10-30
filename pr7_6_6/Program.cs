using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество строк: ");
        int rows = int.Parse(Console.ReadLine());

        int[][] jaggedArray = new int[rows][];

        for (int i = 0; i < rows; i++)
        {
            Console.Write($"Введите количество элементов в строке {i + 1}: ");
            int cols = int.Parse(Console.ReadLine());
            jaggedArray[i] = new int[cols];

            for (int j = 0; j < cols; j++)
            {
                Console.Write($"Элемент [{i},{j}]: ");
                jaggedArray[i][j] = int.Parse(Console.ReadLine());
            }
        }

        for (int i = 0; i < jaggedArray.Length; i++)
        {
            bool hasEven = false;
            foreach (int element in jaggedArray[i])
            {
                if (element % 2 == 0)
                {
                    hasEven = true;
                    break;
                }
            }

            if (!hasEven)
            {
                jaggedArray[i] = null;
            }
        }

        Console.WriteLine("Массив после удаления строк без чётных элементов:");
        foreach (var row in jaggedArray)
        {
            if (row != null)
            {
                foreach (int element in row)
                {
                    Console.Write(element + "\t");
                }
                Console.WriteLine();
            }
        }
        Console.Read();
    }
}
