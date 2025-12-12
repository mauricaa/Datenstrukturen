using Common;
using Datastucture;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Datastucture.Tests
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void Push_And_Peek_ShouldReturnLastPushedItem()
        {
            var stack = new Stack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            Assert.AreEqual(30, stack.Peek());
            Assert.AreEqual(3, stack.Count);
        }

        [Test]
        public void Pop_ShouldReturnAndRemoveLastItem()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.AreEqual(3, stack.Pop());
            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(1, stack.Pop());
            Assert.AreEqual(0, stack.Count);
        }

        [Test]
        public void Pop_OnEmptyStack_ShouldThrowInvalidOperationException()
        {
            var stack = new Stack<int>();
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Test]
        public void Peek_OnEmptyStack_ShouldThrowInvalidOperationException()
        {
            var stack = new Stack<int>();
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Test]
        public void ToList_ShouldReturnElementsInCorrectOrder()
        {
            var stack = new Stack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            var list = stack.ToList();

            CollectionAssert.AreEqual(new[] { 10, 20, 30 }, list);
        }

        [Test]
        public void Count_ShouldBeCorrectAfterPushAndPop()
        {
            var stack = new Stack<string>();
            Assert.AreEqual(0, stack.Count);

            stack.Push("A");
            stack.Push("B");
            Assert.AreEqual(2, stack.Count);

            stack.Pop();
            Assert.AreEqual(1, stack.Count);
        }

        [Test]
        public void IsEmpty_ShouldReturnTrue_WhenStackIsEmpty()
        {
            var stack = new Stack<int>();
            Assert.IsTrue(stack.IsEmpty());

            stack.Push(42);
            Assert.IsFalse(stack.IsEmpty());

            stack.Pop();
            Assert.IsTrue(stack.IsEmpty());
        }

        [Test]
        public void MultiplePushAndPop_ShouldBehaveLikeLIFO()
        {
            var stack = new Stack<int>();
            for (int i = 1; i <= 10; i++)
            {
                stack.Push(i);
            }

            for (int i = 10; i >= 1; i--)
            {
                Assert.AreEqual(i, stack.Pop());
            }

            Assert.IsTrue(stack.IsEmpty());
        }
    }
}