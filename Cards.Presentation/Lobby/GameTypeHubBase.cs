using System;
using Cards.Lobby.GameComponents;
using Cards.Lobby.LobbyComponents;
using Cards.Presentation.Core;
using Microsoft.AspNet.SignalR.Hubs;

namespace Cards.Presentation.Lobby
{
    public abstract class GameTypeHubBase<THub, TGame> : HubBase<THub> where TGame : Game where THub : IHub
    {
        protected readonly ILobby Lobby;

        protected GameTypeHubBase(ILobby lobby)
        {
            Lobby = lobby;
        }

        public abstract void CreateGame();

        public bool JoinGame(string id)
        {
            var game = Lobby.GetGame(Guid.Parse(id));
            if (game.IsSuccessful)
            {
                if(game.Result.AddPlayer(UserContext.Player).IsSuccessful)
                    return UserContext.JoinGame(Guid.Parse(id));
            }
            return false;
        }

        
    }
}