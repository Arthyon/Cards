using Cards.Presentation.Games.PlanningPoker.Messaging.Events;

namespace Cards.Presentation.Games.PlanningPoker.Messaging.Steps
{
    public class AddConnectionIdToGameGroupStep
    {
        public static bool AddConnectionIdToGameGroup(PlayerJoinedPokerEvent ev)
        {
            Process(ev);
            return true;
        }

        private static async void Process(PlayerJoinedPokerEvent ev)
        {
            await ev.HubContext.Groups.Add(ev.ConnectionId, ev.CurrentGame.GroupName);
        }
    }
}