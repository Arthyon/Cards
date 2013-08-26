using System;
using System.Collections.Generic;
using System.Text;

namespace Cards.Messaging.Pipeline
{
    public class Pipeline<T> where T : EventBase
    {
        protected readonly List<Action<T>> Actions = new List<Action<T>>();

        public void Execute(T input)
        {
            Actions.ForEach(ac => ac(input));
        }

        public Pipeline<T> Register(Action<T> action)
        {
            Actions.Add(action);
            return this;
        }

        public string WhatDoIDo()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("When {0}:", typeof (T).Name.Replace("Event", ""));

            foreach (var action in Actions)
            {
                var classType = action.Method.DeclaringType;
                if (classType != null)
                {
                    sb.AppendFormat("\n Do {0}", classType.Name.Replace("Step", ""));
                }
                else
                {
                    sb.AppendFormat("\n Do Unknown step");
                }

            }
            return sb.ToString();
        }
    }
}