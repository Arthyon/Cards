using Cards.Lobby;
using Cards.Lobby.Components;
using Cards.Lobby.GameComponents;

namespace Cards.Presentation.Messaging.Pipeline.Events
{
    public class PlayerJoinedGameEvent : EventBase
    {
        public Maybe<Game> Game { get; private set; }
        public Player Player { get; private set; }

        public PlayerJoinedGameEvent(Maybe<Game> game, Player player)
        {
            Game = game;
            Player = player;
        }
    }
}