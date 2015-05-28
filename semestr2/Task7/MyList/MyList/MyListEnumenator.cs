using System.Collections;
using System.Collections.Generic;

namespace MyList
{
    public partial class MyList<T> : IList<T>
    {
        /// <summary>
        /// Энумератор, позволяющий ходить по MyList<Type> циклом foreach
        /// </summary>
        public class MyListEnumerator : IEnumerator
        {
            private MyList<T> list;
            private int index = -1;
            private MyListElement current;

            public MyListEnumerator(MyList<T> list)
            {
                this.list = list;
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public T Current
            {
                get { return current.Value; }
            }

            public void Reset()
            {
                index = -1;
                current = null;
            }

            public bool MoveNext()
            {
                if (index == -1)
                {
                    current = list.head;
                }
                else
                {
                    current = current.Next;
                }
                ++index;
                return index < list.Count;
            }
        }
    }
}
