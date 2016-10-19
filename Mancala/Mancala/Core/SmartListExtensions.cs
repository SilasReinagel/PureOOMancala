using System.Collections.Generic;

namespace Mancala.Core
{
    public static class SmartListExtensions
    {
        public static SmartList<T> ToSmartList<T>(this IEnumerable<T> enumerable)
        {
            return new SmartList<T>(enumerable);
        }
    }
}
