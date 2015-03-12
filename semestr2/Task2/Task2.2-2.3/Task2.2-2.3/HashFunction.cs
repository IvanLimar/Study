using System;

namespace Task2._2_2._3
{
    public static class HashFunction
    {
        /// <summary>
        /// Хеш-функция
        /// </summary>
        public static int Value(HashTable hashTable, string line)
        {
            int length = hashTable.Length;
            int result = 0;
            for (int i = 0; i < line.Length; ++i)
            {
                int number = Convert.ToInt32(line[i]);
                double temp = Math.Pow(number, i) % length;
                result = result + Convert.ToInt32(temp);

            }
            return result % length;
        }
    }
}
