using System;
using System.CodeDom.Compiler;

class Program
{
	static void Main()
	{
		Console.Write("Введите количество строк: ");
		int rows = int.Parse(Console.ReadLine());

		int[][] jaggedArray = new int[rows][];
		//int temp = 0;

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
                //temp += 1;
            }

			if (!hasEven)
			{
				jaggedArray[i] = null;
                for (; i < rows - 1; i++)
				{
					jaggedArray[i] = jaggedArray[i + 1];
				}
				rows--; //уменьшаем текущее количество строк в массиве
			}
		}
        Console.WriteLine(rows);
        //rows -= temp;
        //Console.WriteLine(temp);
        //Console.WriteLine(rows);
        Console.WriteLine("Массив после удаления строк без чётных элементов:");
        for (int row = 0; row<rows-1; row++)
        //foreach (var row in jaggedArray)x	
        {
            //if (jaggedArray[row] != null)
            //if (row != null)
            {
                foreach (int element in jaggedArray[row])
                //foreach (int element in row)
                {
					Console.Write(element + "\t");
				}
				Console.WriteLine();
			}
		}
		Console.Read();
	}
}
