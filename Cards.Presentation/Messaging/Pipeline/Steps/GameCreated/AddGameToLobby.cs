using Cards.Lobby.LobbyComponents;
using Cards.Presentation.Core;
using Cards.Presentation.Messaging.Messages;
using Cards.Presentation.Messaging.Pipeline.Events;

namespace Cards.Presentation.Messaging.Pipeline.Steps.GameCreated
{
    public class AddGameToLobby
    {
        public AddGameToLobby(GameCreatedEvent msg)
        {
            Locate<ILobby>.Instance.StartGame(msg.CreatedGame);
        }
    }
}