using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cards.Presentation.Messaging.Pipeline.Exceptions
{
    public abstract class GameException : Exception
    {
        protected GameException(string message) :base(message)
        {
            
        }
        protected GameException(string formatMessage, params object[] parameters) : base(string.Format(formatMessage, parameters))
        {

        }
    }
}