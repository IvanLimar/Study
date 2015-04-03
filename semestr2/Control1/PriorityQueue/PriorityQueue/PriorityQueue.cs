using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    /// <summary>
    /// PriorityQueue.
    /// </summary>
    public class PriorityQueue
    {
        private class QueueElement
        {
            public int Value { get; set; }
            public int Priority { get; set; }
            public QueueElement Next { get; set; }
        }

        private QueueElement head = null;

        /// <summary>
        /// Enqueue
        /// </summary>
        public void Enqueue(int value, int priority)
        {
            QueueElement newElement = new QueueElement();
            newElement.Priority = priority;
            newElement.Value = value;
            newElement.Next = head;
            head = newElement;
            QueueElement temp = head;
            while (temp.Next != null && temp.Priority <= temp.Next.Priority)
            {
                int temp2 = temp.Value;
                temp.Value = temp.Next.Value;
                temp.Next.Value = temp2;

                temp2 = temp.Priority;
                temp.Priority = temp.Next.Priority;
                temp.Next.Priority = temp2;

                temp = temp.Next;
            }
        }

        /// <summary>
        /// Dequeue
        /// </summary>
        public int Dequeue()
        {
            if (head == null)
            {
                throw new NullExpection("Queue is empty.");
            }
            int result = head.Value;
            head = head.Next;
            return result;
        }

    }
}
