using System;
using System.Collections.Concurrent;
using Cards.Lobby;
using Cards.Lobby.LobbyComponents;
using Cards.Lobby.User;
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

        private static readonly ConcurrentDictionary<string, Player> ConnectedPlayers = new ConcurrentDictionary<string, Player>();
        private readonly IUserManager _userManager;

        public SignalRLobby(IUserManager userManager)
        {
            _userManager = userManager;
        }
        public bool CanHandleMessage(IDispatchMessage message)
        {
            return message is GameCreatedMessage;
        }

        public void HandleMessage(IDispatchMessage message)
        {
            var gameCreatedMessage = message as GameCreatedMessage;
            Broadcast.Clients.All.addGameToList(gameCreatedMessage.CreatedGame);
        }

        public override System.Threading.Tasks.Task OnConnected()
        {
            if (!ConnectedPlayers.ContainsKey(Context.User.Identity.Name))
            {
                var player = _userManager.GetPlayer(Context.User.Identity.Name);
                if (player.IsSuccessful)
                {
                    player.Result.IsOnline = true;
                    ConnectedPlayers.TryAdd(Context.User.Identity.Name, player.Result);
                    PlayersChanged();
                }
                
            }
            
            return base.OnConnected();
        }

        public override System.Threading.Tasks.Task OnDisconnected()
        {
            var player = _userManager.GetPlayer(Context.User.Identity.Name);
            if (player.IsSuccessful)
            {
                Player p;
                if (ConnectedPlayers.TryRemove(Context.User.Identity.Name, out p))
                {
                    p.IsOnline = false;
                    PlayersChanged();
                }
            }
            
            return base.OnDisconnected();
        }

        public void PlayersChanged()
        {
            Broadcast.Clients.All.playersChanged(ConnectedPlayers.Count);
        }



    }

   
    
}