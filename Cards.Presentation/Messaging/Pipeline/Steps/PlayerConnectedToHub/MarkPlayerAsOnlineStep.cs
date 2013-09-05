using Cards.Presentation.Messaging.Pipeline.Events.PlayerEvents;

namespace Cards.Presentation.Messaging.Pipeline.Steps.PlayerConnectedToHub
{
    public class MarkPlayerAsOnlineStep
    {
        public static bool MarkPlayerAsOnline(PlayerConnectedToHubEvent ev)
        {
            ev.Player.IsOnline = true;

            return true;
        }
    }
}