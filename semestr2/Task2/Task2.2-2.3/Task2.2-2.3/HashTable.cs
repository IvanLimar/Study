using System;

namespace Task2._2_2._3
{
    /// <summary>
    /// Класс хеш-таблица
    /// </summary>
    public class HashTable
    {
        private int length;

        private List[] lists;

        public int Length
        {
            get
            {
                return length;
            }
        }

        /// <summary>
        /// Конструктор, создающий хеш-таблицу.
        /// </summary>
        /// <param name="length"> length - длина хеш таблицы.</param>
        public HashTable(int length)
        {
            if (length < 0)
            {
                this.length = 100;
            }
            else
            {
                this.length = length;
            }
            lists = new List[length];
            for (int i = 0; i < length; ++i)
            {
                lists[i] = new List();
            }
        }

        /// <summary>
        /// Добавление в хеш-таблицу
        /// </summary>
        public void Add(string element)
        {
            int index = HashFunction.Value(this, element);
            lists[index].Add(element);
        }

        /// <summary>
        /// Проверка на принадлежность.
        /// </summary>
        public bool Contains(string element)
        {
            int index = HashFunction.Value(this, element);
            return lists[index].Contains(element);
        }

        /// <summary>
        /// Удаление из хеш-функции.
        /// </summary>
        public void Delete(string element)
        {
            int index = HashFunction.Value(this, element);
            lists[index].Delete(element);
        }
    }
}
