
using System;
using Cards.Lobby.GameComponents;

namespace Cards.Lobby
{
    public class Player
    {
        public string Identifier { get; private set; }

        public Player(string identifier, string name)
        {
            Identifier = identifier;
            Name = name;

        }

        public bool IsOnline { get; set; }


        public string Name { get; private set; }

        public Game CurrentGame { get; set; }
    }
}
