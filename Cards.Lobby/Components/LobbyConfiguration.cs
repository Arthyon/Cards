using StructureMap;

namespace Cards.Lobby.Components
{
    public interface ILobbyConfiguration
    {
        IContainer Container { get; set; }
    }

    internal class LobbyConfiguration : ILobbyConfiguration
    {
        public LobbyConfiguration()
        {
            Container = new Container();
        }

        public IContainer Container { get; set; }
    }
}
