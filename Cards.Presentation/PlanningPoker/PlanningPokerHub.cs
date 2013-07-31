using Cards.Lobby.LobbyComponents;
using Cards.Messaging.Dispatchers;
using Cards.Presentation.Common.Messages;
using Cards.Presentation.Core;
using Cards.Presentation.Lobby;
using Microsoft.AspNet.SignalR.Hubs;

namespace Cards.Presentation.PlanningPoker
{


    [HubName(GameTypes.PlanningPoker)]
    public class PlanningPokerHub : HubBase<PlanningPokerHub>, IGameTypeHubBase<PlanningPokerGame>
    {
        private readonly ILobby _lobby;
        private readonly IMessageDispatcher _dispatcher;


        public PlanningPokerHub(ILobby lobby, IMessageDispatcher dispatcher)
        {
            _lobby = lobby;
            _dispatcher = dispatcher;
        }

        public PlanningPokerGame CreateGame()
        {
            var game = new PlanningPokerGame(5);
            _lobby.StartGame(game);
            _dispatcher.DispatchMessage(new GameCreatedMessage(game));

            return game;
        }
    }
}