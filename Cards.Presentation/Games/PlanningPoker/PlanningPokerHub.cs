using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cards.Lobby.LobbyComponents;
using Cards.Lobby.User;
using Cards.Presentation.Core;
using Cards.Presentation.Games.PlanningPoker.Objects;
using Cards.Presentation.Lobby;
using Cards.Presentation.Messaging.Pipeline;
using Cards.Presentation.Messaging.Pipeline.Events;
using Microsoft.AspNet.SignalR.Hubs;

namespace Cards.Presentation.Games.PlanningPoker
{
    [HubName(GameTypes.PlanningPoker)]
    public class PlanningPokerHub : GameTypeHubBase<PlanningPokerHub, PlanningPokerGame>
    {
        private readonly List<PlanningPokerCard> _defaultHand = new List<PlanningPokerCard>
        {
            new PlanningPokerCard(1),
            new PlanningPokerCard(2),
            new PlanningPokerCard(3),
            new PlanningPokerCard(5),
            new PlanningPokerCard(8),
            new PlanningPokerCard(13),
            new PlanningPokerCard(20),
            new PlanningPokerCard(40),
            new PlanningPokerCard(100),
        }; 

        public PlanningPokerHub(ILobby lobby, IUserManager userManager, IPipelines pipelines) : base(lobby, userManager, pipelines)
        {
        }

        public override void CreateGame()
        {
            var tempGame = new PlanningPokerGame(5);

            Pipelines.GameCreatedPipeline.Execute(new GameCreatedEvent(tempGame, Get.CurrentPlayer));
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

        private void NewRound()
        {
            var currentPlayer = Get.CurrentPlayerFromContext(Context);
            var currentGame = currentPlayer.CurrentGame.Result as PlanningPokerGame;

            var roundState = new
            {
                Cards = _defaultHand,
                BoardState = GetBoardState(currentGame)
            };
            Clients.Caller.newRound(roundState);
        }

        private string GetStatus(PlanningPokerGame game, int? value)
        {
            if (game.EveryoneHasChosenCard)
                return value.Value.ToString();

            return value.HasValue ? "Card chosen" : "Pending";
        }

        private object GetBoardState(PlanningPokerGame currentGame)
        {
            
            return
                new
                {
                    Players =
                        currentGame.ChosenCard.Select(
                            i => new {Name = i.Item1, Status = GetStatus(currentGame, i.Item2)})
                };
        }

        public void PlayCard(int value)
        {
            var currentPlayer = Get.CurrentPlayerFromContext(Context);
            var currentGame = currentPlayer.CurrentGame.Result as PlanningPokerGame;
            currentGame.PlayCard(currentPlayer, value);
            UpdateBoardState();
        }

        public void RequestCurrentState()
        {
            NewRound();
        }

        private void UpdateBoardState()
        {
            var currentGame = Get.CurrentPlayerFromContext(Context).CurrentGame.Result as PlanningPokerGame;

            Broadcast.Clients.Group(currentGame.Id.ToString())
                .boardStateUpdated(GetBoardState(currentGame));
        }
    }
}