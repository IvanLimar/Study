using System;

namespace Task2._2_2._3
{
    public class List
    {
        private int length;

        private class ListElement
        {
            public ListElement next;
            public ListElement previous;
            public string value;
        }

        private ListElement head;
        private ListElement tail;

        public List()
        {
            this.head = null;
            this.tail = null;
            this.length = 0;
        }

        public List(ref string element)
        {
            this.Add(ref element);
        }

        public int Length()
        {
            return this.length;
        }

        public bool IsEmpty()
        {
            return this.head == null;
        }

        public void Add(ref string element)
        {
            ListElement newElement = new ListElement();
            newElement.value = element;
            newElement.next = null;
            newElement.previous = this.tail;
            ++this.length;
            if (this.IsEmpty())
            {
                this.head = newElement;
                this.tail = newElement;
                return;
            }
            this.tail.next = newElement;
            this.tail = newElement;
        }

        public bool IsContain(ref string element)
        {
            ListElement temp = new ListElement();
            temp = this.head;
            while (temp != null)
            {
                if (element == temp.value)
                {
                    return true;
                }
                temp = temp.next;
            }
            return false;
        }

        public void Delete(ref string element)
        {
            ListElement temp = new ListElement();
            temp = this.head;
            while (temp != null)
            {
                if (element == temp.value)
                {
                    --this.length;
                    if (temp.next == null && temp.previous == null)
                    {
                        this.head = null;
                        this.tail = null;
                    }
                    else
                    {
                        if (temp.next == null)
                        {
                            temp.previous.next = null;
                            this.tail = temp.previous;
                            return;
                        }
                        if (temp.previous == null)
                        {
                            temp.next.previous = null;
                            this.head = temp.next;
                            return;
                        }
                        temp.previous.next = temp.next;
                        temp.next.previous = temp.previous;
                    }
                    return;
                }
                temp = temp.next;
            }
            Console.WriteLine("Element wasn't found.");
        }

    }
}
