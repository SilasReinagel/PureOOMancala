using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mancala.Tests
{
    [TestClass]
    public class GameTests
    {
        private Board board;
        private FakePlayer uther;
        private FakePlayer sylvanas;
        private Game game;

        private int uthersLane = 1;
        private int sylvanasLane = 2;

        [TestInitialize]
        public void Initialize()
        {
            board = new Board(4);
            uther = new FakePlayer();
            sylvanas = new FakePlayer();
            game = new Game(board, uther, sylvanas);
            game.Start();
        }

        [TestMethod]
        public void Game_Start_PlayersDoNotThinkGameIsOver()
        {
            Assert.AreEqual(false, uther.IsTheGameOver);
            Assert.AreEqual(false, sylvanas.IsTheGameOver);
        }

        [TestMethod]
        public void Game_Start_ItsFirstPlayersTurn()
        {
            AssertItsPlayersTurn(uther);
        }

        [TestMethod]
        public void Game_UtherTakesATurn_ItsSylvanasTurn()
        {
            game.Move(1);

            AssertItsPlayersTurn(sylvanas);
        }

        [TestMethod]
        public void Game_SylvanasTakesATurn_ItsUthersTurn()
        {
            game.Move(1);
            game.Move(1);

            AssertItsPlayersTurn(uther);
        }

        [TestMethod]
        public void Game_UtherMovesHouse1_SeedsSownCorrectly()
        {
            game.Move(1);

            Assert.AreEqual(0, board.GiveMeLane(uthersLane).HowManySeedsInHouse(1));
            Assert.AreEqual(5, board.GiveMeLane(uthersLane).HowManySeedsInHouse(2));
            Assert.AreEqual(5, board.GiveMeLane(uthersLane).HowManySeedsInHouse(3));
            Assert.AreEqual(5, board.GiveMeLane(uthersLane).HowManySeedsInHouse(4));
            Assert.AreEqual(5, board.GiveMeLane(uthersLane).HowManySeedsInHouse(5));
        }

        [TestMethod]
        public void Game_UtherEndsInScoringBin_ItsStillUthersTurn()
        {
            game.Move(3);

            AssertItsPlayersTurn(uther);
        }

        [TestMethod]
        public void Game_UtherCapturesFromSylvanasPit_SeedsCorrect()
        {
            game.Move(6);
            game.Move(3);

            game.Move(1);

            AssertLaneContains(uthersLane, 0, 5, 5, 5, 5, 0, 7);
            AssertLaneContains(sylvanasLane, 0, 5, 0, 5, 5, 5, 1);
        }

        private void AssertLaneContains(int laneNumber, int p1, int p2, int p3, int p4, int p5, int p6, int endZone)
        {
            var lane = board.GiveMeLane(laneNumber);
            Assert.AreEqual(p1, lane.HowManySeedsInHouse(1), "House 1 Mismatch");
            Assert.AreEqual(p2, lane.HowManySeedsInHouse(2), "House 2 Mismatch");
            Assert.AreEqual(p3, lane.HowManySeedsInHouse(3), "House 3 Mismatch");
            Assert.AreEqual(p4, lane.HowManySeedsInHouse(4), "House 4 Mismatch");
            Assert.AreEqual(p5, lane.HowManySeedsInHouse(5), "House 5 Mismatch");
            Assert.AreEqual(p6, lane.HowManySeedsInHouse(6), "House 6 Mismatch");
            Assert.AreEqual(endZone, lane.EndZone.Count, "EndZone Mismatch");
        }

        private void AssertItsPlayersTurn(FakePlayer player)
        {
            Assert.AreEqual(player.Equals(uther), uther.IsItYourTurn);
            Assert.AreEqual(player.Equals(sylvanas), sylvanas.IsItYourTurn);
        }
    }
}
