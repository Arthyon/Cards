using Cards.Messaging.Core;
using Cards.Messaging.Endpoints;
using Cards.Presentation.Common.Messages;
using Cards.Presentation.Core;
using Microsoft.AspNet.SignalR.Hubs;


namespace Cards.Presentation.Lobby
{
    [HubName("LobbyHub")]
    public class SignalRLobby : HubBase<SignalRLobby>, IMessageEndpoint
    {

        public bool HandleMessage(IDispatchMessage message)
        {
            var gameCreatedMessage = message as GameCreatedMessage;
            if (gameCreatedMessage != null)
            {
                Broadcast.Clients.All.addGameToList(gameCreatedMessage.CreatedGame);
                return true;
            }
            var playerJoinedMessage = message as PlayerJoinedMessage;
            if (playerJoinedMessage != null)
            {
                Broadcast.Clients.All.updatePlayerCount(playerJoinedMessage.Game.Id, playerJoinedMessage.Game.CurrentPlayers);
            }

            return false;
        }

        protected override void UserConnected()
        {
            PlayersChanged();
        }

        protected override void UserDisconnected()
        {
            PlayersChanged();
        }

        public void PlayersChanged()
        {
            Broadcast.Clients.All.playersChanged(ConnectedPlayers.Count);
        }
    }

}