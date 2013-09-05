using Cards.Presentation.Messaging.Pipeline.Events;
using Cards.Presentation.Messaging.Pipeline.Events.PlayerEvents;

namespace Cards.Presentation.Messaging.Pipeline.Steps.PlayerConnectedToHub
{
    public class AddConnectionIdToPlayerStep
    {
        public static bool AddConnectionIdToPlayer(PlayerConnectedToHubEvent ev)
        {
            ev.Player.AddConnectionId(ev.ConnectionId);
            return true;
        }

    }
}