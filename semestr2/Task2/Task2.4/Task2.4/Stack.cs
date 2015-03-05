using System;

namespace Task2._4
{
    /// <summary>
    /// Абстрактный класс стек
    /// </summary>
    public abstract class Stack
    {
        /// <summary>
        /// Проверяет, пуст ли стек
        /// </summary>
        public abstract bool IsEmpty();

        /// <summary>
        /// Кладем в стек число
        /// </summary>
        public abstract void Push(int value);

        /// <summary>
        /// Извлекаем из стека число.
        /// </summary>
        /// <returns></returns>
        public abstract int Pop();
    }
}
