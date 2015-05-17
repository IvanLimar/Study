using System;

namespace Task2._4
{
    /// <summary>
    /// Абстрактный класс стек
    /// </summary>
    public abstract class Stack<Type>
    {
        /// <summary>
        /// Проверяет, пуст ли стек
        /// </summary>
        public abstract bool IsEmpty();

        /// <summary>
        /// Кладем в стек число
        /// </summary>
        public abstract void Push(Type value);

        /// <summary>
        /// Извлекаем из стека число.
        /// </summary>
        /// <returns></returns>
        public abstract Type Pop();
    }
}
