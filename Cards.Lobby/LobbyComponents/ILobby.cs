
using System;
using System.Collections.Generic;
using Cards.Lobby.Components;
using Cards.Lobby.GameComponents;

namespace Cards.Lobby.LobbyComponents
{
    public interface ILobby
    {
        Game StartGame(Game game);
        Maybe<Game> GetGame(Guid id);

        ICollection<Game> GetGames();

    }
}
