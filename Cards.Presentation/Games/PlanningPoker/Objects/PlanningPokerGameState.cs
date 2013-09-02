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
}