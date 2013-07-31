
using System;

namespace Cards.Lobby
{
    public abstract class Player
    {
        protected Player(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
    }
}
