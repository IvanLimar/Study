using System;

namespace Task2._4
{
    /// <summary>
    /// Бросается исключение, если происходит деление на ноль.
    /// </summary>
    public class DividingByZeroException : ApplicationException
    {
        public DividingByZeroException(string message)
            : base(message)
        {
        }
    }
}
