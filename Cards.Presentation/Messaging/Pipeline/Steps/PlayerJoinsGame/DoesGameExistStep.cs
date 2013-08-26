
using System;
using Cards.Presentation.Messaging.Pipeline.Events;
using Cards.Presentation.Messaging.Pipeline.Exceptions;

namespace Cards.Presentation.Messaging.Pipeline.Steps.PlayerJoinsGame
{
    public class DoesGameExistStep
    {
        public static void DoesGameExist(PlayerJoinedGameEvent ev)
        {
            if (!ev.Game.IsSuccessful)
                throw new NotFoundException("Game not found");
        }
    }
}