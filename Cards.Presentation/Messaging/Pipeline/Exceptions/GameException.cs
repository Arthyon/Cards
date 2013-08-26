using System;

namespace Cards.Presentation.Messaging.Pipeline.Exceptions
{
    public class GameException : Exception
    {
        public GameException(string message) :base(message)
        {
            
        }
        public GameException(string formatMessage, params object[] parameters) : base(string.Format(formatMessage, parameters))
        {

        }
    }
}