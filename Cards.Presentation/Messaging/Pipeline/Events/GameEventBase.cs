using Cards.Lobby.GameComponents;
using Cards.Messaging.Pipeline;

namespace Cards.Presentation.Messaging.Pipeline.Events
{
    public class GameEventBase : EventBase
    {
        public Game Game { get; private set; }
        public GameEventBase(Game game)
        {
            Game = game;
        }
    }
}