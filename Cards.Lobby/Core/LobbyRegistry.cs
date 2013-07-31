using Cards.Lobby.LobbyComponents;
using StructureMap.Configuration.DSL;

namespace Cards.Lobby.Core
{
    public class LobbyRegistry : Registry
    {
        public LobbyRegistry()
        {
            For<ILobby>().Singleton().Use<GameLobby>();
        }
    }
}
