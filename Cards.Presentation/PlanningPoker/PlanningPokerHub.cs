using System;
using System.Diagnostics;
using System.Threading.Tasks;
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
        public PlanningPokerHub(ILobby lobby, IMessageDispatcher dispatcher) : base(lobby, dispatcher)
        {

        }

        public override void CreateGame()
        {
            var game = new PlanningPokerGame(5);
            Lobby.StartGame(game);
           
            UserContext.JoinGame(game.Id);
            
            var result = MessageDispatcher.DispatchMessage(new GameCreatedMessage(game));
            Debug.Assert(result > 0);

        }

        public void SendMessage(string message)
        {
            var id = UserContext.CurrentGame.Result.Id.ToString();
            
            var group = Clients.Group(id);
            var msg = new {User = UserContext.Player.Name, Message = message};
            group.messageSent(msg);

        }


        protected async override void UserConnected()
        {
            var id = UserContext.CurrentGame.Result.Id.ToString();
            await Groups.Add(Context.ConnectionId, id);
            UserContext.Player.IsOnline = true;
            
        }

        protected override void UserDisconnected()
        {
            UserContext.Player.IsOnline = false;
        }
    }
}