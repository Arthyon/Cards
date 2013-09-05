using Cards.Lobby;
using Microsoft.AspNet.SignalR;

namespace Cards.Presentation.Games.PlanningPoker.Messaging.Events
{
    public class PlayerPlayedCardEvent : PlanningPokerEventBase
    {
        public int CardValue { get; private set; }

        public PlayerPlayedCardEvent(IHubContext hubContext, PlanningPokerGame game, Player currentPlayer, int cardValue) : base(hubContext, game, currentPlayer)
        {
            CardValue = cardValue;
        }
    }
}