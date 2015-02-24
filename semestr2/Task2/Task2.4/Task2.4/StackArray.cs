using System;

namespace Task2._4
{
    public class StackArray : Stack
    {
        private int[] array;

        public StackArray()
        {
            this.array = new int[0];
        }

        public StackArray(int value)
        {
            this.array = new int[1];
            this.array[0] = value;
        }

        public override bool IsEmpty()
        {
            return this.array.Length == 0;
        }

        public override void Push(int value)
        {
            int index = this.array.Length;
            Array.Resize(ref this.array, index + 1);
            this.array[index] = value;
        }

        public override int Pop()
        {
            if (this.IsEmpty())
            {
                Console.WriteLine("Stack is empty!");
                return -9999;
            }
            int newSize = array.Length - 1;
            int result = this.array[newSize];
            Array.Resize(ref this.array, newSize);
            return result;
        }
    }
}
