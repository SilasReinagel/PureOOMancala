using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mancala.Tests
{
    [TestClass]
    public class LaneTests
    {
        [TestMethod]
        public void Lane_GiveMePits_EndZoneIncluded()
        {
            var pits = new Lane(0).Pits;

            Assert.AreEqual(7, pits.Count);
        }
    }
}
