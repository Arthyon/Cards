namespace Cards.Presentation.Messaging.Pipeline.Exceptions
{
    public class NotFoundException : GameException
    {
        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string formatMessage, params object[] parameters) : base(formatMessage, parameters)
        {
        }
    }
}