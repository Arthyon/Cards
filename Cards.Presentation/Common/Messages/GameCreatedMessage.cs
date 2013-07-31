using Cards.Lobby.GameComponents;
using Cards.Messaging.Core;

namespace Cards.Presentation.Common.Messages
{
    public class GameCreatedMessage : IDispatchMessage
    {
        public Game CreatedGame { get; private set; }

        public GameCreatedMessage(Game createdGame)
        {
            CreatedGame = createdGame;
        }
    }
}