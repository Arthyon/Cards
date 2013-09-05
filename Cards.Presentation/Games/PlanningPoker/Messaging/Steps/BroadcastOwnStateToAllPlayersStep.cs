using Cards.Presentation.Games.PlanningPoker.Messaging.Events;

namespace Cards.Presentation.Games.PlanningPoker.Messaging.Steps
{
    public class BroadcastOwnStateToAllPlayersStep
    {
        public static bool BroadcastOwnStateToAllPlayers(PlanningPokerEventBase ev)
        {
            foreach (var player in ev.CurrentGame.GetPlayers())
            {
                BroadcastOwnStateToPlayerStep.BroadcastOwnStateToPlayer(new PlanningPokerEventBase(ev.HubContext, ev.CurrentGame, player));
            }
            return true;
        }
    }
}