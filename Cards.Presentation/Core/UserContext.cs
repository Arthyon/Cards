using System;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.Security;
using Cards.Lobby;
using Cards.Lobby.Components;
using Cards.Lobby.GameComponents;
using Cards.Lobby.LobbyComponents;
using Cards.Lobby.User;

namespace Cards.Presentation.Core
{
    public class UserContext : IUserContext
    {
        private readonly IUserManager _userManager;
        private readonly ILobby _lobby;


        public UserContext(IUserManager userManager, ILobby lobby)
        {
            _userManager = userManager;
            _lobby = lobby;
        }

        public Player Player
        {
            get
            {
                return _userManager.GetPlayer(HttpContext.Current.User.Identity.Name).Result;
            } 
        }

        public string SessionId
        {
            get { return HttpContext.Current.User.Identity.Name; }
        }

        public bool JoinGame(Guid gameId)
        {
            if (Player.CurrentGame == null)
            {
                var game = _lobby.GetGame(gameId);
                if (game.IsSuccessful)
                {
                    if (game.Result.AddPlayer(Player).IsSuccessful)
                    {
                        Player.CurrentGame = game.Result;
                    }
                }
                
            }
            return false;
            
        }

        public Maybe<Game> CurrentGame
        {
            get { return new Maybe<Game>(Player.CurrentGame); }
        }
    }
}