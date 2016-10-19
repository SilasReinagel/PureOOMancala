using System.Linq;
using Mancala.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mancala.Tests.Core
{
    [TestClass]
    public class LoopingSequenceTest
    {
        [TestMethod]
        public void LoopingSequence_GetNextOnSingleItemList_AllItemsAreElement()
        {
            var sequence = new LoopingSequence<string>(new SmartList<string> { "Sonic The Hedgehog" });

            Assert.AreEqual(5, sequence.Take(5).Count());
            Assert.AreEqual(true, sequence.Take(5).All(x => x.Equals("Sonic The Hedgehog")));
        }

        [TestMethod]
        public void LoopingSequence_GetNextOnThreeItemList_LoopsCorrectly()
        {
            var sequence = new LoopingSequence<int>(new SmartList<int> { 1, 2, 3 });

            var fourElements = sequence.Take(4).ToList();

            Assert.AreEqual(2, fourElements.Count(x => x == 1));
            Assert.AreEqual(1, fourElements.Count(x => x == 2));
            Assert.AreEqual(1, fourElements.Count(x => x == 3));
        }

        [TestMethod]
        public void LoopingSequence_ConsecutiveSingleElementIterations_ElementsDiffer()
        {
            var sequence = new LoopingSequence<int>(new SmartList<int> { 1, 2, 3 });

            Assert.AreEqual(1, sequence.Next());
            Assert.AreEqual(2, sequence.Next());
        }
    }
}
