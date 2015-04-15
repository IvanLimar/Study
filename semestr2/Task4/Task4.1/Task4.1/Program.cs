using System;

namespace Task4_1
{
    /// <summary>
    /// Статический класс Symbol.
    /// </summary>
    public static class Symbol
    {
        /// <summary>
        /// Возвращает true, если symbol - знак арифметической операции, иначе - false.
        /// </summary>
        public static bool IsOperation(char symbol)
        {
            return symbol == '*' || symbol == '/' || symbol == '+' || symbol == '-';
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string expression = "(/ 2 0)";
                Tree tree = new Tree();
                ScanLine.Scan(ref tree, expression);
                string line = PrintTree.Print(tree);
                int result = CalculateTree.Calculate(tree);
                Console.WriteLine("= {0}", result);
            }
            catch (DividingByZeroExpection expection)
            {
                Console.WriteLine();
                Console.WriteLine(expection.Message);
            }
            catch (NullExpection expection)
            {
                Console.WriteLine();
                Console.WriteLine(expection.Message);
            }
            catch (OutBorderArrayExpection expection)
            {
                Console.WriteLine();
                Console.WriteLine(expection.Message);
            }
            catch (IllegalSymbolsExpection expection)
            {
                Console.WriteLine();
                Console.WriteLine(expection.Message);
            }
        }
    }
}
