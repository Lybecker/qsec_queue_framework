using System;
using Xunit;

namespace QueueFramework.Test
{
    public class PriorityQueueTests
    {

        [Fact]
        public void NewCollection_IsEmpty()
        {
            var queue = new PriorityQueue<string>();
            Assert.Equal(0, queue.Count);
        }

        [Fact]
        public void Enqueue_IncrementsCount()
        {
            var queue = new PriorityQueue<string>();
            for (int i = 1; i < 10; i++) {
                queue.Enqueue("test" + i, i);
                Assert.Equal(i, queue.Count);
            }
        }

        [Fact]
        public void Enqueue_SamePriority_PreservesFIFO()
        {
            var queue = new PriorityQueue<string>();
            queue.Enqueue("firststring", 10);
            queue.Enqueue("secondstring", 10);
            Assert.Equal("firststring", queue.Dequeue());
            Assert.Equal("secondstring", queue.Dequeue());
        }

        [Fact]
        public void Enqueue_HigherPriority_RetrievedFirst()
        {
            var queue = new PriorityQueue<string>();
            queue.Enqueue("p2", 2);
            queue.Enqueue("p10", 10);
            queue.Enqueue("p5", 5);
            queue.Enqueue("p1", 1);
            queue.Enqueue("p5", 5);
            queue.Enqueue("p13", 13);
            Assert.Equal("p13", queue.Dequeue());
            Assert.Equal("p10", queue.Dequeue());
            Assert.Equal("p5", queue.Dequeue());
            Assert.Equal("p5", queue.Dequeue());
            Assert.Equal("p2", queue.Dequeue());
            Assert.Equal("p1", queue.Dequeue());
        }

        [Fact]
        public void Dequeue_RemovesItem()
        {
            var queue = new PriorityQueue<string>();
            queue.Enqueue("test", 10);
            Assert.Equal(1, queue.Count);
            queue.Dequeue();
            Assert.Equal(0, queue.Count);
        }

        [Fact]
        public void Dequeue_ThrowsExceptionForEmptyQueue()
        {
            var queue = new PriorityQueue<string>();
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Fact]
        public void Peek_ReturnsItemWithoutRemoving()
        {
            var queue = new PriorityQueue<string>();
            queue.Enqueue("test", 10);
            Assert.Equal(1, queue.Count);
            Assert.Equal("test", queue.Peek());
            Assert.Equal(1, queue.Count);
        }

        [Fact]
        public void Peek_ThrowsExceptionForEmptyQueue()
        {
            var queue = new PriorityQueue<string>();
            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }
    }
}
