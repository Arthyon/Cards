using Cards.Lobby.LobbyComponents;
using Cards.Presentation.Lobby;
using Cards.Presentation.Messaging.Pipeline;
using Cards.Presentation.Messaging.Pipeline.Events;
using Microsoft.AspNet.SignalR.Hubs;

namespace Cards.Presentation.Games.PlanningPoker
{
    [HubName(GameTypes.PlanningPoker)]
    public class PlanningPokerHub : GameTypeHubBase<PlanningPokerHub, PlanningPokerGame>
    {
        private readonly IPipelines _pipelines;

        public PlanningPokerHub(ILobby lobby, IPipelines pipelines)
            : base(lobby, pipelines)
        {
            _pipelines = pipelines;
        }

        public override void CreateGame(PlanningPokerGame game)
        {
            var tempGame = new PlanningPokerGame(5);
            _pipelines.GameCreatedPipeline.Execute(new GameCreatedEvent(tempGame, UserContext.Player));
        }

        public void SendMessage(string message)
        {
            string id = UserContext.CurrentGame.Result.Id.ToString();

            dynamic group = Clients.Group(id);
            var msg = new {User = UserContext.Player.Name, Message = message};
            group.messageSent(msg);
        }


        protected override async void UserConnected()
        {
            string id = UserContext.CurrentGame.Result.Id.ToString();
            await Groups.Add(Context.ConnectionId, id);
            UserContext.Player.IsOnline = true;
        }

        protected override void UserDisconnected()
        {
            UserContext.Player.IsOnline = false;
        }
    }
}