using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using Cards.Lobby;
using Cards.Lobby.Components;
using Cards.Lobby.User;
using Cards.Presentation.Messaging.Pipeline;
using Cards.Presentation.Messaging.Pipeline.Events.PlayerEvents;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Cards.Presentation.Core
{
    public abstract class HubBase<T> : Hub where T : IHub
    {
        protected static readonly ConcurrentDictionary<string, Player> ConnectedPlayers =
            new ConcurrentDictionary<string, Player>();


        protected HubBase(IUserManager userManager, IPipelines pipelines)
        {
            Broadcast = GlobalHost.ConnectionManager.GetHubContext<T>();
            UserManager = userManager;
            Pipelines = pipelines;
        }

        protected IHubContext Broadcast { get; private set; }

        

        protected IUserManager UserManager { get; private set; }
        protected IPipelines Pipelines { get; private set; }

        public override Task OnConnected()
        {
            Pipelines.PlayerConnectedToHub.Execute(new PlayerConnectedToHubEvent(CurrentPlayer, ConnectedPlayers, Context.ConnectionId));
            UserConnected();
            return base.OnConnected();
        }

        protected abstract void UserConnected();
        protected abstract void UserDisconnected();

        public override Task OnDisconnected()
        {
            Pipelines.PlayerDisconnectedFromHub.Execute(new PlayerDisconnectedFromHubEvent(CurrentPlayer, ConnectedPlayers));

            UserDisconnected();
                
            return base.OnDisconnected();
        }

        protected Player CurrentPlayer
        {
            get
            {
                return Get.CurrentPlayerFromContext(Context);
            }
        }

    }

    
}