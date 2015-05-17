using System.Collections;

namespace MyList
{
    /// <summary>
    /// Энумератор, позволяющий ходить по MyList<Type> циклом foreach
    /// </summary>
    public class MyListEnumerator<Type> : IEnumerator
    {
        private MyList<Type> list;
        private int index = -1;

        public MyListEnumerator(MyList<Type> list)
        {
            this.list = list;
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public Type Current
        {
            get { return list[index]; }
        }

        public void Reset()
        {
            index = -1;
        }

        public bool MoveNext()
        {
            ++index;
            return index < list.Count;
        }
    }
}
