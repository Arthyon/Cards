using System.Diagnostics;
using Cards.Messaging.Dispatchers;
using Cards.Presentation.Core;
using Cards.Presentation.Messaging.Messages;
using Cards.Presentation.Messaging.Pipeline.Events;

namespace Cards.Presentation.Messaging.Pipeline.Steps.GameCreated
{
    public class BroadcastGameCreatedStep
    {
        public static bool BroadcastGameCreated(GameCreatedEvent ev)
        {
            var msg = new GameCreatedMessage(ev.CreatedGame, ev.GameOwner);
            var result = Locate<IMessageDispatcher>.Instance.DispatchMessage(msg);

            Debug.Assert(result > 0);

            return true;
        }
    }
}