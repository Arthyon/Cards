using System;
using System.Collections.Generic;

namespace Cards.Presentation.Messaging.Pipeline
{
    public class Pipeline<T>
    {
        private readonly List<Action<T>> _actions = new List<Action<T>>();

        public void Execute(T input)
        {
            _actions.ForEach(ac => ac(input));
        }

        public Pipeline<T> Register(Action<T> action)
        {
            _actions.Add(action);
            return this;
        }
    }
}