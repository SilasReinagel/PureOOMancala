using System;
using System.Collections.Generic;
using System.Linq;

namespace Mancala.Core
{
    public class LoopingSequence<T>
    {
        private readonly SmartList<T> items;
        private int index;

        public LoopingSequence(SmartList<T> items)
        {
            this.items = items;
        }

        public T Next()
        {
            return items[index++ % items.Count + 1];
        }

        public IEnumerable<T> Take(int numItems)
        {
            return Enumerable.Range(0, numItems).Select(x => Next());
        }

        public void AdvanceTo(T obj)
        {
            if (!items.Contains(obj))
                throw new InvalidOperationException("Element not found.");
            while (!Next().Equals(obj))
                index++;
        }
    }
}
