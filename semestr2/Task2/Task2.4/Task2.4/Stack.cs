using System;

namespace Task2._4
{
    public abstract class Stack
    {
        public Stack()
        {

        }

        public Stack(int value)
        {

        }

        public abstract bool IsEmpty();

        public abstract void Push(int value);

        public abstract int Pop();
    }
}
