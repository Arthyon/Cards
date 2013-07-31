using Cards.Messaging.Core;
using Cards.Messaging.Endpoints;
using Cards.Presentation.Common.Messages;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;


namespace Cards.Presentation.Lobby
{
    [HubName("LobbyHub")]
    public class SignalRLobby : Hub, IMessageEndpoint
    {
  
        public bool CanHandleMessage(IDispatchMessage message)
        {
            return message is GameCreatedMessage;
        }

        public void HandleMessage(IDispatchMessage message)
        {
            var gameCreatedMessage = message as GameCreatedMessage;
            Clients.All.addGameToList(gameCreatedMessage.CreatedGame);
        }
    }

   
    
}