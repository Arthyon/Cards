using Cards.Lobby.GameComponents;
using Cards.Presentation.Games.PlanningPoker.Messaging.Events;

namespace Cards.Presentation.Games.PlanningPoker.Messaging.Steps
{
    public class CanGameStartStep
    {
        public static bool CanGameStart(PokerGameStartedEvent ev)
        {
            return ev.CurrentGame.Status == GameStatus.WaitingForPlayers;
        }
    }
}