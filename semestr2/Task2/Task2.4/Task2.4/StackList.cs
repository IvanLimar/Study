using System;

namespace Task2._4
{
    public class StackList : Stack
    {
        private class StackElement
        {
            public int value;
            public StackElement next;
        }

        private StackElement head;

        public StackList()
        {
            this.head = null;
        }

        public StackList(int value)
        {
            StackElement newElement = new StackElement();
            this.head = newElement;
            newElement.next = null;
            newElement.value = value;
        }

        public override void Push(int value)
        {
            StackElement newElement = new StackElement();
            newElement.value = value;
            newElement.next = this.head;
            this.head = newElement;
        }

        public override int Pop()
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

        public override bool IsEmpty()
        {
            return this.head == null;
        }
    }
}
