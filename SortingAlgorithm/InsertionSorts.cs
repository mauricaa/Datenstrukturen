using Common;

namespace SortingAlgorithm
{
    public class InsertionSorts<T> : ISortAlgorithm<T> where T : IComparable<T>
    {
        public void Sort(Node<T> head)
        {
            if (head == null || head.Next == null)
                return;

            Node<T> i = head.Next;

            while (i != null)
            {
                Node<T> j = head;
                Node<T> nextI = i.Next;

                while (j != i && j.Data.CompareTo(i.Data) > 0)
                {
                    T temp = j.Data;
                    j.Data = i.Data;
                    i.Data = temp;

                    j = j.Next;
                }

                i = nextI;
            }
        }
    }
}