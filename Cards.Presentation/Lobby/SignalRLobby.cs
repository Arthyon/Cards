using System;
using System.Collections.Generic;
using Cards.Lobby.GameComponents;
using Cards.Lobby.LobbyComponents;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;


namespace Cards.Presentation.Lobby
{
    [HubName("LobbyHub")]
    public class SignalRLobby : Hub
    {
        private readonly ILobby _lobby;

        public SignalRLobby(ILobby lobby)
        {
            _lobby = lobby;
        }

    }

   
    
}