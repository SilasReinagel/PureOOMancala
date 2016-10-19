using System.Linq;
using Mancala.Core;

namespace Mancala
{
    public class Board
    {
        private readonly SmartList<Lane> lanes;
        private readonly LoopingSequence<Seeds> pits;

        public Board(int numSeeds)
        {
            lanes = new SmartList<Lane>(Enumerable.Range(0, 2).Select(x => new Lane(numSeeds)));
            pits = new LoopingSequence<Seeds>(lanes.SelectMany(x => x.Pits).ToSmartList());
        }

        public Lane GiveMeLane(int lane)
        {
            return lanes[lane];
        }

        public void SowSeedsFrom(int laneNumber, int house)
        {
            var seeds = GiveMeLane(laneNumber).GiveMeSeedsFromHouse(house);
            pits.AdvanceTo(seeds);
            while (seeds.Count > 0)
                seeds.SowInto(pits.Next());
        }
    }
}
