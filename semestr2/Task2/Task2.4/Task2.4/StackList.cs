using System;

namespace Task2._4
{
    /// <summary>
    ///  Класс стек, реализованный на списках.
    /// </summary>
    public class StackList : Stack
    {
        /// <summary>
        /// Элемент стека.
        /// </summary>
        private class StackElement
        {
            private int _value;
            public int Value
            {
                get
                {
                    return _value;
                }
                set
                {
                    _value = value;
                }
            }

            public StackElement Next { get; set; }
        }

        private StackElement head = null;

        /// <summary>
        /// Конструктор, создающий пустой стек.
        /// </summary>
        public StackList()
        {
            
        }

        /// <summary>
        /// Кладем элемет в стек.
        /// </summary>
        public override void Push(int element)
        {
            StackElement newElement = new StackElement();
            newElement.Value = element;
            newElement.Next = head;
            head = newElement;
        }

        /// <summary>
        /// Извлекаем элемент из стека.
        /// </summary>
        public override int Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty!");
                return -9999;
            }
            int result = head.Value;
            this.head = head.Next;
            return result;
        }

        /// <summary>
        /// Проверяем, пуст ли стек. 
        /// </summary>
        public override bool IsEmpty()
        {
            return head == null;
        }
    }
        
}
