
namespace Cards.Lobby.GameComponents
{
    public interface IGameConfiguration
    {
        int MinPlayers { get; set; }
        int MaxPlayers { get; set; }
        bool PlayersCanJoinMidGame { get; set; }
        
    }

    public class GameConfiguration : IGameConfiguration
    {
        public GameConfiguration()
        {
            MaxPlayers = 5;
            MinPlayers = 2;
            PlayersCanJoinMidGame = false;
        }

        public bool PlayersCanJoinMidGame { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        
    }
}
