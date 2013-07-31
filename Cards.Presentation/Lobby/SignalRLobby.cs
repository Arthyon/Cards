using Cards.Lobby;


namespace Cards.Presentation.Lobby
{
    public class SignalRLobby
    {
        private readonly GameLobby _lobby;

        public SignalRLobby()
        {
            _lobby = new GameLobby();
        }
    }
    
}