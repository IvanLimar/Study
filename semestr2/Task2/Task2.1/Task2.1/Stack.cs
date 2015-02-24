using System;

namespace Task2._1
{
    class Stack
    {
        private class StackElement
        {
            public int value;
            public StackElement next;
        }

        private StackElement head;

        public Stack()
        {
            this.head = null;
        }

        public Stack(int element)
        {
            StackElement newElement = new StackElement();
            this.head = newElement;
            newElement.next = null;
            newElement.value = element;
        }

        public void Push(int element)
        {
            StackElement newElement = new StackElement();
            newElement.value = element;
            newElement.next = this.head;
            this.head = newElement;
        }

        public int Pop()
        {
            if (this.IsEmpty())
            {
                Console.WriteLine("Stack is empty!");
                return -9999;
            }
            int result = this.head.value;
            this.head = this.head.next;
            return result;
        }

        public bool IsEmpty()
        {
            return this.head == null;
        }
    }
}
