using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue queue = new PriorityQueue();
            for (int i = 0; i < 10; ++i)
            {
                queue.Enqueue(i, i % 2);
            }
            for (int i = 0; i < 15; ++i)
            {
                try
                {
                    Console.WriteLine(queue.Dequeue());
                }
                catch (NullExpection expection)
                {
                    Console.WriteLine(expection.Message);
                }
            }
        }
    }
}
