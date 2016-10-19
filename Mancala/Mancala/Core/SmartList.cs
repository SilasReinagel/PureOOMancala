using System.Collections.Generic;

namespace Mancala.Core
{
    public sealed class SmartList<T> : List<T>
    {
        public SmartList(params T[] items) : base(new List<T>(items))
        {
        }

        public SmartList(IEnumerable<T> collection) : base(collection)
        {
        }

        public new T this[int humanIndex]
        {
            get { return base[humanIndex - 1]; }
            set { base[humanIndex - 1] = value; }
        }

        public new int IndexOf(T obj)
        {
            return base.IndexOf(obj) + 1;
        }
    }
}
