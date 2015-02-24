using System;

namespace Task2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();
            for (int i = 0; i < 10; ++i)
            {
                stack.Push(i);
            }
            while (!stack.IsEmpty())
            {
                stack.Pop();
            }
        }
    }
}
