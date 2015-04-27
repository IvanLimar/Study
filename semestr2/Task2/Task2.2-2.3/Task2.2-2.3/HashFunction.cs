using System;

namespace TaskListHashTable
{
    public static class HashFunction
    {
        /// <summary>
        /// Хеш-функция
        /// </summary>
        public static int Value(string line)
        {
            int result = 0;
            for (int i = 0; i < line.Length; ++i)
            {
                int number = Convert.ToInt32(line[i]);
                double temp = Math.Pow(number, i);
                result = result + Convert.ToInt32(temp);

            }
            return result;
        }
    }
}
