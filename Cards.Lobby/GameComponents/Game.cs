using System;
using System.Collections.Generic;
using System.Linq;
using Cards.Lobby.Components;

namespace Cards.Lobby.GameComponents
{
    public abstract class Game
    {
        protected GameConfiguration Configuration { get; set; }
        protected PlayerCollection PlayerCollection { get; set; }

        public Guid GameId { get; private set; }
        public GameStatus Status { get; protected set; }
        public string GameType { get; protected set; }

        protected Game(string gameType, Action<IGameConfiguration> config)
        {
            Configuration = new GameConfiguration();
            PlayerCollection = new PlayerCollection();

            GameId = Guid.NewGuid();
            Status = GameStatus.WaitingForPlayers;
            GameType = gameType;

            config(Configuration);
        }

        public Maybe<Player> GetPlayer(Guid id)
        {
            return PlayerCollection.GetPlayer(id);
        }

        public ICollection<Player> GetPlayers()
        {
            return PlayerCollection;
        }

        public Maybe<Player> AddPlayer(Player player)
        {
            if(Status == GameStatus.WaitingForPlayers || (Status == GameStatus.InProgress && Configuration.PlayersCanJoinMidGame))
            {
                if (PlayerCollection.PlayerCount < Configuration.MaxPlayers)
                {
                    PlayerCollection.AddPlayer(player);
                    return new Maybe<Player>(player);
                }
            }

            return new Maybe<Player>();
        }

        public bool StartGame()
        {
            if (Status == GameStatus.WaitingForPlayers && PlayerCollection.PlayerCount >= Configuration.MinPlayers)
            {
                Status = GameStatus.InProgress;
                return true;
            }
            return false;
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
