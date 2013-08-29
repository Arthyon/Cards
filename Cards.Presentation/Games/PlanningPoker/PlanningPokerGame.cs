using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Cards.Lobby;
using Cards.Lobby.GameComponents;

namespace Cards.Presentation.Games.PlanningPoker
{
    public class PlanningPokerGame : Game
    {
        public PlanningPokerGame(int maxPlayers) : base(GameTypes.PlanningPoker,"Planning Poker", maxPlayers)
        {
            ChosenCard = new List<Tuple<Player, int?>>();
        }

        private List<Tuple<Player, int?>> ChosenCard { get; set; }

        public object ChosenCardList
        {
            get
            {
                return ChosenCard.Select(
                    i => new {Name = i.Item1.Name, Status = GetStatus(i.Item2)});
            }
        }

        private string GetStatus(int? value)
        {
            if (EveryoneHasChosenCard)
                return value.Value.ToString();

            return value.HasValue ? "Card chosen" : "Pending";
        }

        protected override void PlayerAdded(Player player)
        {
            ChosenCard.Add(Tuple.Create<Player, int?>(player, null));
        }

        public bool EveryoneHasChosenCard
        {
            get
            {
                return ChosenCard.TrueForAll(i => i.Item2 != null);
            }
        }

        public void PlayCard(Player player, int value)
        {
            var tuple = ChosenCard.First(i => i.Item1 == player);
            var index = ChosenCard.IndexOf(tuple);
            ChosenCard[index] = Tuple.Create<Player, int?>(player, value);
        }
    }
}