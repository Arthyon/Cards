using Cards.Lobby.LobbyComponents;
using Cards.Presentation.Lobby;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Cards.Presentation.PlanningPoker
{


    [HubName(GameTypes.PlanningPoker)]
    public class PlanningPokerHub : Hub, IGameTypeHubBase<PlanningPokerGame>
    {
        private readonly ILobby _lobby;


        public PlanningPokerHub(ILobby lobby)
        {
            _lobby = lobby;
            
            
        }

        public PlanningPokerGame CreateGame()
        {
            var game = new PlanningPokerGame(5);
            _lobby.StartGame(game);
            GlobalHost.ConnectionManager.GetHubContext<SignalRLobby>().Clients.All.updateGameList(_lobby.GetGames());
            
            
            return game;
        }
    }
}