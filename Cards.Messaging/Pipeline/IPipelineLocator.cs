
namespace Cards.Messaging.Pipeline
{
    public interface IPipelineLocator
    {
        Pipeline<T> Find<T>() where T : EventBase;
    }
}
