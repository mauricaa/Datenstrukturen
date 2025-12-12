using System;
using System.Collections.Generic;
using Common;

namespace Datastucture
{
    public class Stack<T> where T : IComparable<T>
    {
        private DoppeltVerketteteListe<T> list = new DoppeltVerketteteListe<T>();

        public void Push(T item)
        {
            list.AddLast(item);
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack ist leer!");

            T item = Peek();

            if (list.Head == list.Tail)
            {

                list.Head = null;
                list.Tail = null;
            }
            else
            {
                list.Tail = list.Tail.Previous;
                list.Tail.Next = null;
            }

            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack ist leer!");

            return list.Tail.Data;
        }

        public int Count => list.Count();

        public bool IsEmpty() => list.Head == null;

        public List<T> ToList()
        {
            var result = new List<T>();
            Node<T> current = list.Head;
            while (current != null)
            {
                result.Add(current.Data);
                current = current.Next;
            }
            return result;
        }
    }
}