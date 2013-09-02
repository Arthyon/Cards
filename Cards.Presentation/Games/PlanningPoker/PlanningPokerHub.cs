using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cards.Lobby;
using Cards.Lobby.GameComponents;
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

        public void StartGame()
        {
            var game = CurrentPlayer.CurrentGame.Result;
            if (game.Status == GameStatus.WaitingForPlayers)
            {
                game.StartGame();
                NewRound();
            }
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

            NewRound();
            
            
        }

        protected override void UserDisconnected()
        {
            
        }

        private void NewRound()
        {
           
            var currentGame = CurrentPlayer.CurrentGame.Result as PlanningPokerGame;

            var roundState = new PlanningPokerGameState()
            {
                InProgress = currentGame.Status == GameStatus.InProgress,
                Cards = _defaultHand,
                BoardState = GetBoardState(currentGame)
            };
            Clients.Group(currentGame.Id.ToString()).syncState(roundState);
        }

        

        private PlanningPokerBoardState GetBoardState(PlanningPokerGame currentGame)
        {
            
            return new PlanningPokerBoardState
                {
                    Players = currentGame.PlayerInformation()
                };
        }

        public void PlayCard(int value)
        {
            var currentPlayer = Get.CurrentPlayerFromContext(Context);
            var currentGame = currentPlayer.CurrentGame.Result as PlanningPokerGame;
            currentGame.PlayCard(currentPlayer, value);
            UpdateBoardState();
        }



        private void UpdateBoardState()
        {
            var currentGame = Get.CurrentPlayerFromContext(Context).CurrentGame.Result as PlanningPokerGame;

            Broadcast.Clients.Group(currentGame.Id.ToString())
                .boardStateUpdated(GetBoardState(currentGame));
        }

        public void UpdateInformation(string newRole)
        {
            PlanningPokerRole role;
            switch (newRole)
            {
                case "Board":
                    role = PlanningPokerRole.Board;
                    break;
                default:
                    role = PlanningPokerRole.Player;
                    break;
            }

            var currentGame = CurrentPlayer.CurrentGame.Result as PlanningPokerGame;
            currentGame.GetPokerPlayerContext(CurrentPlayer).CurrentRole = role;

            UpdateBoardState();
        }


    }
}