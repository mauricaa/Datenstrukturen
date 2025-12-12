using Datastucture.Tests;
 
using Datastucture;
using NUnit.Framework;
using System;
namespace Datastucture.Tests
{
    [TestFixture]
    public class VerketteteListeTests
    {
        [Test]
        public void AddLast_ShouldAddElements()
        {
            var list = new EinzelnVerketteteListe<int>();
            list.AddLast(1);
            list.AddLast(2);
            Assert.AreEqual(0, list.PosOfElement(1));
            Assert.AreEqual(1, list.PosOfElement(2));
        }
        [Test]
        public void InsertBefore_ShouldInsertElementCorrectly()
        {
            var list = new EinzelnVerketteteListe<int>();
            list.AddLast(1);
            list.AddLast(3);
            list.AddLast(5);
            list.InsertBefore(3, 99);
            Assert.AreEqual(1, list.PosOfElement(99));
            Assert.AreEqual(2, list.PosOfElement(3));
        }
        [Test]
        public void InsertAfter_ShouldInsertElementCorrectly()
        {
            var list = new EinzelnVerketteteListe<int>();
            list.AddLast(1);
            list.AddLast(3);
            list.AddLast(5);
            list.InsertAfter(3, 77);
            Assert.AreEqual(2, list.PosOfElement(77));
            Assert.AreEqual(1, list.PosOfElement(3));
        }
        [Test]
        public void PosOfElement_ShouldReturnMinusOne_WhenNotFound()
        {
            var list = new EinzelnVerketteteListe<int>();
            list.AddLast(10);
            list.AddLast(20);
            Assert.AreEqual(-1, list.PosOfElement(99));
        }
        [Test]
        public void InsertBefore_OnHead_ShouldInsertAtBeginning()
        {
            var list = new EinzelnVerketteteListe<int>();
            list.AddLast(5);
            list.AddLast(10);
            list.InsertBefore(5, 1);
            Assert.AreEqual(0, list.PosOfElement(1));
            Assert.AreEqual(1, list.PosOfElement(5));
        }
        [Test]
        public void InsertAfter_OnLastElement_ShouldAppend()
        {
            var list = new EinzelnVerketteteListe<int>();
            list.AddLast(5);
            list.AddLast(10);
            var posOfNewElement = list.InsertAfter(10, 99);
            Assert.AreEqual(posOfNewElement, list.PosOfElement(99));
        }
        [Test]
        public void InsertBefore_ShouldThrow_WhenElementNotFound()
        {
            var list = new EinzelnVerketteteListe<int>();
            list.AddLast(1);
            Assert.Throws<ArgumentException>(() => list.InsertBefore(99, 5));
        }
    }
}