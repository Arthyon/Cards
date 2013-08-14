using System;
using System.Collections.Generic;
using Cards.Lobby.Components;

using Cards.Lobby.GameComponents;
using Cards.Lobby.LobbyComponents;

namespace Cards.Lobby
{
    public class GameLobby : ILobby
    {
        private GameCollection GameCollection { get; set; }

        public GameLobby()
        {
            GameCollection = new GameCollection();
           }

        public Game StartGame(Game game)
        {
            return GameCollection.StartNewGame(game);
        }

        public Maybe<Game> GetGame(Guid id)
        {
            return GameCollection.GetGame(id);
        }

        public ICollection<Game> GetGames()
        {
            return GameCollection;
        }
    }
}
