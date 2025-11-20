using Common;
using System;
using System.Collections.Generic;
namespace Datastucture
{
    public class EinzelnVerketteteListe<T>
    {
        public Node<T> Head { get; set; }
        public void AddLast(T data)
        {
            Node<T> toAdd = new Node<T> { Data = data };
            if (Head == null)
            {
                Head = toAdd;
            }
            else
            {
                Node<T> current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = toAdd;
            }
        }
        public void InsertBefore(T elementAfter, T elementToInsert)
        {
            Node<T> newNode = new Node<T> { Data = elementToInsert };
            if (Head != null && EqualityComparer<T>.Default.Equals(Head.Data, elementAfter))
            {
                newNode.Next = Head;
                Head = newNode;
                return;
            }
            Node<T> current = Head;
            while (current != null && current.Next != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Next.Data, elementAfter))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return;
                }
                current = current.Next;
            }
            throw new ArgumentException("Element not found in list");
        }
        public int InsertAfter(T elementBefore, T elementToInsert)
        {
            Node<T> newNode = new Node<T> { Data = elementToInsert };
            int index = 0;
            Node<T> current = Head;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, elementBefore))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return index + 1;
                }
                current = current.Next;
                index++;
            }
            return -1;
        }
        public int PosOfElement(T element)
        {
            Node<T> current = Head;
            int index = 0;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, element))
                {
                    return index;
                }
                current = current.Next;
                index++;
            }
            return -1;
        }
    }
}
//Alle drei Methoden haben die Laufzeitkomplexität O(n),
//da im Worst Case die gesamte Liste durchsucht werden muss