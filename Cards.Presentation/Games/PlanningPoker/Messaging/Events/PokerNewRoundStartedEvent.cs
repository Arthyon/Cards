using Cards.Lobby;
using Microsoft.AspNet.SignalR;

namespace Cards.Presentation.Games.PlanningPoker.Messaging.Events
{
    public class PokerNewRoundStartedEvent : PlanningPokerEventBase
    {
        public PokerNewRoundStartedEvent(IHubContext hubContext, PlanningPokerGame game, Player currentPlayer) : base(hubContext, game, currentPlayer)
        {
        }
    }
}