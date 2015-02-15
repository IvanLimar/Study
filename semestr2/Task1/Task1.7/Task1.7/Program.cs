using System;

namespace Task1._7
{
    class Program
    {
        static void Initsalization(int[,] matrix, int hight, int length)
        {
            Random random = new Random();
            for (int i = 0; i < hight; ++i)
            {
                for (int j = 0; j < length; ++j)
                {
                    matrix[i, j] = random.Next(10, 99);
                }
            }
        }

        static void Print(int[,] matrix, int hight, int length)
        {
            for (int i = 0; i < hight; ++i)
            {
                for (int j = 0; j < length; ++j)
                {
                    System.Console.Write("{0} ", matrix[i, j]);
                }
                System.Console.WriteLine();
            }
        }

        //Минимальный столбец матрицы станет на позицию leftBorder
        static void MoveMinimum(int[,] numbers, int leftBorder, int rightBorder, int hight, int length)
        {
            if (leftBorder < 0 || rightBorder >= length)
            {
                return;
            }
            int indexOfMinimum = leftBorder;
            const int firstLine = 0;
            for (int i = leftBorder; i < rightBorder; ++i)
            {
                if (numbers[firstLine, i + 1] < numbers[firstLine, indexOfMinimum])
                {
                    indexOfMinimum = i + 1;
                }
            }
            for (int i = 0; i < hight; ++i)
            {
                int temp = numbers[i, leftBorder];
                numbers[i, leftBorder] = numbers[i, indexOfMinimum];
                numbers[i, indexOfMinimum] = temp;
            }
        }

        static void SelectionSort(int[,] numbers, int hight, int length)
        {
            for (int i = 0; i < length; ++i)
            {
                MoveMinimum(numbers, i, length - 1, hight, length);
            }
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("Enter the hight and length of matrix:");

            System.Console.Write("Hight = ");
            int hight = System.Int32.Parse(System.Console.ReadLine());

            System.Console.Write("Length = ");
            int length = System.Int32.Parse(System.Console.ReadLine());

            int[,] matrix = new int[hight, length];

            Initsalization(matrix, hight, length);

            Print(matrix, hight, length);
            System.Console.WriteLine();
            SelectionSort(matrix, hight, length);

            Print(matrix, hight, length);
        }
    }
}
