using Cards.Presentation.Games.PlanningPoker.Messaging.Events;

namespace Cards.Presentation.Games.PlanningPoker.Messaging.Steps
{
    public class StartPokerGameStep
    {
        public static bool StartPokerGame(PokerGameStartedEvent ev)
        {
            return ev.CurrentGame.StartGame();

        }
    }
}