using Cards.Lobby;

namespace Cards.Presentation.Games.PlanningPoker.Objects
{
    public class PlanningPokerPlayerContext 
    {
        public PlanningPokerPlayerContext(Player player)
        {
            Player = player;
            CurrentRole = PlanningPokerRole.Player;
        }
        public Player Player { get; set; }

        public int? SelectedValue { get; set; }

        public bool HasSelectedCard {get { return SelectedValue.HasValue; }}

        public void NewRound()
        {
            SelectedValue = null;
        }

        public PlanningPokerRole CurrentRole { get; set; }

        
    }
}