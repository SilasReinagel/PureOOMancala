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

        private void AssertItsPlayersTurn(FakePlayer player)
        {
            Assert.AreEqual(player.Equals(uther), uther.IsItYourTurn);
            Assert.AreEqual(player.Equals(sylvanas), sylvanas.IsItYourTurn);
        }
    }
}
