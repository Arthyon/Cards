using System;
using System.Collections.Generic;
using System.Linq;
using Cards.Lobby;
using Cards.Lobby.GameComponents;
using Cards.Presentation.Games.PlanningPoker.Objects;

namespace Cards.Presentation.Games.PlanningPoker
{
    public class PlanningPokerGame : Game
    {
        public PlanningPokerGame(int maxPlayers) : base(GameTypes.PlanningPoker,"Planning Poker", maxPlayers)
        {
            
            PokerPlayerContexts = new List<PlanningPokerPlayerContext>();
        }

        

        private List<PlanningPokerPlayerContext> PokerPlayerContexts { get; set; }

        public List<PlanningPokerPlayerInfo> PlayerInformation()
        {
            
                return PokerPlayerContexts.Select( i => new PlanningPokerPlayerInfo(i.Player, GetStatus(i.SelectedValue), i.CurrentRole)).ToList();
            
        }

        private string GetStatus(int? value)
        {
            if (EveryoneHasChosenCard)
                return value.Value.ToString();

            return value.HasValue ? "Card chosen" : "Pending";
        }

        protected override void PlayerAdded(Player player)
        {
            PokerPlayerContexts.Add(new PlanningPokerPlayerContext(player));
        }

        public PlanningPokerPlayerContext GetPokerPlayerContext(Player player)
        {
            return PokerPlayerContexts.First(list => list.Player.Identifier == player.Identifier);
        }

        public List<PlanningPokerPlayerContext> GetPokerPlayerContexts()
        {
            return PokerPlayerContexts;
        }

        public bool EveryoneHasChosenCard
        {
            get
            {
                return PokerPlayerContexts.TrueForAll(i => i.HasSelectedCard);
            }
        }

        public void PlayCard(Player player, int value)
        {

            GetPokerPlayerContext(player).SelectedValue = value;
            
        }

        public void NewRound()
        {
            foreach (var player in PokerPlayerContexts)
            {
                player.NewRound();
            }
        }
    }
}