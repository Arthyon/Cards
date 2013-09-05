
using Cards.Presentation.Core;
using Cards.Presentation.Games.PlanningPoker.Messaging.Events;
using Cards.Presentation.Games.PlanningPoker.Objects;

namespace Cards.Presentation.Games.PlanningPoker.Messaging.Steps
{
    public class BroadcastOwnStateToPlayerStep
    {
        public static bool BroadcastOwnStateToPlayer(PlanningPokerEventBase ev)
        {
            var status = new CurrentPlayerStatus(ev.CurrentGame.GetPokerPlayerContext(ev.CurrentPlayer));
            foreach (var connectionId in ev.CurrentPlayer.ConnectionIds)
            {
                ev.HubContext.Clients.Client(connectionId).updateClientState(status);
            }
            

            return true;
        }
    }
}