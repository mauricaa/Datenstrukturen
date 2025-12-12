using Datastucture;
using Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using SortingAlgorithm;

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
            var node1 = list.Head;
            var node99 = node1.Next;
            var node3 = node99.Next;
            Assert.AreEqual(1, node1.Data);
            Assert.AreEqual(99, node99.Data);
            Assert.AreEqual(3, node3.Data);
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
            var forward = "";
            var cur = list.Head;
            while (cur != null)
            {
                forward += cur.Data + ",";
                cur = cur.Next;
            }
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

        [Test]
        public void BubbleSort_ShouldSortAscending()
        {
            var list = new DoppeltVerketteteListe<int>();
            list.AddLast(5);
            list.AddLast(3);
            list.AddLast(8);
            list.AddLast(1);
            list.AddLast(4);
            list.BubbleSort();
            var expected = new[] { 1, 3, 4, 5, 8 };
            var actual = new List<int>();
            var current = list.Head;
            while (current != null)
            {
                actual.Add(current.Data);
                current = current.Next;
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BubbleSort_WithDuplicates_ShouldPreserveOrder()
        {
            var list = new DoppeltVerketteteListe<int>();
            list.AddLast(3);
            list.AddLast(1);
            list.AddLast(3);
            list.AddLast(2);
            list.AddLast(3);
            list.BubbleSort();
            var expected = new[] { 1, 2, 3, 3, 3 };
            var actual = new List<int>();
            var current = list.Head;
            while (current != null)
            {
                actual.Add(current.Data);
                current = current.Next;
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BubbleSort_EmptyList_ShouldRemainEmpty()
        {
            var list = new DoppeltVerketteteListe<int>();
            list.BubbleSort();
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
        }

        [Test]
        public void BubbleSort_SingleElement_ShouldRemainUnchanged()
        {
            var list = new DoppeltVerketteteListe<int>();
            list.AddLast(42);
            list.BubbleSort();
            Assert.AreEqual(42, list.Head.Data);
            Assert.AreEqual(list.Head, list.Tail);
        }

        [Test]
        public void BubbleSort_AlreadySorted_ShouldRemainSame()
        {
            var list = new DoppeltVerketteteListe<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.BubbleSort();
            Assert.AreEqual(1, list.Head.Data);
            Assert.AreEqual(3, list.Tail.Data);
        }

        [Test]
        public void BubbleSort_ReverseSorted_ShouldSortCorrectly()
        {
            var list = new DoppeltVerketteteListe<int>();
            list.AddLast(5);
            list.AddLast(4);
            list.AddLast(3);
            list.AddLast(2);
            list.AddLast(1);
            list.BubbleSort();
            var current = list.Head;
            int prev = int.MinValue;
            while (current != null)
            {
                Assert.IsTrue(current.Data >= prev);
                prev = current.Data;
                current = current.Next;
            }
        }

        [Test]
        public void BubbleSort_ShouldUpdateTailCorrectly()
        {
            var list = new DoppeltVerketteteListe<int>();
            list.AddLast(3);
            list.AddLast(1);
            list.AddLast(2);
            list.BubbleSort();
            Assert.AreEqual(3, list.Tail.Data);
            Assert.IsNull(list.Tail.Next);
            Assert.AreEqual(2, list.Tail.Previous.Data);
        }

        [Test]
        public void BubbleSort_WithStrings_ShouldSortLexicographically()
        {
            var list = new DoppeltVerketteteListe<string>();
            list.AddLast("banana");
            list.AddLast("apple");
            list.AddLast("cherry");
            list.BubbleSort();
            var expected = new[] { "apple", "banana", "cherry" };
            var actual = new List<string>();
            var current = list.Head;
            while (current != null)
            {
                actual.Add(current.Data);
                current = current.Next;
            }
            CollectionAssert.AreEqual(expected, actual);
        }
        [Test]
        public void InsertionSort_EmptyList_ShouldRemainEmpty()
        {
            var list = new DoppeltVerketteteListe<int>();
            list.SortAlgorithm = new InsertionSorts<int>();
            list.BubbleSort();
            Assert.IsNull(list.Head);
        }

        [Test]
        public void InsertionSort_SingleElement_ShouldRemainUnchanged()
        {
            var list = new DoppeltVerketteteListe<int>();
            list.AddLast(999);
            list.SortAlgorithm = new InsertionSorts<int>();
            list.BubbleSort();
            Assert.AreEqual(999, list.Head.Data);
        }
    }
}