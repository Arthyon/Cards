using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cards.Lobby;
using Cards.Messaging.Pipeline;

namespace Cards.Presentation.Messaging.Pipeline.Events.PlayerEvents
{
    public class PlayerDisconnectedFromHubEvent : EventBase
    {
        public Player Player { get; private set; }
        public ConcurrentDictionary<string,Player> CurrentPlayers { get; private set; }

        public PlayerDisconnectedFromHubEvent(Player player, ConcurrentDictionary<string, Player> currentPlayersInHub)
        {
            Player = player;
            CurrentPlayers = currentPlayersInHub;
        }
    }
}