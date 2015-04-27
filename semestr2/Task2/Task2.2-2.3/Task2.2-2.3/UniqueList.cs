using System;

namespace TaskListHashTable
{
    /// <summary>
    /// Список без повторяющихся элементов
    /// </summary>
    public class UniqueList : List
    {
        /// <summary>
        /// Клнструктор, создающий пустой список.
        /// </summary>
        public UniqueList() : base()
        {
        }

        /// <summary>
        /// Конструктор, создающий список с одним элементом.
        /// </summary>
        public UniqueList(string value) : base(value)
        {
        }

        /// <summary>
        /// Добавление элемента в конец списка, если его не было в списке.
        /// </summary>
        public override void Add(string value)
        {
            if (Contains(value))
            {
                throw new RepeatedValueAddExpception("List contains element.");
            }
            base.Add(value);
        }
    }
}
