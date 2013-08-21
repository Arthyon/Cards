
using System;
using Cards.Presentation.Messaging.Pipeline.Events;
using Cards.Presentation.Messaging.Pipeline.Exceptions;

namespace Cards.Presentation.Messaging.Pipeline.Steps.PlayerJoinsGame
{
    public class DoesGameExist
    {
        public DoesGameExist(PlayerJoinedGameEvent ev)
        {
            if(!ev.Game.IsSuccessful)
                throw new NotFoundException("Game not found");
            
        }
    }
}