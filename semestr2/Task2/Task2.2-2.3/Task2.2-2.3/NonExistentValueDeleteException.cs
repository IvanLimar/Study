using System;

namespace TaskListHashTable
{
    /// <summary>
    /// Исключение бросается при попытке удалить из списка несуществующий элемент.
    /// </summary>
    public class NonExistentValueDeleteException : ApplicationException
    {
        public NonExistentValueDeleteException(string message)
            : base(message)
        {
        }
    }
}
