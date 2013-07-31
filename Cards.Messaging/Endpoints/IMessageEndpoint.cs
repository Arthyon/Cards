using Cards.Messaging.Core;

namespace Cards.Messaging.Endpoints
{
    public interface IMessageEndpoint
    {
        bool CanHandleMessage(IDispatchMessage message);
        void HandleMessage(IDispatchMessage message);
    }
}