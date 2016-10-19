using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mancala.Tests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void Board_OneSeedPerBin_Lane1HasSixHouseWithOneSeedEachAndZeroSeedsInEndZone()
        {
            var lane = new Board(1).GiveMeLane(1);

            Assert.AreEqual(6, lane.Houses.Count());
            Assert.AreEqual(true, lane.Houses.All(x => x.Count == 1));
            Assert.AreEqual(0, lane.EndZone.Count);
        }
    }
}
