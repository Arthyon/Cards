using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Cards.Messaging.Dispatchers;
using Cards.Presentation.Core;
using Cards.Presentation.Messaging.Messages;
using Cards.Presentation.Messaging.Pipeline.Events;

namespace Cards.Presentation.Messaging.Pipeline.Steps.PlayerJoinsGame
{
    public class BroadcastPlayerJoinedMessageStep
    {
        public static void BroadcastPlayerJoinedMessage(PlayerJoinedGameEvent ev)
        {
            var messageDispatcher = Locate<IMessageDispatcher>.Instance;
            var i = messageDispatcher.DispatchMessage(new PlayerJoinedMessage(ev.Game.Result, ev.Player));
            Debug.Assert(i > 0);
        }
    }
}