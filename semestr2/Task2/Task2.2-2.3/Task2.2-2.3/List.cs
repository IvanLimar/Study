using System;

namespace TaskListHashTable
{
    /// <summary>
    /// Класс список
    /// </summary>
    public class List
    {
        private int length = 0;

        /// <summary>
        /// Элемент списка.
        /// </summary>
        private class ListElement
        {
            public ListElement Next { get; set; }
            public ListElement Previous { get; set; }
            public string Value{ get; set; }
        }

        private ListElement head = null;
        private ListElement tail = null;

        /// <summary>
        /// Конструктор, создающий пустой список.
        /// </summary>
        public List()
        {        
        }

        /// <summary>
        /// Конструктор, создающий список с одним элементом
        /// </summary>
        public List(string element)
        {
            Add(element);
        }

        /// <summary>
        /// Возвращает длину списка
        /// </summary>
        public int Length()
        {
            return length;
        }

        /// <summary>
        /// Проверяем, пуст ли список.
        /// </summary>
        public bool IsEmpty()
        {
            return head == null;
        }

        /// <summary>
        /// Добавляем элемент в конец списка.
        /// </summary>
        public virtual void Add(string element)
        {
            ListElement newElement = new ListElement();
            newElement.Value = element;
            newElement.Next = null;
            newElement.Previous = tail;
            ++length;
            if (this.IsEmpty())
            {
                head = newElement;
                tail = newElement;
                return;
            }
            tail.Next = newElement;
            tail = newElement;
        }

        /// <summary>
        /// Проверяем, есть ли элемент в списке.
        /// </summary>
        public bool Contains(string element)
        {
            ListElement temp = new ListElement();
            temp = head;
            while (temp != null)
            {
                if (element == temp.Value)
                {
                    return true;
                }
                temp = temp.Next;
            }
            return false;
        }

        public string GetValue(int position)
        {
            if (position < 0 || position >= length)
            {
                return "";
            }
            ListElement temp = head;
            for (int i = 0; i < position; ++i)
            {
                temp = temp.Next;
            }
            return temp.Value;
        }

        /// <summary>
        /// Удаляем элемент из списка.
        /// </summary>
        public void Delete(string element)
        {
            ListElement temp = new ListElement();
            temp = head;
            while (temp != null)
            {
                if (element == temp.Value)
                {
                    --length;
                    if (temp.Next == null && temp.Previous == null)
                    {
                        head = null;
                        tail = null;
                    }
                    else
                    {
                        if (temp.Next == null)
                        {
                            temp.Previous.Next = null;
                            tail = temp.Previous;
                            return;
                        }
                        if (temp.Previous == null)
                        {
                            temp.Next.Previous = null;
                            head = temp.Next;
                            return;
                        }
                        temp.Previous.Next = temp.Next;
                        temp.Next.Previous = temp.Previous;
                    }
                    return;
                }
                temp = temp.Next;
            }
            throw new NonExistentValueDeleteException("List doesn't contain element");
        }
    }
}
