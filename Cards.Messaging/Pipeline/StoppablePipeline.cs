using System;

namespace Cards.Messaging.Pipeline
{
    public class StoppablePipeline<T> : Pipeline<T> where T : EventBase
    {
        public bool Stopped { get; private set; }

        public override void Execute(T input)
        {
            foreach (var action in Actions)
            {
                var succeeded = action(input);
                if (!succeeded)
                {
                    Stopped = true;
                    break;
                }
            }
        }

        public StoppablePipeline<T> Register(Func<T, bool> condition, Action<T> successEvent, Action<T> failEvent)
        {
            Func<T, bool> act = d =>
            {
                if (condition(d))
                {
                    successEvent(d);
                    return true;
                }
                else
                {
                    failEvent(d);
                    return false;
                }
            };
            Actions.Add(act);
            return this;
        }

        public new StoppablePipeline<T> Register(Func<T, bool> action)
        {
            Actions.Add(action);
            return this;
        }
    }
}
