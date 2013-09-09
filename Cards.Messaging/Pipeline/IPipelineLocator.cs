
using System.Collections.Generic;

namespace Cards.Messaging.Pipeline
{
    public interface IPipelineLocator
    {
        IEnumerable<PipelineBase> AllPipeLines();
        
        Pipeline<T> FindFor<T>() where T : EventBase;

        TPipeline Find<TPipeline>() where TPipeline : PipelineBase;
    }
}
