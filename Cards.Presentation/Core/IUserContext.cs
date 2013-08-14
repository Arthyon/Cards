using System;
using Cards.Lobby;
using Cards.Lobby.Components;
using Cards.Lobby.GameComponents;

namespace Cards.Presentation.Core
{
    public interface IUserContext
    {
        Player Player { get; }

        string SessionId { get; }

        bool JoinGame(Guid gameId);

        Maybe<Game> CurrentGame { get; }
    }
}