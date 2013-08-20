using Cards.Lobby.LobbyComponents;
using Cards.Presentation.Core;
using Cards.Presentation.Messaging.Messages;

namespace Cards.Presentation.Messaging.Pipeline.Steps.GameCreated
{
    public class AddGameToLobby
    {
        public AddGameToLobby(GameCreatedMessage msg)
        {
            Locate<ILobby>.Instance.StartGame(msg.CreatedGame);
        }
    }
}