using System;

namespace Task2._4
{
    class Program
    {
        /// <summary>
        /// Определяем, является ли символ знаком операции.
        /// </summary>
        static bool IsOrerator(char symbol)
        {
            return symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/';
        }

        /// <summary>
        /// Считаем бинарную операцию
        /// </summary>
        static int Operation(int operand1, int operand2, char action)
        {
            if (action == '+')
            {
                return operand1 + operand2;
            }
            if (action == '-')
            {
                return operand1 - operand2;
            }
            if (action == '*')
            {
                return operand1 * operand2;
            }
            if (action == '/')
            {
                return operand1 / operand2;
            }
            return -9999;
        }

        /// <summary>
        /// Считаем постфиксное выражение с помощью стека
        /// </summary>
        static int Calculate(string postfixExpression, Stack stack)
        {
            for (int i = 0; i < postfixExpression.Length; ++i)
            {
                if (Char.IsLetter(postfixExpression[i]))
                {
                    Console.WriteLine("Expression is wrong!");
                    return -9999;
                }
            }
            Console.Write("{0} = ", postfixExpression);
            string[] values = postfixExpression.Split(' ');
            for (int i = 0; i < values.Length; ++i)
            {
                if (IsOrerator(values[i] [0]))
                {
                    const int size = 2;
                    int[] operands = new int[size];
                    for (int j = 0; j < 2; ++j )
                    {
                        if (stack.IsEmpty())
                        {
                            Console.WriteLine("Expression is wrong!");
                            return -9999;
                        }
                        operands[j] = stack.Pop();
                    }
                    if (values[i] [0] == '/' && operands[0] == 0)
                    {
                        Console.WriteLine("Error! Dividing by zero!");
                        return -9999;
                    }
                    int number = Operation(operands[1], operands[0], values[i][0]);
                    stack.Push(number);
                }
                else
                {
                    stack.Push(Int32.Parse(values[i]));
                }
            }
            int result = stack.Pop();
            if (!stack.IsEmpty())
            {
                Console.WriteLine("Expression is wrong!");
                return -9999;
            }
            else
            {
                Console.WriteLine(result);
                return result;
            }          
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter postfix expression:");
            string expression = Console.ReadLine();
            Stack stack = new StackArray();
            Calculate(expression, stack);
        }
    }
}
