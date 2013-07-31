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
  
        public bool CanHandleMessage(IDispatchMessage message)
        {
            return message is GameCreatedMessage;
        }

        public void HandleMessage(IDispatchMessage message)
        {
            var gameCreatedMessage = message as GameCreatedMessage;
            Broadcast.Clients.All.addGameToList(gameCreatedMessage.CreatedGame);
        }
    }

   
    
}