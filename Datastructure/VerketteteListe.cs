using Common;

namespace Datastucture
{
    public class VerketteteListe
    {
        public Node Head;
        public void Addlast(object data)
        {
            Node toAdd = new Node();
            toAdd.Data = data;
            if (Head == null)
            {
                Head = new Node();
                Head.Next = toAdd;
            }
            else
            {
                Node current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = toAdd;
            }
        }
        public bool CheckForObject(object toFind)
        {
            Node current = Head;
            while (current.Next != null)
            {
                current = current.Next;
                if (current.Data == toFind)
                    return true;
            }
            return false;
        }

    }
}

