using System;

namespace Task2._4
{
    public class WrongExpressionException : ApplicationException
    {
        public WrongExpressionException(string message)
            : base(message)
        {
        }
    }
}
