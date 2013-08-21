using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Cards.Lobby;
using Cards.Lobby.GameComponents;
using Cards.Lobby.LobbyComponents;
using Cards.Messaging.Dispatchers;
using Cards.Presentation.Core;
using Cards.Presentation.Messaging.Messages;
using Cards.Presentation.Messaging.Pipeline;
using Cards.Presentation.Messaging.Pipeline.Events;
using Microsoft.AspNet.SignalR.Hubs;

namespace Cards.Presentation.Lobby
{
    public abstract class GameTypeHubBase<THub, TGame> : HubBase<THub> where TGame : Game where THub : IHub
    {
        protected readonly ILobby Lobby;
        protected readonly IPipelines Pipelines;
        

        protected GameTypeHubBase(ILobby lobby, IPipelines pipelines)
        {
            Lobby = lobby;
            Pipelines = pipelines;
            
        }

        public abstract void CreateGame(TGame configuration);

        public bool JoinGame(string id)
        {
            var game = Lobby.GetGame(Guid.Parse(id));
            var player = UserContext.Player;

            Pipelines.PlayerJoinsGamePipeline.Execute(new PlayerJoinedGameEvent(game, player));

            return true;
        }

        public List<Player> PlayersInGame()
        {
            var game = UserContext.CurrentGame;
            if (game.IsSuccessful)
            {
                return game.Result.GetPlayers().ToList();
            }
            return new List<Player>();
        }

        
    }
}