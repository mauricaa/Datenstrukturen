using Common;
using Datastucture;
using System;
using SortingAlgorithm;

namespace Datastucture
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Einzeln verkettete Liste");
            EinzelnVerketteteListe<int> list = new EinzelnVerketteteListe<int>();
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
            try
            {
                list.InsertAfter(999, 5);
            }
            catch (Exception) { }

            Console.WriteLine("Doppelt verkettete Liste");
            DoppeltVerketteteListe<int> dList = new DoppeltVerketteteListe<int>();
            dList.AddLast(1);
            dList.AddLast(3);
            dList.AddLast(12);
            Console.WriteLine("Startliste (doppelt, vorwärts):");
            PrintDoubleList(dList);
            Console.WriteLine("Startliste (doppelt, rückwärts):");
            PrintDoubleListReverse(dList);
            dList.InsertBefore(3, 99);
            Console.WriteLine("Nach InsertBefore(3, 99) (vorwärts):");
            PrintDoubleList(dList);
            Console.WriteLine("Nach InsertBefore(3, 99) (rückwärts):");
            PrintDoubleListReverse(dList);
            dList.InsertAfter(12, 77);
            Console.WriteLine("Nach InsertAfter(12, 77) (vorwärts):");
            PrintDoubleList(dList);
            Console.WriteLine("Nach InsertAfter(12, 77) (rückwärts):");
            PrintDoubleListReverse(dList);
            Console.WriteLine("Position von 3: " + dList.PosOfElement(3));
            Console.WriteLine("Position von 99: " + dList.PosOfElement(99));
            Console.WriteLine("Position von 77: " + dList.PosOfElement(77));
            try
            {
                dList.InsertAfter(999, 5);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            Console.WriteLine("INSERTION SORT TEST");
            var insertionList = new DoppeltVerketteteListe<int>();
            insertionList.AddLast(5);
            insertionList.AddLast(1);
            insertionList.AddLast(4);
            insertionList.AddLast(2);

            insertionList.SortAlgorithm = SortAlgorithmFactory.Create<int>("insertionsort");

            Console.WriteLine("Vor Insertion Sort:");
            PrintDoubleList(insertionList);
            insertionList.Sort();
            Console.WriteLine("Nach Insertion Sort:");
            PrintDoubleList(insertionList);

            Console.WriteLine("BUBBLE SORT TEST");
            var bubbleList = new DoppeltVerketteteListe<int>();
            bubbleList.AddLast(5);
            bubbleList.AddLast(1);
            bubbleList.AddLast(4);
            bubbleList.AddLast(2);

            bubbleList.SortAlgorithm = SortAlgorithmFactory.Create<int>("bubble");

            Console.WriteLine("Vor Sortierung (vorwärts):");
            PrintDoubleList(bubbleList);
            Console.WriteLine("Vor Sortierung (rückwärts):");
            PrintDoubleListReverse(bubbleList);
            bubbleList.Sort();
            Console.WriteLine("Nach BubbleSort (vorwärts):");
            PrintDoubleList(bubbleList);
            Console.WriteLine("Nach BubbleSort (rückwärts):");
            PrintDoubleListReverse(bubbleList);
        }

        static void PrintList(EinzelnVerketteteListe<int> list)
        {
            Node<int> current = list.Head;
            while (current != null)
            {
                Console.Write(current.Data + " -> ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }

        static void PrintDoubleList(DoppeltVerketteteListe<int> list)
        {
            Node<int> current = list.Head;
            while (current != null)
            {
                Console.Write(current.Data + " <-> ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }

        static void PrintDoubleListReverse(DoppeltVerketteteListe<int> list)
        {
            Node<int> current = list.Tail;
            if (current == null)
            {
                Console.WriteLine("null");
                return;
            }
            while (current != null)
            {
                Console.Write(current.Data + " <-> ");
                current = current.Previous;
            }
            Console.WriteLine("null");
        }
    }
}