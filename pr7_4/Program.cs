using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr7_4
{
    internal class Program
    {
        static void Main()
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
                    Console.Write($"Элемент {i},{j}: ");
                    array[i, j] = int.Parse(Console.ReadLine());
                }
            }

            int[] maxElements = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int maxInRow = array[i, 0]; 

                for (int j = 1; j < cols; j++)
                {
                    if (array[i, j] > maxInRow)
                    {
                        maxInRow = array[i, j];
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



//3  5  1  7
//2  9  8  6
//4  0  3 10