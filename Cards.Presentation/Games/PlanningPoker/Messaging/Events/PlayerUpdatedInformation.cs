using Cards.Lobby;
using Cards.Presentation.Games.PlanningPoker.Objects;
using Microsoft.AspNet.SignalR;

namespace Cards.Presentation.Games.PlanningPoker.Messaging.Events
{
    public class PlayerUpdatedInformationEvent : PlanningPokerEventBase
    {
        public PlanningPokerRole NewRole { get; private set; }

        public PlayerUpdatedInformationEvent(IHubContext hubContext, PlanningPokerGame game, Player currentPlayer, PlanningPokerRole newRole) : base(hubContext, game, currentPlayer)
        {
            NewRole = newRole;
        }
    }
}