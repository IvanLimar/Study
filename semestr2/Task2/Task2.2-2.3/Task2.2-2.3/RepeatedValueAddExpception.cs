using System;

namespace TaskListHashTable
{
    /// <summary>
    /// Исключение бросается при попытке добавить в UniqueList элемент, который уже есть в UniqueList.
    /// </summary>
    public class RepeatedValueAddExpception : ApplicationException
    {
        public RepeatedValueAddExpception(string message)
            : base(message)
        {
        }
    }
}
