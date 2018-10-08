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
        public void Dequeue_ThrowsExceptionForEmptyQueue()
        {
            var queue = new PriorityQueue<string>();
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Fact]
        public void Peek_ThrowsExceptionForEmptyQueue()
        {
            var queue = new PriorityQueue<string>();
            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }
    }
}
