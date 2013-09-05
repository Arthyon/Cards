
using Cards.Presentation.Games.PlanningPoker.Messaging.Events;

namespace Cards.Presentation.Games.PlanningPoker.Messaging.Steps
{
    public class PlayCardForPlayerStep
    {
        public static bool PlayCardForPlayer(PlayerPlayedCardEvent ev)
        {
            ev.CurrentGame.PlayCard(ev.CurrentPlayer, ev.CardValue);
            return true;
        }
    }
}