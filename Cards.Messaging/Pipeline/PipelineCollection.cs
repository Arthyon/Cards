using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Messaging.Pipeline
{
    public sealed class PipelineCollection : IPipelineLocator
    {
        private readonly Dictionary<Type, object> _collection = new Dictionary<Type, object>();

        public void Add<T>(Pipeline<T> pipeline) where T : EventBase
        {
            var key = typeof (T);
            if (_collection.ContainsKey(key))
            {
                throw new Exception("Key already exists");
            }
            _collection.Add(typeof(T),pipeline);
        }

        public IEnumerable<PipelineBase> AllPipeLines()
        {
            return _collection.Select(i => i.Value).Cast<PipelineBase>();
        }

        Pipeline<T> IPipelineLocator.FindFor<T>()
        {
            var type = typeof(T);
            object value;
            if (_collection.TryGetValue(type, out value))
            {
                var pipeline = value as Pipeline<T>;
                if (pipeline != null)
                    return pipeline;
            }
            throw new Exception(string.Format("No pipeline configured for event: {0}", type.Name));
        }

        TPipeline IPipelineLocator.Find<TPipeline>()
        {
            var pipeline = _collection.FirstOrDefault(i => i.Value is TPipeline);
            
            var specificPipeline = pipeline.Value as TPipeline;
            if (specificPipeline != null)
                return specificPipeline;

            throw new Exception("Pipeline not of specified type");
        }

    }
}
