using System;

namespace Task2._4
{
    /// <summary>
    /// Стековый калькулятор, вычисляющий постфиксное выпажение
    /// </summary>
    public static class StackCalculator
    {
        /// <summary>
        /// Определяем, является ли символ знаком операции.
        /// </summary>
        private static bool IsOrerator(char symbol)
        {
            return symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/';
        }

        /// <summary>
        /// Считаем бинарную операцию
        /// </summary>
        private static int Operation(int operand1, int operand2, char action)
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
                if (operand2 == 0)
                {
                    throw new DividingByZeroException("Dividing by zero.");
                }
                return operand1 / operand2;
            }
            throw new WrongExpressionException("It's not binary operation.");
        }

        /// <summary>
        /// Считаем постфиксное выражение с помощью стека
        /// </summary>
        public static int Calculate(string postfixExpression, Stack<int> stack)
        {
            for (int i = 0; i < postfixExpression.Length; ++i)
            {
                if (Char.IsLetter(postfixExpression[i]))
                {
                    throw new WrongExpressionException("Letters in expression.");
                }
            }
            Console.Write("{0} = ", postfixExpression);
            string[] values = postfixExpression.Split(' ');
            for (int i = 0; i < values.Length; ++i)
            {
                if (IsOrerator(values[i][0]))
                {
                    const int size = 2;
                    int[] operands = new int[size];
                    for (int j = 0; j < 2; ++j)
                    {
                        if (stack.IsEmpty())
                        {
                            throw new WrongExpressionException("Few numbers.");
                        }
                        operands[j] = stack.Pop();
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
                throw new WrongExpressionException("Many numbers.");
            }
            else
            {
                return result;
            }
        }

    }
}
