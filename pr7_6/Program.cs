using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr7_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество строк: ");
            int rows = int.Parse(Console.ReadLine());

            Console.Write("Введите количество столбцов: ");
            int cols = int.Parse(Console.ReadLine());

            int[,] array = new int[rows, cols];

            Console.WriteLine("Введите элементы массива:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"Элемент [{i},{j}]: ");
                    array[i, j] = int.Parse(Console.ReadLine());
                }
            }

            int newRowCount = 0;

            for (int i = 0; i < rows; i++)
            {
                bool hasEven = false;
                for (int j = 0; j < cols; j++)
                {
                    if (array[i, j] % 2 == 0)
                    {
                        hasEven = true;
                        break;
                    }
                }

                if (hasEven)
                {
                    if (newRowCount != i)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            array[newRowCount, j] = array[i, j];
                        }
                    }
                    newRowCount++;
                }
            }

            if (newRowCount == 0)
            {
                Console.WriteLine("Все строки были удалены.");
            }
            else
            {
                Console.WriteLine("Новый массив без строк без чётных элементов:");
                for (int i = 0; i < newRowCount; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Console.Write(array[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }
            Console.Read();
        }
    }
}