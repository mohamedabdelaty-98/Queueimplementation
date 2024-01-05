using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Queueimplementation.QueueUsingLinkedList
{
    internal class QueueLinkedList<T>
    {
        Node<T> First;
        Node<T> Last;
        public int Count { get; set; }
        public QueueLinkedList()
        {
            First = Last = null;
            Count = 0;
        }
        private bool IsEmpty()=> Count== 0;
        public void Enqueue(T item)
        {
            Node<T> newnode = new Node<T>();
            newnode.Value = item;
            if(!IsEmpty())
            {
                Last.Next = newnode;
                Last = newnode;
                Count++;
            }
            else
            {
                Last=First=newnode;
                Count++;
            }
        }
        public T Dequeue()
        {
            if (IsEmpty())
                throw new Exception("Queue is Empty");
            if (First == null)
                Last = null;

            T data = First.Value;
            First = First.Next;
            Count--;
            return data;
        }
        public T Peek()
        {
            if (!IsEmpty())
                return First.Value;
            else
                throw new Exception("Queue is empty");
        }
    }
}
