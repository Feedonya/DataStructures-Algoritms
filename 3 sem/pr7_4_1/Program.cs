using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr7_6
{
    internal class Program
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

            int[] maxElements = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int maxInRow = jaggedArray[i][0];

                for (int j = 1; j < jaggedArray[i].Length; j++)
                {
                    if (jaggedArray[i][j] > maxInRow)
                    {
                        maxInRow = jaggedArray[i][j];
                    }
                }

                maxElements[i] = maxInRow; 
            }

            Console.WriteLine("Максимальные элементы каждой строки:");
            for (int i = 0; i < maxElements.Length; i++)
            {
                Console.WriteLine($"Строка {i + 1}: {maxElements[i]}");
            }
            Console.Read();
        }
    }
}