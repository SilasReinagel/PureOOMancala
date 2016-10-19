namespace Mancala
{
    public interface Player
    {
        void GameIsOver(string winner);
        void ItsThisPlayersTurn(Player player);
    }
}
