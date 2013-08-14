using System;
using System.Collections.ObjectModel;
using System.Linq;
using Cards.Lobby.Components;

namespace Cards.Lobby.GameComponents
{
    public class PlayerCollection : Collection<Player>
    {
        public int PlayerCount
        {
            get { return Count; }
        }

        public Player AddPlayer(Player player)
        {
            Add(player);
            return player;
        }

        public Maybe<Player> GetPlayer(string id)
        {
            return new Maybe<Player>(this.FirstOrDefault(player => player.Identifier == id));
        }
    }
}