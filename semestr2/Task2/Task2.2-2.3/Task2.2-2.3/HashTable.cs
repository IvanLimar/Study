using System;

namespace Task2._2_2._3
{
    class HashTable
    {
        private int length;

        private List[] lists;

        private int HashFunctinon(ref string element)
        {
            int result = 0;
            for (int i = 0; i < element.Length; ++i)
            {
                int number = Convert.ToInt32(element[i]);
                double temp = Math.Pow(number, i) % this.length;
                result = result + Convert.ToInt32(temp);
                
            }
            return result % this.length;
        }

        public HashTable(int length)
        {
            this.length = length;
            this.lists = new List[length];
            for (int i = 0; i < length; ++i)
            {
                this.lists[i] = new List();
            }
        }

        public void Add(ref string element)
        {
            int index = this.HashFunctinon(ref element);
            this.lists[index].Add(ref element);
        }

        public bool IsContain(ref string element)
        {
            int index = this.HashFunctinon(ref element);
            return this.lists[index].IsContain(ref element);
        }

        public void Delete(ref string element)
        {
            int index = this.HashFunctinon(ref element);
            this.lists[index].Delete(ref element);
        }
    }
}
