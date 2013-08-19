using Cards.Lobby;
using Cards.Lobby.GameComponents;
using Cards.Messaging.Core;

namespace Cards.Presentation.Common.Messages
{
    public class PlayerJoinedMessage : IDispatchMessage
    {
        public Game Game { get; private set; }
        public Player Player { get; private set; }

        public PlayerJoinedMessage(Game game, Player player)
        {
            Game = game;
            Player = player;
        }
    }
}