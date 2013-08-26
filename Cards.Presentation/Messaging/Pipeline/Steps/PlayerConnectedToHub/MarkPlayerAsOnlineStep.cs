using Cards.Presentation.Messaging.Pipeline.Events.PlayerEvents;

namespace Cards.Presentation.Messaging.Pipeline.Steps.PlayerConnectedToHub
{
    public class MarkPlayerAsOnlineStep
    {
        public static void MarkPlayerAsOnline(PlayerConnectedToHubEvent ev)
        {
            ev.Player.IsOnline = true;
        }
    }
}