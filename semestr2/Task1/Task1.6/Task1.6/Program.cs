using System;

namespace Task1._6
{
    class Program
    {
        static void Initsalization(int[,] matrix, int size)
        {
            Random random = new Random();
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    matrix[i, j] = random.Next(10, 99);
                    System.Console.Write("{0} ", matrix[i, j]);
                }
                System.Console.WriteLine();
            }
        }

        //Обход матрицы по спирали
        static void Spiral(int[,] matrix, int size)
        {
            int currentLine = (size - 1) / 2;
            int currentCulumn = (size - 1) / 2;
            int step = 0;
            System.Console.WriteLine("A[{0}, {1}] = {2}", currentLine, currentCulumn, matrix[currentLine, currentCulumn]);
            while (true)
            {
                for (int direction = 0; direction < 4; ++direction) // 0 - up, 1 - left, 2 - down, 3 -right.
                {
                    if (direction == 0 || direction == 2)
                    {
                        ++step;
                    }
                    for (int i = 0; i < step; ++i)
                    {
                        switch (direction)
                        {
                            case 0: 
                                --currentLine;
                                break;
                            case 1:
                                --currentCulumn;
                                break;
                            case 2:
                                ++currentLine;
                                break;
                            case 3:
                                ++currentCulumn;
                                break;
                            default:
                                break;
                        }
                        bool isBorder = (currentCulumn < 0) || (currentCulumn >= size) || (currentLine < 0) || (currentLine >= size);
                        if (isBorder)
                        {
                            return;
                        }
                        System.Console.WriteLine("A[{0}, {1}] = {2}", currentLine, currentCulumn, matrix[currentLine, currentCulumn]);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("Enter the size of matrix (n*n):");
            int size = System.Int32.Parse(System.Console.ReadLine());
            if (size % 2 == 0)
            {
                return;
            }
            int[,] matrix = new int[size, size];
            System.Console.WriteLine("Enter the numbers:");
            Initsalization(matrix, size);
            System.Console.WriteLine();
            Spiral(matrix, size);
        }
    }
}
