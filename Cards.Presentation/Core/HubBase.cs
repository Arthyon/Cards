using System;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Cards.Presentation.Core
{
    public abstract class HubBase<T> : Hub where T : IHub
    {
        protected IHubContext Broadcast { get; private set; }

        protected IUserContext UserContext {get { return _userContextProvider.UserContext; }}

        private readonly IUserContextProvider _userContextProvider;

        protected HubBase()
        {
            _userContextProvider = Locate<IUserContextProvider>.Instance;
            Broadcast = GlobalHost.ConnectionManager.GetHubContext<T>();
        }

    }
}