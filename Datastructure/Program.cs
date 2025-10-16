using Common;
using Datastucture;
using System;

namespace Datastucture
{
    class Program
    {
        static void Main()
        {
            VerketteteListe<int> list = new VerketteteListe<int>();
            list.AddLast(1);
            list.AddLast(3);
            list.AddLast(12);

            Console.WriteLine("Startliste:");
            PrintList(list);

            list.InsertBefore(3, 99);
            Console.WriteLine("Nach InsertBefore(3, 99):");
            PrintList(list);

            list.InsertAfter(12, 77);
            Console.WriteLine("Nach InsertAfter(12, 77):");
            PrintList(list);

            Console.WriteLine("Position von 3: " + list.PosOfElement(3));
            Console.WriteLine("Position von 99: " + list.PosOfElement(99));
            Console.WriteLine("Position von 77: " + list.PosOfElement(77));
        }

        static void PrintList(VerketteteListe<int> list)
        {
            Node<int> current = list.Head;
            while (current != null)
            {
                Console.Write(current.Data + " -> ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }
    }
}
