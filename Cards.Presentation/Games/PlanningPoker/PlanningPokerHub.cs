using System.Web;
using Cards.Lobby.LobbyComponents;
using Cards.Lobby.User;
using Cards.Presentation.Core;
using Cards.Presentation.Lobby;
using Cards.Presentation.Messaging.Pipeline;
using Cards.Presentation.Messaging.Pipeline.Events;
using Microsoft.AspNet.SignalR.Hubs;

namespace Cards.Presentation.Games.PlanningPoker
{
    [HubName(GameTypes.PlanningPoker)]
    public class PlanningPokerHub : GameTypeHubBase<PlanningPokerHub, PlanningPokerGame>
    {
        public PlanningPokerHub(ILobby lobby, IUserManager userManager, IPipelines pipelines) : base(lobby, userManager, pipelines)
        {
        }

        public override void CreateGame()
        {
            var tempGame = new PlanningPokerGame(5);
            Pipelines.GameCreatedPipeline.Execute(new GameCreatedEvent(tempGame, Get.CurrentPlayer));
        }

        public void SendMessage(string message)
        {
            var player = Get.CurrentPlayer;
            string id = player.CurrentGame.Result.Id.ToString();

            dynamic group = Clients.Group(id);
            var msg = new {User = player.Name, Message = message};
            group.messageSent(msg);
        }


        protected override async void UserConnected()
        {
            var player = Get.CurrentPlayer;
            string id = player.CurrentGame.Result.Id.ToString();
            await Groups.Add(Context.ConnectionId, id);
            
        }

        protected override void UserDisconnected()
        {
           
        }
    }
}