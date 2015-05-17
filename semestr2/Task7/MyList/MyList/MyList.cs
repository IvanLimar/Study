using System;
using System.Collections.Generic;
using System.Collections;

namespace MyList
{
    /// <summary>
    /// Генериковый список со значениями типа Type.
    /// </summary>
    public class MyList<Type> : IList<Type>
    {
        public bool IsReadOnly
        {
            get { return false; }
        }

        public int Count
        {
            get { return count; }
        }

        /// <summary>
        /// Возвращает или задает элемент списка с номером index.
        /// index > 0, index < Count
        /// </summary>
        public Type this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                MyListElement temp = head;
                for (int i = 0; i < index; ++i)
                {
                    temp = temp.Next;
                }
                return temp.Value;
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                MyListElement temp = head;
                for (int i = 0; i < index; ++i)
                {
                    temp = temp.Next;
                }
                temp.Value = value;
            }
        }

        private int count = 0;
        private MyListElement head;
        private MyListElement tail;

        private class MyListElement
        {
            public MyListElement Previous { get; set; }
            public MyListElement Next { get; set;}
            public Type Value { get; set; } 
        }

        public MyList()
        {
        }

        /// <summary>
        /// добавление item в конец списка.
        /// </summary>
        public void Add(Type item)
        {
            ++count;
            MyListElement listElement = new MyListElement();
            listElement.Value = item;
            listElement.Previous = tail;
            if (tail == null)
            {
                head = listElement;
                tail = listElement;
                return;
            }
            tail.Next = listElement;
            tail = listElement;
        }

        /// <summary>
        /// Вставка item на позицию index.
        /// </summary>
        public void Insert(int index, Type item)
        {
            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (index == count)
            {
                Add(item);
                return;
            }
            ++count;
            MyListElement listElement = new MyListElement();
            listElement.Value = item;
            listElement.Next = head;
            if (index == 0)
            {
                head.Previous = listElement;
                head = listElement;
                return;
            }
            for (int i = 1; i < index + 1; ++i)
            {
                listElement.Next = listElement.Next.Next;
            }
            listElement.Next.Previous.Next = listElement;
            listElement.Previous = listElement.Next.Previous;
            listElement.Next.Previous = listElement;
        }

        /// <summary>
        /// Возвращает позицию, на которой находится item.
        /// Если item отсутствует, возввращает -1.
        /// </summary>
        public int IndexOf(Type item)
        {
            for (int i = 0; i < Count; ++i)
            {
                if (item.Equals(this[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Проверяет. есть ли item в списке.
        /// </summary>
        public bool Contains(Type item)
        {
            return IndexOf(item) >= 0;
        }

        /// <summary>
        /// На позиции index удаляет элемент.
        /// </summary>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException();
            }
            --count;
            MyListElement temp = head;
            for (int i = 0; i < index; ++i)
            {
                temp = temp.Next;
            }
            if (temp == head && temp == tail)
            {
                head = null;
                tail = null;
                return;
            }
            if (temp == head)
            {
                head = temp.Next;
                head.Previous = null;
                return;
            }
            if (temp == tail)
            {
                tail = temp.Previous;
                tail.Next = null;
                return;
            }
            temp.Previous.Next = temp.Next;
            temp.Next.Previous = temp.Previous;
        }

        /// <summary>
        /// Удаляет item, если он есть, и возвращает true, в противном случае - false.
        /// </summary>
        public bool Remove(Type item)
        {
            int index = IndexOf(item);
            bool result = index > -1;
            if (result)
            {
                RemoveAt(index);
            }
            return result;
        }

        /// <summary>
        /// Удаляет все элементы списка.
        /// </summary>
        public void Clear()
        {
            int length = count;
            for (int i = 0; i < length; ++i)
            {
                RemoveAt(0);
            }
        }

        /// <summary>
        /// В массив array c позиции startArrayIndex вставляет элементы списока.
        /// </summary>
        public void CopyTo(Type[] array, int startArrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            if (startArrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (array.Length - startArrayIndex < count)
            {
                throw new ArgumentException();
            }
            for (int i = 0; i < count; ++i)
            {
                array[startArrayIndex + i] = this[i];
            }
        }

        IEnumerator<Type> IEnumerable<Type>.GetEnumerator()
        {
            return GetEnumerator() as IEnumerator<Type>;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator() as IEnumerator;
        }

        public MyListEnumerator<Type> GetEnumerator()
        {
            return new MyListEnumerator<Type>(this);
        }
    }
}
