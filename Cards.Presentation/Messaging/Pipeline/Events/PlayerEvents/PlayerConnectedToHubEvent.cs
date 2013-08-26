
using System.Collections.Concurrent;
using Cards.Lobby;
using Cards.Messaging.Pipeline;

namespace Cards.Presentation.Messaging.Pipeline.Events.PlayerEvents
{
    public class PlayerConnectedToHubEvent : EventBase
    {
        public Player Player { get; private set; }
        public ConcurrentDictionary<string,Player> CurrentPlayers { get; private set; }
        public string ConnectionId { get; set; }
 
        public PlayerConnectedToHubEvent(Player player, ConcurrentDictionary<string, Player> currentPlayersInHub, string connectionId)
        {
            Player = player;
            CurrentPlayers = currentPlayersInHub;
            ConnectionId = connectionId;
        }
    }
}