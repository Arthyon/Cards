using System;

namespace Cards.Presentation.Messaging.Aspects
{
    public class ExceptionLoggingAspect<T>
    {
        public ExceptionLoggingAspect(Action<T> action)
        {
            Handle = action;
        }

        public void Execute(T input)
        {
            try
            {
                Handle(input);
            }
            catch
            {
                //Log here
                    //Log.Error("*** ERROR ***: {0}", ex);
                throw;
            }
        }

        private Action<T> Handle { get; set; }

    }
}