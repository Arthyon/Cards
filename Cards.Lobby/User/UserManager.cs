using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Cards.Lobby.Components;

namespace Cards.Lobby.User
{
    internal class UserManager : IUserManager
    {
        private readonly ICollection<Player> _playerList;

        public UserManager()
        {
            _playerList = new Collection<Player>();
        }
        public IReadOnlyCollection<Player> PlayerList
        {
            get { return new ReadOnlyCollection<Player>(_playerList.ToList()); }
        }

        public Player AddPlayer(Player player)
        {
            if (!_playerList.Contains(player))
            {
                _playerList.Add(player);
            }
            return player;
        }

        public bool RemovePlayer(Player player)
        {
            if (_playerList.Contains(player))
            {
                _playerList.Remove(player);
                return true;
            }
            return false;

        }

        public Maybe<Player> GetPlayer(string identifier)
        {
            return new Maybe<Player>(_playerList.FirstOrDefault(a => a.Identifier == identifier));
        }

    }
}
