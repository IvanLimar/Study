using System;

namespace Task4_1
{
    /// <summary>
    /// Бросается исключение при попытке деления на ноль
    /// </summary>
    public class DividingByZeroException : ApplicationException
    {
        public DividingByZeroException(string message)
            : base(message)
        {
        }
    }
}
