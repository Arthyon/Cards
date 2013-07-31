using Cards.Lobby.GameComponents;

namespace Cards.Presentation.PlanningPoker
{
    public class PlanningPokerGame : Game
    {
        public PlanningPokerGame(int maxPlayers) : base(GameTypes.PlanningPoker,"Planning Poker", maxPlayers)
        {
        }
    }
}