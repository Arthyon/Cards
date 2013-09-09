using System.Diagnostics;
using Cards.Messaging.Dispatchers;
using Cards.Presentation.Core;
using Cards.Presentation.Messaging.Messages;
using Cards.Presentation.Messaging.Pipeline.Events;

namespace Cards.Presentation.Messaging.Pipeline.Steps
{
    public class SendGameStartedMessageStep
    {
        public static bool SendGameStartedMessage(GameEventBase ev)
        {
            var gameStartedMessage = new GameStartedMessage(ev.Game);
            int handledBy = Locate<IMessageDispatcher>.Instance.DispatchMessage(gameStartedMessage);

            Debug.Assert(handledBy > 0);
            return true;
        }
    }
}