using System;

namespace Task2._2_2._3
{
    public class AddictionPresentValueException : ApplicationException
    {
        public AddictionPresentValueException()
        {
        }

        public AddictionPresentValueException(string message) : base(message)
        {
        }
    }

    public class DeletingNotPresentValueException : ApplicationException
    {
        public DeletingNotPresentValueException()
        {
        }

        public DeletingNotPresentValueException(string message)
            : base(message)
        {
        }
    }
}
