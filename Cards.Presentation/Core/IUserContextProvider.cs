using System;

namespace Cards.Presentation.Core
{
    public interface IUserContextProvider
    {
        IUserContext UserContext { get; }
    }

    public class UserContextProvider : IUserContextProvider
    {
        private readonly Func<IUserContext> provider; 
        public UserContextProvider(Func<IUserContext> provider)
        {
            this.provider = provider;
        }

        public IUserContext UserContext
        {
            get { return provider(); }
        }
    }
}
