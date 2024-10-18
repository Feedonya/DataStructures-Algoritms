using System;

class Program
{
    static void Main()
    {
        // Ввод количества строк
        Console.Write("Введите количество строк: ");
        int rows = Convert.ToInt32(Console.ReadLine());

        // Инициализация ступенчатого массива
        int[][] jaggedArray = new int[rows][];

        // Ввод строк разной длины и их элементов
        for (int i = 0; i < rows; i++)
        {
            Console.Write($"Введите количество элементов в строке {i + 1}: ");
            int cols = Convert.ToInt32(Console.ReadLine());
            jaggedArray[i] = new int[cols];

            for (int j = 0; j < cols; j++)
            {
                Console.Write($"Элемент [{i},{j}]: ");
                jaggedArray[i][j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        // Массив для хранения максимальных элементов каждой строки
        int[] maxElements = new int[rows];

        // Поиск максимальных элементов в каждой строке
        for (int i = 0; i < rows; i++)
        {
            int maxInRow = jaggedArray[i][0]; // Первый элемент строки как начальный максимум

            for (int j = 1; j < jaggedArray[i].Length; j++)
            {
                if (jaggedArray[i][j] > maxInRow)
                {
                    maxInRow = jaggedArray[i][j]; // Находим максимальный элемент
                }
            }

            maxElements[i] = maxInRow; // Записываем максимальный элемент строки
        }

        // Вывод массива максимальных элементов
        Console.WriteLine("Максимальные элементы каждой строки:");
        for (int i = 0; i < maxElements.Length; i++)
        {
            Console.WriteLine($"Строка {i + 1}: {maxElements[i]}");
        }
    }
}
