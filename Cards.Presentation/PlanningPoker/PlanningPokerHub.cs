using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Cards.Lobby.LobbyComponents;
using Cards.Messaging.Dispatchers;
using Cards.Presentation.Lobby;
using Cards.Presentation.Messaging.Messages;
using Cards.Presentation.Messaging.Pipeline;
using Microsoft.AspNet.SignalR.Hubs;

namespace Cards.Presentation.PlanningPoker
{


    [HubName(GameTypes.PlanningPoker)]
    public class PlanningPokerHub : GameTypeHubBase<PlanningPokerHub, PlanningPokerGame>
    {
        private readonly IPipelineConfiguration _pipelines;

        public PlanningPokerHub(ILobby lobby, IMessageDispatcher dispatcher, IPipelineConfiguration pipelines) : base(lobby, dispatcher)
        {
            _pipelines = pipelines;
        }

        public override void CreateGame()
        {
            var game = new PlanningPokerGame(5);

            _pipelines.GameCreatedPipeline.Execute(new GameCreatedMessage(game, UserContext.Player));
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