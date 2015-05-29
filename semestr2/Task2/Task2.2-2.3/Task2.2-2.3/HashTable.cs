using System;

namespace TaskListHashTable
{
    /// <summary>
    /// Класс хеш-таблица. Можно добавлять, удалять и проверять на принадлежность хеш-таблице.
    /// </summary>
    public class HashTable
    {
        private List[] lists;

        private Func<string, int> hashFunction;

        public Func<string, int> Function
        {
            get { return hashFunction; }
        }

        public int Length { get; set; }

        /// <summary>
        /// Конструктор, создающий хеш-таблицу.
        /// </summary>
        /// <param name="length"> length - длина хеш таблицы.</param>
        public HashTable(int length)
        {
            if (length < 0)
            {
                Length = 100;
            }
            else
            {
                Length = length;
            }
            hashFunction = (string line) =>
            {
                return HashFunction.Value(line) % Length;
            };
            lists = new List[length];
            for (int i = 0; i < length; ++i)
            {
                lists[i] = new List();
            }
        }

        /// <summary>
        /// Смена хеш-функции.
        /// </summary>
        public void ChangeHash(Func<string, int> newHashFunction)
        {
            hashFunction = (string line) =>
            {
                return newHashFunction(line) % Length;
            };
            Rebuild();
        }

        /// <summary>
        /// Перестройка хеш-таблицы после смены хеш-функции.
        /// </summary>
        private void Rebuild()
        {
            List temp = new List();
            for (int i = 0; i < Length; ++i)
            {
                int j = 0;
                while (j < lists[i].Length())
                {
                    temp.Add(lists[i].GetValue(j++));
                }
            }
            Clear();
            for (int i = 0; i < temp.Length(); ++i)
            {
                Add(temp.GetValue(i));
            }
        }

        /// <summary>
        /// Удаляем все содержимое хеш-таблицы
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < Length; ++i)
            {
                lists[i] = new List();
            }
        }

        /// <summary>
        /// Добавление в хеш-таблицу
        /// </summary>
        public void Add(string element)
        {
            int index = hashFunction(element);
            lists[index].Add(element);
        }

        /// <summary>
        /// Проверка на принадлежность.
        /// </summary>
        public bool Contains(string element)
        {
            int index = hashFunction(element);
            return lists[index].Contains(element);
        }

        /// <summary>
        /// Удаление из хеш-функции.
        /// </summary>
        public void Delete(string element)
        {
            int index = hashFunction(element);
            lists[index].Delete(element);
        }
    }
}
