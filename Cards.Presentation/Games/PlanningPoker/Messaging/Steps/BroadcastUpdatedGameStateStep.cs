using System.Linq;
using Cards.Lobby.GameComponents;
using Cards.Presentation.Core;
using Cards.Presentation.Games.PlanningPoker.Messaging.Events;
using Cards.Presentation.Games.PlanningPoker.Objects;

namespace Cards.Presentation.Games.PlanningPoker.Messaging.Steps
{
    public class BroadcastUpdatedGameStateStep
    {

        public static bool BroadcastUpdatedGameState(PlanningPokerEventBase ev)
        {
            var roundState = new PlanningPokerGameState
            {
                InProgress = ev.CurrentGame.Status == GameStatus.InProgress,
                Cards = ev.CurrentGame.DefaultHand,
                BoardState = new PlanningPokerBoardState
                {
                    RoundFinished = ev.CurrentGame.EveryoneHasChosenCard,
                    Players = ev.CurrentGame.PlayerInformation(includeBoard: false),
                    GameContainsBoard = ev.CurrentGame.GetPokerPlayerContexts().Any(i => i.CurrentRole == PlanningPokerRole.Board),
                    AllPlayers = ev.CurrentGame.PlayerInformation()
                },

            };

            ev.HubContext.Clients.Game(ev.CurrentPlayer).syncState(roundState);

            return true;
        }

        
 
    }

  
    
}