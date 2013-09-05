
using Cards.Presentation.Messaging.Pipeline.Events.PlayerEvents;

namespace Cards.Presentation.Messaging.Pipeline.Steps.PlayerDisconnectedFromHub
{
    public class MarkPlayerAsOfflineStep
    {
        public static bool MarkPlayerAsOffline(PlayerDisconnectedFromHubEvent ev)
        {
            ev.Player.IsOnline = false;
            return true;
        }
    }
}