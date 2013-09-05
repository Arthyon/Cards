using Cards.Lobby.LobbyComponents;
using Cards.Lobby.User;
using Cards.Messaging.Pipeline;
using Cards.Presentation.Core;
using Cards.Presentation.Games.PlanningPoker.Messaging.Events;
using Cards.Presentation.Games.PlanningPoker.Objects;
using Cards.Presentation.Lobby;
using Cards.Presentation.Messaging.Pipeline.Events;
using Microsoft.AspNet.SignalR.Hubs;

namespace Cards.Presentation.Games.PlanningPoker
{
    [HubName(GameTypes.PlanningPoker)]
    public class PlanningPokerHub : GameTypeHubBase<PlanningPokerHub, PlanningPokerGame>
    {
        
        public PlanningPokerHub(ILobby lobby, IUserManager userManager, IPipelineLocator pipelines) : base(lobby, userManager, pipelines)
        {
            
        }

        /// <summary>
        /// Called from client when setup phase is done, and administrator decides to start the game
        /// </summary>
        public void StartGame()
        {
            Pipelines.Find<PokerGameStartedEvent>().Execute(
                new PokerGameStartedEvent(
                        hubContext: Broadcast, 
                        game: CurrentGame, 
                        currentPlayer:CurrentPlayer));
        }

        /// <summary>
        /// Called from the lobby when a player creates a new game
        /// Creates the game with default settings which can be changed later in setup phase
        /// </summary>
        public override void CreateGame()
        {
            Pipelines.Find<GameCreatedEvent>().Execute(
                new GameCreatedEvent(
                    createdGame: new PlanningPokerGame(5), 
                    gameOwner: Get.CurrentPlayer));
        }

        /// <summary>
        /// Called when a user connects to the game
        /// </summary>
        protected override void UserConnected()
        {
            Pipelines.Find<PlayerJoinedPokerEvent>().Execute(
               new PlayerJoinedPokerEvent(
                   hubContext: Broadcast, 
                   newConnectionId: Context.ConnectionId, 
                   currentGame: CurrentGame, 
                   currentPlayer: CurrentPlayer));
        }

        protected override void UserDisconnected()
        {
            
        }

        /// <summary>
        /// Called when a user plays a card
        /// </summary>
        public void PlayCard(int value)
        {
            Pipelines.Find<PlayerPlayedCardEvent>().Execute(new PlayerPlayedCardEvent(Broadcast, CurrentGame, CurrentPlayer, cardValue: value));
            

        }

        public void StartNewRound()
        {
            Pipelines.Find<PokerNewRoundStartedEvent>().Execute(new PokerNewRoundStartedEvent(Broadcast, CurrentGame, CurrentPlayer));
        }


        /// <summary>
        /// Called when a user updates his information. Currently restricted to changing to a new role
        /// </summary>
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

            Pipelines.Find<PlayerUpdatedInformationEvent>().Execute(new PlayerUpdatedInformationEvent(Broadcast, CurrentGame, CurrentPlayer, newRole: role));
        }

    }
}