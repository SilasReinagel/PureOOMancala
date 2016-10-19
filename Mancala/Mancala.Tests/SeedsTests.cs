using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mancala.Tests
{
    [TestClass]
    public class SeedsTests
    {
        [TestMethod]
        public void Seeds_SowInto_TransfersOneSeedToTheOther()
        {
            var distributingSeeds = new Seeds(1);
            var plantingSeeds = new Seeds(1);

            distributingSeeds.SowInto(plantingSeeds);

            Assert.AreEqual(0, distributingSeeds.Count);
            Assert.AreEqual(2, plantingSeeds.Count);
        }
    }
}
