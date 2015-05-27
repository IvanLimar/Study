using System;
using System.Collections.Generic;
using System.Collections;

namespace Set
{
    /// <summary>
    /// Энуменатор. Позволяет по коллекции, которая "построена" на List<T>, ходить foreach
    /// </summary>
    public class SetEnumerator<Type> : IEnumerator
    {
        private List<Type> list;
        private int index = -1;

        public SetEnumerator(List<Type> list)
        {
            this.list = list;
        }

        public bool MoveNext()
        {
            ++index;
            return index < list.Count;
        }

        public void Reset()
        {
            index = -1;
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public Type Current
        {
            get
            {
                try
                {
                    return list[index];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
