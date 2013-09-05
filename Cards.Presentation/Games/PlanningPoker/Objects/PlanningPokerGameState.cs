using System.Collections.Generic;
using Cards.Lobby;

namespace Cards.Presentation.Games.PlanningPoker.Objects
{
    public enum PlanningPokerRole
    {
        Player,
        Board
    }
    public class PlanningPokerGameState
    {
        
        public bool InProgress { get; set; }
        
        public PlanningPokerBoardState BoardState { get; set; }
        public List<PlanningPokerCard> Cards { get; set; } 
    }

    public class PlanningPokerBoardState
    {
        public bool RoundFinished { get; set; }
        public bool GameContainsBoard { get; set; }
        public List<PlanningPokerPlayerInfo> AllPlayers { get; set; } 
        public List<PlanningPokerPlayerInfo> Players { get; set; } 
    }

    public class PlanningPokerPlayerInfo
    {
        public PlanningPokerPlayerInfo(Player player, string status, PlanningPokerRole role)
        {
            Name = player.Name;
            Status = status;
            Role = role.ToString();
        }
        public string Role { get; set; }
        public string Name { get; private set; }
        public string Status { get; private set; }
    }

    public class CurrentPlayerStatus
    {
        public CurrentPlayerStatus(PlanningPokerPlayerContext player)
        {
            Role = player.CurrentRole.ToString();
            IsPlayer = player.CurrentRole != PlanningPokerRole.Board;
            ChosenCard = player.SelectedValue;
        }
        public string Role { get; private set; }

        public bool IsPlayer { get; private set; }
        public int? ChosenCard { get; private set; }
    }
}