using Cards.Lobby;
using Cards.Lobby.GameComponents;
using Cards.Messaging.Core;

namespace Cards.Presentation.Messaging.Messages
{
    public class GameCreatedMessage : IDispatchMessage
    {
        public Game CreatedGame { get; private set; }
        public Player GameOwner { get; private set; }

        public GameCreatedMessage(Game createdGame, Player gameOwner)
        {
            CreatedGame = createdGame;
            GameOwner = gameOwner;
        }
    }
}