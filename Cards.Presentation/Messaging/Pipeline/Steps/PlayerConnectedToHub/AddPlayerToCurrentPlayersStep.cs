using Cards.Presentation.Messaging.Pipeline.Events.PlayerEvents;
using Cards.Presentation.Messaging.Pipeline.Exceptions;

namespace Cards.Presentation.Messaging.Pipeline.Steps.PlayerConnectedToHub
{
    public class AddPlayerToCurrentPlayersStep
    {
        public static void AddPlayerToCurrentPlayers(PlayerConnectedToHubEvent ev)
        {
            if (!ev.CurrentPlayers.ContainsKey(ev.Player.Identifier))
            {
                if (!ev.CurrentPlayers.TryAdd(ev.Player.Identifier, ev.Player))
                    throw new GameException("Could not add player to list of connected players");
            }
            
        }
    }
}