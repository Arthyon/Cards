using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Cards.Presentation.Core
{
    public abstract class HubBase<T> : Hub where T : IHub
    {
        protected IHubContext Broadcast { get; private set; }

        protected HubBase()
        {
            Broadcast = GlobalHost.ConnectionManager.GetHubContext<T>();
        }
    }
}