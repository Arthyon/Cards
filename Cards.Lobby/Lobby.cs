using System;
using Cards.Lobby.Components;

using Cards.Lobby.GameComponents;

namespace Cards.Lobby
{
    public class GameLobby
    {
        private LobbyConfiguration Configuration { get; set; }
        private GameCollection GameCollection { get; set; }

        public GameLobby(Action<ILobbyConfiguration> config)
        {
            Configuration = new LobbyConfiguration();
            config(Configuration);

            GameCollection = new GameCollection();

            ComponentInitialization.Initialize(Configuration);
        }

        public GameLobby()
        {
            Configuration = new LobbyConfiguration();

            GameCollection = new GameCollection();

            ComponentInitialization.Initialize(Configuration);
        }
        
        public Game StartGame(Game game)
        {
            return GameCollection.StartNewGame(game);
        }

        public Maybe<Game> GetGame(Guid id)
        {
            return GameCollection.GetGame(id);
        }
        
    }
}
