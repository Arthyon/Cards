using Cards.Lobby;
using Cards.Presentation.Messaging.Pipeline.Events.PlayerEvents;
using Cards.Presentation.Messaging.Pipeline.Exceptions;

namespace Cards.Presentation.Messaging.Pipeline.Steps.PlayerDisconnectedFromHub
{
    public class RemovePlayerFromCurrentPlayersStep
    {
        public static void RemovePlayerFromCurrentPlayers(PlayerDisconnectedFromHubEvent ev)
        {
                Player p;
                if (!ev.CurrentPlayers.TryRemove(ev.Player.Identifier, out p))
                throw new GameException("Couldn't remove player from current players");
        }
    }
}