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
            ChosenCard = new List<Tuple<string, int?>>();
        }

        public List<Tuple<string, int?>> ChosenCard { get; set; }

        protected override void PlayerAdded(Player player)
        {
            ChosenCard.Add(Tuple.Create<string, int?>(player.Identifier, null));
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
            var tuple = ChosenCard.First(i => i.Item1 == player.Identifier);
            var index = ChosenCard.IndexOf(tuple);
            ChosenCard[index] = Tuple.Create<string, int?>(player.Identifier, value);
        }
    }
}