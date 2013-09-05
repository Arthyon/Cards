using Cards.Presentation.Games.PlanningPoker.Messaging.Events;

namespace Cards.Presentation.Games.PlanningPoker.Messaging.Steps
{
    public class ChangePlayerRoleStep
    {
        public static bool ChangePlayerRole(PlayerUpdatedInformationEvent ev)
        {
            ev.CurrentGame.GetPokerPlayerContext(ev.CurrentPlayer).CurrentRole = ev.NewRole;

            return true;
        }
    }
}