using System.Linq;
using Cards.Presentation.Core;
using Cards.Presentation.Games.PlanningPoker.Messaging.Events;
using Cards.Presentation.Games.PlanningPoker.Objects;

namespace Cards.Presentation.Games.PlanningPoker.Messaging.Steps
{
    public class BroadcastUpdatedBoardStateStep
    {
        public static bool BroadcastUpdatedBoardState(PlanningPokerEventBase ev)
        {
            ev.HubContext.Clients.Game(ev.CurrentPlayer)
                .boardStateUpdated(new PlanningPokerBoardState
                {
                    RoundFinished = ev.CurrentGame.EveryoneHasChosenCard,
                    Players = ev.CurrentGame.PlayerInformation(includeBoard: false),
                    GameContainsBoard = ev.CurrentGame.GetPokerPlayerContexts().Any(i => i.CurrentRole == PlanningPokerRole.Board),
                    AllPlayers = ev.CurrentGame.PlayerInformation(),
                });

            return true;
        }
    }
}