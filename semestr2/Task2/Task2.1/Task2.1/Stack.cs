using System;

namespace Task2._1
{
    /// <summary>
    ///  Класс стек.
    /// </summary>
    public class Stack
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
        public Stack()
        {
            
        }

        /// <summary>
        /// Конструктор, создающий стек с одним элементом.
        /// </summary>
        public Stack(int element)
        {
            Push(element);
        }

        /// <summary>
        /// Кладем элемет в стек.
        /// </summary>
        public void Push(int element)
        {
            StackElement newElement = new StackElement();
            newElement.Value = element;
            newElement.Next = head;
            head = newElement;
        }

        /// <summary>
        /// Извлекаем элемент из стека.
        /// </summary>
        public int Pop()
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
        public bool IsEmpty()
        {
            return head == null;
        }
    }
}
