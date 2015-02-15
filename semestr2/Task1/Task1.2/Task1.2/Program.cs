using System;

namespace Task1._2
{
    class Program
    {
        static int Fibonacci(int indexOfNumber)
        {
            if (indexOfNumber < 0)
            {
                return -1;
            }
            int previous = 1;
            int result = 1;
            for (int i = 2; i <= indexOfNumber; ++i)
            {
                int temp = result;
                result = result + previous;
                previous = temp; 
            }
            return result;
        }
        static void Main(string[] args)
        {
            System.Console.WriteLine("A[n] - Fibonacci sequence. Enter the 'n'. Numeration begins with 0.");
            int number = System.Int32.Parse(System.Console.ReadLine());
            int result = Fibonacci(number);
            System.Console.WriteLine("A[{0}] = {1}", number, result);
        }
    }
}
