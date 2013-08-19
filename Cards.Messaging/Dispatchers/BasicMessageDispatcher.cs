
using System.Collections.Generic;
using System.Linq;
using Cards.Messaging.Core;
using Cards.Messaging.Endpoints;

namespace Cards.Messaging.Dispatchers
{
    public class BasicMessageDispatcher : IMessageDispatcher
    {
        protected IList<IMessageEndpoint> Endpoints;
 
        public BasicMessageDispatcher(IList<IMessageEndpoint> endpoints)
        {
            Endpoints = endpoints;
        }
        public int DispatchMessage(IDispatchMessage message)
        {
            var count = 0;
            foreach (var endpoint in Endpoints)
            {
                
                var handled = endpoint.HandleMessage(message);
                if(handled)
                    count++;
            }
            return count;
        }
    }
}
