using System.Collections.Generic;
using System.Collections;

namespace Set
{
    /// <summary>
    /// Множество. Можно добавлять, удалять, проверять на принадлежность.
    /// Монжо объединять и пересекать два множества.
    /// </summary>
    public class Set<Type> : IEnumerable
    {
        private List<Type> list;

        public Set()
        {
            list = new List<Type>();
        }

        /// <summary>
        /// Добавляем в множество item, если его нет.
        /// </summary>
        public void Add(Type item)
        {
            if (!list.Contains(item))
            {
                list.Add(item);
            }
        }

        /// <summary>
        /// Удаляет item.
        /// </summary>
        public void Delete(Type item)
        {
            list.Remove(item);
        }

        /// <summary>
        /// Возвращает true, если есть item
        /// </summary>
        public bool Contains(Type item)
        {
            return list.Contains(item);
        }

        /// <summary>
        /// Возвращает множество, полученное пересечением firstSet и secondSet.
        /// </summary>
        public static Set<Type> Intersection(Set<Type> firstSet, Set<Type> secondSet)
        {
            Set<Type> result = new Set<Type>();
            foreach (var x in firstSet.list)
            {
                if (secondSet.Contains(x))
                {
                    result.Add(x);
                }
            }
            return result;
        }

        /// <summary>
        /// Возвращает множество, полученное объединением firstSet и secondSet.
        /// </summary>
        public static Set<Type> Union(Set<Type> firstSet, Set<Type> secondSet)
        {
            Set<Type> result = firstSet;
            foreach (var x in secondSet.list)
            {
                if (!firstSet.Contains(x))
                {
                    result.Add(x);
                }
            }
            return result;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumenator() as IEnumerator;
        }

        SetEnumerator<Type> GetEnumenator()
        {
            return new SetEnumerator<Type>(list);
        }
    }
}
