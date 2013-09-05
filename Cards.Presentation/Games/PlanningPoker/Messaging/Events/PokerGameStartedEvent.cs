using Cards.Lobby;
using Microsoft.AspNet.SignalR;

namespace Cards.Presentation.Games.PlanningPoker.Messaging.Events
{
    public class PokerGameStartedEvent : PlanningPokerEventBase
    {
        public PokerGameStartedEvent(IHubContext hubContext, PlanningPokerGame game, Player currentPlayer) : base(hubContext, game, currentPlayer)
        {
        }
    }
}