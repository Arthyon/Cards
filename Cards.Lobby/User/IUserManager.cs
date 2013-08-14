using System;
using System.Collections.Generic;
using Cards.Lobby.Components;

namespace Cards.Lobby.User
{
    public interface IUserManager
    {
        IReadOnlyCollection<Player> PlayerList { get; }

        Player AddPlayer(Player player);

        bool RemovePlayer(Player player);

        Maybe<Player> GetPlayer(string userId);
    }
}