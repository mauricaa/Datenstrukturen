using Datastucture;
using Common;
using NUnit.Framework;
using System;

namespace Datastucture.Tests
{
    [TestFixture]
    public class DoubleLinkedListDatastructureTests
    {
        [Test]
        public void AddLast_ShouldAddElements()
        {
            var list = new DoppeltVerketteteListe<int>();
            list.AddLast(1);
            list.AddLast(2);

            Assert.AreEqual(0, list.PosOfElement(1));
            Assert.AreEqual(1, list.PosOfElement(2));

            // Tail should point to last element
            Assert.AreEqual(2, list.Tail.Data);
            Assert.IsNull(list.Head.Previous);
        }

        [Test]
        public void InsertBefore_ShouldInsertElementCorrectly()
        {
            var list = new DoppeltVerketteteListe<int>();
            list.AddLast(1);
            list.AddLast(3);
            list.AddLast(5);

            list.InsertBefore(3, 99);

            Assert.AreEqual(1, list.PosOfElement(99));
            Assert.AreEqual(2, list.PosOfElement(3));

            // check links: 1 <-> 99 <-> 3
            var node1 = list.Head;
            var node99 = node1.Next;
            var node3 = node99.Next;

            Assert.AreEqual(1, node1.Data);
            Assert.AreEqual(99, node99.Data);
            Assert.AreEqual(3, node3.Data);

            // previous links
            Assert.AreEqual(node1, node99.Previous);
            Assert.AreEqual(node99, node3.Previous);
        }

        [Test]
        public void InsertAfter_ShouldInsertElementCorrectly()
        {
            var list = new DoppeltVerketteteListe<int>();
            list.AddLast(1);
            list.AddLast(3);
            list.AddLast(5);

            var pos = list.InsertAfter(3, 77);

            Assert.AreEqual(2, pos);
            Assert.AreEqual(2, list.PosOfElement(77));
            Assert.AreEqual(1, list.PosOfElement(3));

            // check backward link from new node
            var current = list.Head;
            while (current != null && current.Data != 77) current = current.Next;
            Assert.IsNotNull(current);
            Assert.AreEqual(3, current.Previous.Data);
        }

        [Test]
        public void PosOfElement_ShouldReturnMinusOne_WhenNotFound()
        {
            var list = new DoppeltVerketteteListe<int>();
            list.AddLast(10);
            list.AddLast(20);

            Assert.AreEqual(-1, list.PosOfElement(99));
        }

        [Test]
        public void InsertBefore_OnHead_ShouldInsertAtBeginning()
        {
            var list = new DoppeltVerketteteListe<int>();
            list.AddLast(5);
            list.AddLast(10);

            list.InsertBefore(5, 1);

            Assert.AreEqual(0, list.PosOfElement(1));
            Assert.AreEqual(1, list.PosOfElement(5));
            Assert.AreEqual(1, list.Head.Next.Data);
            Assert.IsNull(list.Head.Previous);
        }

        [Test]
        public void InsertAfter_OnLastElement_ShouldAppendAndUpdateTail()
        {
            var list = new DoppeltVerketteteListe<int>();
            list.AddLast(5);
            list.AddLast(10);

            var posOfNewElement = list.InsertAfter(10, 99);

            Assert.AreEqual(posOfNewElement, list.PosOfElement(99));
            Assert.AreEqual(99, list.Tail.Data);
            Assert.AreEqual(list.Tail.Previous.Data, 10);
        }

        [Test]
        public void InsertBefore_ShouldThrow_WhenElementNotFound()
        {
            var list = new DoppeltVerketteteListe<int>();
            list.AddLast(1);

            Assert.Throws<ArgumentException>(() => list.InsertBefore(99, 5));
        }

        [Test]
        public void InsertAfter_ShouldThrow_WhenElementNotFound()
        {
            var list = new DoppeltVerketteteListe<int>();
            list.AddLast(1);

            Assert.Throws<ArgumentException>(() => list.InsertAfter(99, 5));
        }

        [Test]
        public void BackwardsTraversal_ShouldProduceReverseOrder()
        {
            var list = new DoppeltVerketteteListe<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            // traverse forward, collect
            var forward = "";
            var cur = list.Head;
            while (cur != null)
            {
                forward += cur.Data + ",";
                cur = cur.Next;
            }

            // traverse backward from tail
            var backward = "";
            cur = list.Tail;
            while (cur != null)
            {
                backward += cur.Data + ",";
                cur = cur.Previous;
            }

            Assert.AreEqual("1,2,3,", forward);
            Assert.AreEqual("3,2,1,", backward);
        }
    }
}
