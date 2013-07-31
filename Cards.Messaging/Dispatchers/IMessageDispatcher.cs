using Cards.Messaging.Core;

namespace Cards.Messaging.Dispatchers
{
    public interface IMessageDispatcher
    {
        /// <summary>
        /// Returns number of endpoints that handled this message
        /// </summary>
        int DispatchMessage(IDispatchMessage message);
    }
}