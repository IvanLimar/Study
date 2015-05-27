using System;

namespace Task2._4
{
    public class EmptyStackException : ApplicationException
    {
        public EmptyStackException(string message)
            : base(message)
        {
        }
    }
}
