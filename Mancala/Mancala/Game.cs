using System.Linq;
using Mancala.Core;

namespace Mancala
{
    public class Game
    {
        private readonly Board board;
        private readonly SmartList<Player> players;
        private readonly LoopingSequence<Player> turnOrder;

        private Player currentPlayer;

        public Game(Board board, Player firstPlayer, Player secondPlayer)
        {
            this.board = board;
            players = new SmartList<Player>(firstPlayer, secondPlayer);
            turnOrder = new LoopingSequence<Player>(players);
        }

        public void Start()
        {
            ChangeTurn();
        }

        public void Move(int house)
        {
            board.SowSeedsFrom(players.IndexOf(currentPlayer), house);
            ChangeTurn();
        }

        private void ChangeTurn()
        {
            currentPlayer = turnOrder.Next();
            players.ForEach(x => x.ItsThisPlayersTurn(currentPlayer));
        }
    }
}
