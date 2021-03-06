﻿using System;
using System.Collections.Generic;
using System.Linq;
using Cards.Lobby.Components;

namespace Cards.Lobby.GameComponents
{
    public abstract class Game
    {
        public string GroupName { get { return Id.ToString(); } }

        public int MaxPlayers { get; protected set; }
        public int CurrentPlayers {get { return GetPlayers().Count; }}
        protected PlayerCollection PlayerCollection { get; set; }

        public Guid Id { get; private set; }
        public GameStatus Status { get; protected set; }
        public string GameType { get; protected set; }
        public string GameName { get; protected set; }

        protected Game(string gameType, string displayName, int maxPlayers)
        {
            MaxPlayers = maxPlayers;
            PlayerCollection = new PlayerCollection();

            Id = Guid.NewGuid();
            Status = GameStatus.WaitingForPlayers;
            GameType = gameType;
            GameName = displayName;
        }

        public Maybe<Player> GetPlayer(string id)
        {
            return PlayerCollection.GetPlayer(id);
        }

        public ICollection<Player> GetPlayers()
        {
            return PlayerCollection;
        }

        public Maybe<Player> AddPlayer(Player player)
        {
            if(Status == GameStatus.WaitingForPlayers)
            {
                if (PlayerCollection.PlayerCount < MaxPlayers)
                {
                    PlayerCollection.AddPlayer(player);
                    PlayerAdded(player);
                    return new Maybe<Player>(player);
                }
            }

            return new Maybe<Player>();
        }

        protected abstract void PlayerAdded(Player player);
    

        public bool StartGame()
        {
                Status = GameStatus.InProgress;
                return true;
        }

        public bool EndGame()
        {
            if (Status == GameStatus.InProgress)
            {
                Status = GameStatus.Finished;
                return true;
            }
            return false;
        }
        
    }

    public enum GameStatus
    {
        WaitingForPlayers,
        InProgress,
        Finished
    }
}
