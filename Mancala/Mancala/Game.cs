using Mancala.Core;

namespace Mancala
{
    public class Game
    {
        private readonly Board board;
        private readonly SmartList<Player> players;
        private readonly LoopingSequence<Player> turnOrder;
        private readonly ConditionalAction updateTurn;

        private Player currentPlayer;

        public Game(Board board, Player firstPlayer, Player secondPlayer)
        {
            this.board = board;
            players = new SmartList<Player>(firstPlayer, secondPlayer);
            turnOrder = new LoopingSequence<Player>(players);
            updateTurn = new ConditionalAction(() => !board.WasLastSeedSownIntoEndZone(CurrentLane), ChangeTurn);
        }

        public void Start()
        {
            ChangeTurn();
        }

        public void Move(int house)
        {
            board.SowSeedsFrom(CurrentLane, house);
            updateTurn.Invoke();
        }

        private int CurrentLane { get { return players.IndexOf(currentPlayer); } }

        private void ChangeTurn()
        {
            currentPlayer = turnOrder.Next();
            players.ForEach(x => x.ItsThisPlayersTurn(currentPlayer));
        }
    }
}
