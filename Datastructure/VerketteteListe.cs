using Common;
using System.Collections.Generic;

namespace Datastucture
{
    public class VerketteteListe<T>
    {
        public Node<T> Head { get; set; }
        public void Addlast(T data)
        {
            Node<T> toAdd = new Node<T> { Data = data };
            if (Head == null)
            {
                Head.Next = toAdd;
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
        public bool CheckForObject(T toFind)
        {
            Node<T> current = Head;
            while (current.Next != null)
            {
                if (current.Data != null && EqualityComparer<T>.Default.Equals(current.Data, toFind))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
    }
}