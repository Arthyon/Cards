using Cards.Messaging.Pipeline;
using Cards.Presentation.Games.PlanningPoker.Messaging.Events;
using Cards.Presentation.Games.PlanningPoker.Messaging.Steps;

namespace Cards.Presentation.Games.PlanningPoker.Messaging
{
    public class PokerPipelines : PipelineRegistry
    {
        public override void Configure(PipelineCollection pipelines)
        {
            pipelines.Add(new Pipeline<PlayerJoinedPokerEvent>()
                .Register(AddConnectionIdToGameGroupStep.AddConnectionIdToGameGroup)
                .Register(BroadcastOwnStateToPlayerStep.BroadcastOwnStateToPlayer)
                .Register(BroadcastUpdatedGameStateStep.BroadcastUpdatedGameState));

            pipelines.Add(new StoppablePipeline<PokerGameStartedEvent>()
                .Register(CanGameStartStep.CanGameStart)
                .Register(StartPokerGameStep.StartPokerGame)
                .Register(BroadcastUpdatedGameStateStep.BroadcastUpdatedGameState));

            pipelines.Add(new Pipeline<PlayerPlayedCardEvent>()
                .Register(PlayCardForPlayerStep.PlayCardForPlayer)
                .Register(BroadcastUpdatedBoardStateStep.BroadcastUpdatedBoardState));

            pipelines.Add(new Pipeline<PlayerUpdatedInformationEvent>()
                .Register(ChangePlayerRoleStep.ChangePlayerRole)
                .Register(BroadcastUpdatedBoardStateStep.BroadcastUpdatedBoardState));

            pipelines.Add(new Pipeline<PokerNewRoundStartedEvent>()
                .Register(ResetGameStateStep.ResetGameState)
                .Register(BroadcastOwnStateToAllPlayersStep.BroadcastOwnStateToAllPlayers)
                .Register(BroadcastUpdatedGameStateStep.BroadcastUpdatedGameState));

        }
    }
}