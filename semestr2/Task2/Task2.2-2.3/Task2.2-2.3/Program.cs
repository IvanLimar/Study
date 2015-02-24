using System;

namespace Task2._2_2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            List list = new List();
            string a = "a";
            list.Add(ref a);
            list.Delete(ref a);
            for (int i = 0; i < 10; ++i)
            {
                string temp = i.ToString();
                list.Add(ref temp);
            }
            

            const int length = 10;
            HashTable hashTable = new HashTable(length);

        }
    }
}
