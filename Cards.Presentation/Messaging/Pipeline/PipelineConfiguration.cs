using Cards.Messaging.Pipeline;
using Cards.Presentation.Messaging.Pipeline.Events;
using Cards.Presentation.Messaging.Pipeline.Events.PlayerEvents;
using Cards.Presentation.Messaging.Pipeline.Steps.GameCreated;
using Cards.Presentation.Messaging.Pipeline.Steps.PlayerConnectedToHub;
using Cards.Presentation.Messaging.Pipeline.Steps.PlayerDisconnectedFromHub;
using Cards.Presentation.Messaging.Pipeline.Steps.PlayerJoinsGame;

namespace Cards.Presentation.Messaging.Pipeline
{


    public class PipelineConfiguration : PipelineRegistry
    {
        public override void Configure(PipelineCollection pipelines)
        {
            pipelines.Add(new Pipeline<GameCreatedEvent>()
                .Register(AddGameToLobbyStep.AddGameToLobby)
                .Register(PlayerJoinsGameStep.PlayerJoinsGame)
                .Register(BroadcastGameCreatedStep.BroadcastGameCreated));

            pipelines.Add(new Pipeline<PlayerJoinedGameEvent>()
                .Register(DoesGameExistStep.DoesGameExist)
                .Register(PlayerJoinsGameStep.PlayerJoinsGame)
                .Register(BroadcastPlayerJoinedMessageStep.BroadcastPlayerJoinedMessage));

            pipelines.Add(new Pipeline<PlayerConnectedToHubEvent>()
                .Register(AddPlayerToCurrentPlayersStep.AddPlayerToCurrentPlayers)
                .Register(MarkPlayerAsOnlineStep.MarkPlayerAsOnline)
                .Register(AddConnectionIdToPlayerStep.AddConnectionIdToPlayer));

            pipelines.Add(new Pipeline<PlayerDisconnectedFromHubEvent>()
                .Register(RemovePlayerFromCurrentPlayersStep.RemovePlayerFromCurrentPlayers)
                .Register(MarkPlayerAsOfflineStep.MarkPlayerAsOffline));

        }
    }
}