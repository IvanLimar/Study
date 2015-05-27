using System;

namespace Task2._4
{
    /// <summary>
    /// Класс стек, реализованный на массивах
    /// </summary>
    public class StackArray<Type> : Stack<Type>
    {
        private Type[] array = new Type[100];

        private int length = 0;

        /// <summary>
        /// Создаем стек на массивах.
        /// </summary>
        public StackArray()
        {           
        }

        /// <summary>
        /// Проверяем, пуст ли стек.
        /// </summary>
        public override bool IsEmpty()
        {
            return length == 0;
        }

        /// <summary>
        /// Вставляем число в стек
        /// </summary>
        public override void Push(Type value)
        {
            if (length == array.Length)
            {
                Array.Resize(ref array, 2 * array.Length);
            }
            array[length] = value;
            ++length;
        }

        /// <summary>
        /// Извлекаем число из стека.
        /// </summary>
        public override Type Pop()
        {
            if (IsEmpty())
            {
                throw new EmptyStackException("Stack is empty.");
            }
            --length;
            Type result = array[length];
            return result;
        }
    }
}
