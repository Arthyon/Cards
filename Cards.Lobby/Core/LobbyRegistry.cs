using Cards.Lobby.LobbyComponents;
using Cards.Lobby.User;
using StructureMap.Configuration.DSL;

namespace Cards.Lobby.Core
{
    public class LobbyRegistry : Registry
    {
        public LobbyRegistry()
        {
            For<ILobby>().Singleton().Use<GameLobby>();
            For<IUserManager>().Singleton().Use<UserManager>();
        }
    }
}
