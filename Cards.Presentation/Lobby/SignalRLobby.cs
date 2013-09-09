using Cards.Lobby.User;
using Cards.Messaging.Core;
using Cards.Messaging.Endpoints;
using Cards.Messaging.Pipeline;
using Cards.Presentation.Core;
using Cards.Presentation.Messaging.Messages;
using Microsoft.AspNet.SignalR.Hubs;


namespace Cards.Presentation.Lobby
{
    [HubName("LobbyHub")]
    public class SignalRLobby : HubBase<SignalRLobby>, IMessageEndpoint
    {
        public SignalRLobby(IUserManager userManager, IPipelineLocator pipelines) : base(userManager, pipelines)
        {
        }

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
            var gameUpdatedMessage = message as GameStartedMessage;
            if (gameUpdatedMessage != null)
            {
                Broadcast.Clients.All.gameStarted(gameUpdatedMessage.Game.Id);
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