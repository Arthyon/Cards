using System;
using System.Diagnostics;
using Cards.Lobby.LobbyComponents;
using Cards.Messaging.Dispatchers;
using Cards.Presentation.Common.Messages;
using Cards.Presentation.Lobby;
using Microsoft.AspNet.SignalR.Hubs;

namespace Cards.Presentation.PlanningPoker
{


    [HubName(GameTypes.PlanningPoker)]
    public class PlanningPokerHub : GameTypeHubBase<PlanningPokerHub, PlanningPokerGame>
    {
       
        private readonly IMessageDispatcher _dispatcher;


        public PlanningPokerHub(ILobby lobby, IMessageDispatcher dispatcher) : base(lobby)
        {
            _dispatcher = dispatcher;
        }

        
        public override void CreateGame()
        {
            var game = new PlanningPokerGame(5);
            Lobby.StartGame(game);
            UserContext.JoinGame(game.Id);
            var result = _dispatcher.DispatchMessage(new GameCreatedMessage(game));
            Debug.Assert(result > 0);

            
        }
    }
}