using System;
using Cards.Presentation.Messaging.Pipeline.Events;

namespace Cards.Presentation.Messaging.Pipeline.Steps.PlayerJoinsGame
{
    public class AddPlayerToGameStep
    {
        public static void AddPlayerToGame(PlayerJoinedGameEvent ev)
        {
            var result = ev.Game.Result.AddPlayer(ev.Player);
            if(!result.IsSuccessful)
                throw new Exception("Failed"); //TODO {Christian} Fix this exception
        }
    }
}