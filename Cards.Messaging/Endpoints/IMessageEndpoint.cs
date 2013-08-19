using Cards.Messaging.Core;

namespace Cards.Messaging.Endpoints
{
    public interface IMessageEndpoint
    {
        bool HandleMessage(IDispatchMessage message);
    }
}