using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Cards.Lobby;
using Cards.Lobby.User;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Cards.Presentation.Core
{
    public abstract class HubBase<T> : Hub where T : IHub
    {
        protected IHubContext Broadcast { get; private set; }

        protected IUserContext UserContext {get { return _userContextProvider.UserContext; }}

        protected IUserManager UserManager { get; private set; }

        protected static readonly ConcurrentDictionary<string, Player> ConnectedPlayers = new ConcurrentDictionary<string, Player>();

        private readonly IUserContextProvider _userContextProvider;

        protected HubBase()
        {
            _userContextProvider = Locate<IUserContextProvider>.Instance;
            Broadcast = GlobalHost.ConnectionManager.GetHubContext<T>();
            UserManager = Locate<IUserManager>.Instance;
        }

        public override Task OnConnected()
        {
            if (!ConnectedPlayers.ContainsKey(Context.User.Identity.Name))
            {
                var player = UserManager.GetPlayer(Context.User.Identity.Name);
                if (player.IsSuccessful)
                {
                    if (ConnectedPlayers.TryAdd(Context.User.Identity.Name, player.Result))
                    {
                        UserConnected();
                    }
                }
            }
            return base.OnConnected();
        }

        protected abstract void UserConnected();
        protected abstract void UserDisconnected();

        public override Task OnDisconnected()
        {
            var player = UserManager.GetPlayer(Context.User.Identity.Name);
            if (player.IsSuccessful)
            {
                Player p;
                if (ConnectedPlayers.TryRemove(Context.User.Identity.Name, out p))
                {
                    UserDisconnected();
                }
            }
            return base.OnDisconnected();
        }

        
    }
}