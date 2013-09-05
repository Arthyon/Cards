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

        public readonly List<PlanningPokerCard> DefaultHand = new List<PlanningPokerCard>
        {
            new PlanningPokerCard(1),
            new PlanningPokerCard(2),
            new PlanningPokerCard(3),
            new PlanningPokerCard(5),
            new PlanningPokerCard(8),
            new PlanningPokerCard(13),
            new PlanningPokerCard(20),
            new PlanningPokerCard(40),
            new PlanningPokerCard(100),
        }; 

        public PlanningPokerGame(int maxPlayers) : base(GameTypes.PlanningPoker,"Planning Poker", maxPlayers)
        {
            
            PokerPlayerContexts = new List<PlanningPokerPlayerContext>();
        }

        

        private List<PlanningPokerPlayerContext> PokerPlayerContexts { get; set; }

        public List<PlanningPokerPlayerInfo> PlayerInformation(bool includeBoard = true)
        {
            if (includeBoard)
            {
                return PokerPlayerContexts.Select(i => new PlanningPokerPlayerInfo(i.Player, GetStatus(i.SelectedValue), i.CurrentRole)).ToList();
            }
            else
            {
                return PokerPlayerContexts.Where(i => i.CurrentRole != PlanningPokerRole.Board).Select(i => new PlanningPokerPlayerInfo(i.Player, GetStatus(i.SelectedValue), i.CurrentRole)).ToList();
            }
                
            
        }

        private string GetStatus(int? value)
        {
            if (EveryoneHasChosenCard)
            {
                //Player is not eligible to play (is a board most likely)
                if (!value.HasValue)
                {
                    return "";
                }
                return value.Value.ToString();
            }
                

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
                return PokerPlayerContexts.Where(i => i.CurrentRole != PlanningPokerRole.Board).All(i => i.HasSelectedCard);
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