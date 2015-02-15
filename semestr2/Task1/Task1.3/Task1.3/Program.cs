using System;

namespace Task1._3
{
    class Program
    {
        //Минимальный элемент массива станет на позицию leftBorder
        static void MoveMinimum(int[] numbers, int leftBorder, int rightBorder, int size)
        {
            if (leftBorder < 0 || rightBorder >= size)
            {
                return;
            }
            int indexOfMinimum = leftBorder;
            for (int i = leftBorder; i < rightBorder; ++i)
            {
                if (numbers[i + 1] < numbers[indexOfMinimum])
                {
                    indexOfMinimum = i + 1;
                }
            }
            int temp = numbers[leftBorder];
            numbers[leftBorder] = numbers[indexOfMinimum];
            numbers[indexOfMinimum] = temp;
        }

        static void SelectionSort(int[] numbers, int size)
        {
            for (int i = 0; i < size; ++i)
            {
                MoveMinimum(numbers, i, size - 1, size);
            }
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("Enter the size of array:");
            int size = System.Int32.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Enter numbers:");
            int[] numbers = new int[size];
            for (int i = 0; i < size; ++i)
            {
                System.Console.Write("A[{0}] = ", i);
                numbers[i] = System.Int32.Parse(System.Console.ReadLine());
            }
            SelectionSort(numbers, size);
            System.Console.WriteLine("Result of sort:");
            for (int i = 0; i < size; ++i)
            {
                System.Console.WriteLine("A[{0}] = {1}", i, numbers[i]);
            }
        }
    }
}
