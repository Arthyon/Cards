using Cards.Lobby;
using Microsoft.AspNet.SignalR;

namespace Cards.Presentation.Games.PlanningPoker.Messaging.Events
{
    public class PlayerJoinedPokerEvent : PlanningPokerEventBase
    {
        
        public string ConnectionId { get; private set; }
       

        public PlayerJoinedPokerEvent(IHubContext hubContext, string newConnectionId, PlanningPokerGame currentGame, Player currentPlayer) : base(hubContext, currentGame, currentPlayer)
        {
            ConnectionId = newConnectionId;

        }
    }
}