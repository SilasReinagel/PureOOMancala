namespace Mancala
{
    public class FakePlayer : Player
    {
        public bool IsTheGameOver { get; private set; }
        public bool IsItYourTurn { get; private set; }

        public void GameIsOver(string winner)
        {
            IsTheGameOver = true;
        }

        public void ItsThisPlayersTurn(Player player)
        {
            IsItYourTurn = player.Equals(this);
        }
    }
}
