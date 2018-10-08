using System;
using System.Collections;
using System.Collections.Generic;

namespace QueueFramework
{
    public class PriorityQueue<T>
    {
        private readonly List<KeyValuePair<int, T>> items = new List<KeyValuePair<int, T>>();        

        public int Count => items.Count;

        public void Enqueue(T item, int priority)
        {
            var newItemPair = new KeyValuePair<int, T>(priority, item);

            var index = items.FindIndex(x => x.Key <= priority);
            if (index >= 0)
            {
                items.Insert(index, newItemPair);
            }
            else items.Add(newItemPair);
        }

        public T Dequeue()
        {
            var result = Peek();
            items.RemoveAt(Count - 1);
            return result;
        }

        public T Peek()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return items[Count - 1].Value;
        }
    }
}
