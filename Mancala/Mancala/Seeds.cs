using System.Collections.Generic;
using System.Linq;

namespace Mancala
{
    public class Seeds
    {
        private readonly Stack<object> seeds;

        public int Count { get { return seeds.Count; } }

        public Seeds(int initialCount)
        {
            seeds = new Stack<object>(Enumerable.Range(0, initialCount).Select(x => new object()).ToList());
        }

        public void SowInto(Seeds other)
        {
            other.HereIsAnotherSeed(seeds.Pop());
        }

        public void HereIsAnotherSeed(object seed)
        {
            seeds.Push(seed);
        }

        public override string ToString()
        {
            return Count.ToString();
        }
    }
}
