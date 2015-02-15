using System;

namespace Task1._1
{
    class Program
    {
        static int Factorial(int number)
        {
            if (number < 0)
            {
                return -1;
            }
            if (number == 0 || number == 1)
            {
                return 1;
            }
            return number * Factorial(number - 1);
        }
        static void Main(string[] args)
        {
            System.Console.WriteLine("Enter the number:");
            int number = System.Int32.Parse(System.Console.ReadLine());
            int result = Factorial(number);
            System.Console.WriteLine("{0}! = {1}", number, result);
        }
    }
}
