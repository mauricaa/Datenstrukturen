using Common;
using System;
using System.Collections.Generic;

namespace Datastucture
{
    public class DoppeltVerketteteListe<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }

        public void AddLast(T data)
        {
            DoubleNode<T> newNode = new DoubleNode<T> { Data = data };

            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                newNode.Previous = Tail;
                Tail.Next = newNode;
                Tail = newNode;
            }
        }

        public void InsertBefore(T elementAfter, T elementToInsert)
        {
            DoubleNode<T> newNode = new DoubleNode<T> { Data = elementToInsert };

            if (Head == null)
                throw new ArgumentException("Element not found in list");

            if (EqualityComparer<T>.Default.Equals(Head.Data, elementAfter))
            {
                newNode.Next = Head;
                Head.Previous = newNode;
                Head = newNode;
                return;
            }

            DoubleNode<T> current = Head;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, elementAfter))
                {
                    newNode.Next = current;
                    newNode.Previous = current.Previous;
                    if (current.Previous != null)
                        current.Previous.Next = newNode;
                    current.Previous = newNode;
                    return;
                }
                current = current.Next;
            }

            throw new ArgumentException("Element not found in list");
        }

        public int InsertAfter(T elementBefore, T elementToInsert)
        {
            DoubleNode<T> newNode = new DoubleNode<T> { Data = elementToInsert };
            int index = 0;

            DoubleNode<T> current = Head;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, elementBefore))
                {
                    newNode.Next = current.Next;
                    newNode.Previous = current;

                    if (current.Next != null)
                        current.Next.Previous = newNode;
                    else
                        Tail = newNode;

                    current.Next = newNode;
                    return index + 1;
                }

                current = current.Next;
                index++;
            }

            throw new ArgumentException("Element not found in list");
        }

        public int PosOfElement(T element)
        {
            DoubleNode<T> current = Head;
            int index = 0;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, element))
                    return index;

                current = current.Next;
                index++;
            }

            return -1;
        }
    }
}
