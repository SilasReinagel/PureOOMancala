using System.Collections.Generic;
using System.Linq;
using Mancala.Core;

namespace Mancala
{
    public class Lane
    {
        public Seeds EndZone { get; private set; }
        public SmartList<Seeds> Houses { get; private set; }
        public SmartList<Seeds> Pits { get; private set; }

        public Lane(int numSeedsPerPit)
        {
            EndZone = new Seeds(0);
            Houses = new SmartList<Seeds>(Enumerable.Range(0, 6).Select(x => new Seeds(numSeedsPerPit)).ToList());
            Pits = Houses.Concat(new List<Seeds> { EndZone }).ToSmartList();
        }

        public int HowManySeedsInHouse(int houseNumber)
        {
            return GiveMeSeedsFromHouse(houseNumber).Count;
        }

        public Seeds GiveMeSeedsFromHouse(int houseNumber)
        {
            return Houses[houseNumber];
        }
    }
}
