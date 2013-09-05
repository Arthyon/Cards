using Cards.Lobby;
using Cards.Messaging.Pipeline;
using Microsoft.AspNet.SignalR;

namespace Cards.Presentation.Games.PlanningPoker.Messaging.Events
{
    public class PlanningPokerEventBase : EventBase
    {
        public IHubContext HubContext { get; private set; }
        public PlanningPokerGame CurrentGame { get; private set; }
        public Player CurrentPlayer { get; private set; }

        public PlanningPokerEventBase(IHubContext hubContext, PlanningPokerGame game, Player currentPlayer)
        {
            HubContext = hubContext;
            CurrentGame = game;
            CurrentPlayer = currentPlayer;
        }
    }
}