﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cards.Lobby;
using Cards.Lobby.GameComponents;
using Cards.Lobby.LobbyComponents;
using Cards.Lobby.User;
using Cards.Presentation.Core;
using Cards.Presentation.Messaging.Pipeline;
using Cards.Presentation.Messaging.Pipeline.Events;
using Microsoft.AspNet.SignalR.Hubs;

namespace Cards.Presentation.Lobby
{
    public abstract class GameTypeHubBase<THub, TGame> : HubBase<THub> where TGame : Game where THub : IHub
    {
        protected readonly ILobby Lobby;

        protected GameTypeHubBase(ILobby lobby, IUserManager userManager, IPipelines pipelines) : base(userManager, pipelines)
        {
            Lobby = lobby;
        }

        public abstract void CreateGame();

        public bool JoinGame(string id)
        {
            var game = Lobby.GetGame(Guid.Parse(id));
            

            Pipelines.PlayerJoinsGamePipeline.Execute(new PlayerJoinedGameEvent(game, Get.CurrentPlayer));

            return true;
        }

        public List<Player> PlayersInGame()
        {
            var game = Get.CurrentPlayer.CurrentGame;
            if (game.IsSuccessful)
            {
                return game.Result.GetPlayers().ToList();
            }
            return new List<Player>();
        }

        
    }
}