using Cards.Presentation.Lobby;
using StructureMap.Configuration.DSL;

namespace Cards.Presentation.Core
{
    public class PresentationRegistry : Registry
    {
        public PresentationRegistry()
        {
            For<ILobby>().Singleton().Use<SignalRLobby>();
        }
    }
}