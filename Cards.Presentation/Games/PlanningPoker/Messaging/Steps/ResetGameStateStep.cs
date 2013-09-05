using Cards.Presentation.Games.PlanningPoker.Messaging.Events;

namespace Cards.Presentation.Games.PlanningPoker.Messaging.Steps
{
    public class ResetGameStateStep
    {
        public static bool ResetGameState(PokerNewRoundStartedEvent ev)
        {
            ev.CurrentGame.NewRound();
            return true;
        }
    }
}