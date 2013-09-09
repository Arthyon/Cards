using System;

namespace Cards.Presentation.Lobby
{
    public class ClientFeedbackException : Exception
    {
        public ClientFeedbackException(string message) : base(message)
        {
            
        }
    }
}