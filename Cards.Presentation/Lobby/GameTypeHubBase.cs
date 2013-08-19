using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Cards.Lobby;
using Cards.Lobby.GameComponents;
using Cards.Lobby.LobbyComponents;
using Cards.Messaging.Dispatchers;
using Cards.Presentation.Common.Messages;
using Cards.Presentation.Core;
using Microsoft.AspNet.SignalR.Hubs;

namespace Cards.Presentation.Lobby
{
    public abstract class GameTypeHubBase<THub, TGame> : HubBase<THub> where TGame : Game where THub : IHub
    {
        protected readonly ILobby Lobby;
        protected IMessageDispatcher MessageDispatcher { get; private set; }

        protected GameTypeHubBase(ILobby lobby, IMessageDispatcher messageDispatcher)
        {
            Lobby = lobby;
            MessageDispatcher = messageDispatcher;
        }

        public abstract void CreateGame();

        public bool JoinGame(string id)
        {
            var game = Lobby.GetGame(Guid.Parse(id));
            if (game.IsSuccessful)
            {
                if (game.Result.AddPlayer(UserContext.Player).IsSuccessful)
                {
                    var i = MessageDispatcher.DispatchMessage(new PlayerJoinedMessage(game.Result, UserContext.Player));
                    Debug.Assert(i > 0);

                    Groups.Add(Context.ConnectionId, game.Result.Id.ToString());

                    return UserContext.JoinGame(Guid.Parse(id));
                }
                    
            }
            return false;
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