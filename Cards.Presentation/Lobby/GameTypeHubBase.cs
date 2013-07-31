using Cards.Lobby.GameComponents;

namespace Cards.Presentation.Lobby
{
    public interface IGameTypeHubBase<out T> where T : Game
    {
        T CreateGame();
    }
}