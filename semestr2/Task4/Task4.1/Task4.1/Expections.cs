using System;

namespace Task4_1
{
    public class DividingByZeroExpection : ApplicationException
    {
        public DividingByZeroExpection()
        {
        }

        public DividingByZeroExpection(string message)
            : base(message)
        {
        }
    }

    public class OutBorderArrayExpection : ApplicationException
    {
        public OutBorderArrayExpection()
        {
        }

        public OutBorderArrayExpection(string message)
            : base(message)
        {
        }
    }

    public class NullExpection : ApplicationException
    {
        public NullExpection()
        {
        }

        public NullExpection(string message)
            : base(message)
        {
        }
    }

    public class IllegalSymbolsExpection : ApplicationException
    {
        public IllegalSymbolsExpection()
        {
        }

        public IllegalSymbolsExpection(string message)
            : base(message)
        {
        }
    }
}
