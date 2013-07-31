using Cards.Lobby;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;


namespace Cards.Presentation.Lobby
{
    [HubName("LobbyHub")]
    public class SignalRLobby : Hub, ILobby
    {
        private readonly GameLobby _lobby;

        public SignalRLobby()
        {
            _lobby = new GameLobby();
        }

        public void JoinGame()
        {
            
        }
    }
    
}