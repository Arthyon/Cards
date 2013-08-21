
using Cards.Lobby;
using Cards.Lobby.GameComponents;

namespace Cards.Presentation.Messaging.Pipeline.Events
{
    public class GameCreatedEvent : EventBase
    {
        public Game CreatedGame { get; private set; }
        public Player GameOwner { get; private set; }

        public GameCreatedEvent(Game createdGame, Player gameOwner)
        {
            CreatedGame = createdGame;
            GameOwner = gameOwner;
        }
    }
}