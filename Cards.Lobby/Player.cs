using System.Collections.Generic;
using System.Linq;
using Cards.Lobby.Components;
using Cards.Lobby.GameComponents;

namespace Cards.Lobby
{
    public class Player
    {
        private Game _game;

        public Player(string identifier, string name)
        {
            Identifier = identifier; //SessionId
            Name = name;

            ConnectionIds = new List<string>();
        }

        public string Identifier { get; private set; }

        public bool IsOnline { get; set; }


        public string Name { get; private set; }

        public Maybe<Game> CurrentGame
        {
            get { return new Maybe<Game>(_game); }
            set { _game = value.Result; }
        }

        private List<string> ConnectionIds { get; set; }

        public bool OwnsConnectionId(string connectionId)
        {
            return ConnectionIds.Any(i => i.Equals(connectionId));
        }

        public void AddConnectionId(string connectionId)
        {
            if (OwnsConnectionId(connectionId))
                return;

            ConnectionIds.Add(connectionId);
        }
    }
}