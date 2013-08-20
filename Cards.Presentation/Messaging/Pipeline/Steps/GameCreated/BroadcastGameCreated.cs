using System.Diagnostics;
using Cards.Messaging.Dispatchers;
using Cards.Presentation.Core;
using Cards.Presentation.Messaging.Messages;

namespace Cards.Presentation.Messaging.Pipeline.Steps.GameCreated
{
    public class BroadcastGameCreated
    {
        public BroadcastGameCreated(GameCreatedMessage msg)
        {

            var result = Locate<IMessageDispatcher>.Instance.DispatchMessage(msg);

            Debug.Assert(result > 0);
        }
    }
}