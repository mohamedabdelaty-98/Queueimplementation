using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queueimplementation
{
    internal class QueueImplementation<T>
    {
        T[] arr;
        int first,last,size;
        public int count { get; private set; }
        public QueueImplementation(int size=5)
        {
            this.size = size <= 0 ? 5 : size;
            this.arr = new T[size];
            this.first = 0;
            this.last = size - 1; 
            this.count = 0;
        }
        private bool IsEmpty()=> count == 0;
        private bool IsFull() => count == size;
        private void Extend(int size)
        {
            this.size=size;
            T[]newarr=new T[size];
            Array.Copy(arr, newarr, arr.Length);
            arr = newarr;
        }
        public void Enqueue(T item)
        {
            if (!IsFull())
            {
                last = (last + 1) % size;
                arr[last] = item;
                count++;
            }
            else
            {
                Extend(size * 2);
                last = (last + 1) % size;
                arr[last] = item;
                count++;
            }
        }
        public T Dequeue()
        {
            if (!IsEmpty())
            {
                T item = arr[first];
                first = (first + 1) % size;
                count--;
                return item;
            }
            else
                throw new Exception("Queue is empty");
        }
        public T Peek()
        {
            if (!IsEmpty())
                return arr[first];
            else
                throw new Exception("Queue is empty");
        }
    }
}
