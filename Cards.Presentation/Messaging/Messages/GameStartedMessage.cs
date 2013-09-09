using Cards.Lobby.GameComponents;
using Cards.Messaging.Core;

namespace Cards.Presentation.Messaging.Messages
{
    public class GameStartedMessage : IDispatchMessage
    {
        public Game Game { get; private set; }

        public GameStartedMessage(Game game)
        {
            Game = game;
        }
    }
}